using HtmlAgilityPack;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PublishActivity.Data.Models;
using PublishActivity.Services.Services.Interfaces;
using System.Xml;

namespace PublishActivity.Services.Services
{
	public class ImpactFactorService : IImpactFactorService
	{
		private readonly IDbContextFactory<BasePpsContext> _dbContextFactory;

		private const string JOURNAL_LINK_FORMAT = "https://www.scimagojr.com/{0}";
		private const string JOURNAL_PAGE_LINK_FORMAT = "https://www.scimagojr.com/journalsearch.php?q={0}";
		private const string SCIMAGO_LINK = "https://www.scimagojr.com/";
		private const string JOURNAL_SEARCH = "journalsearch.php";
		private const string HREF_ATTRIBUTE_NAME = "href";

		public ImpactFactorService(IDbContextFactory<BasePpsContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		#region Private methods

		private async Task InsertInto(RetingJournal retingJournal)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			var parameter = new SqlParameter("@impactFactor", retingJournal.ValumeInd)
			{
				Scale = 3,
			};
			context.Database
						.ExecuteSqlRaw("INSERT INTO reting_Journal (Valume_Ind, Date_EditJ, Ind_Journal_id_IndJ, id_Edt, yearJ) VALUES(@impactFactor, {1}, {2}, {3}, {4})",
						parameter, retingJournal.DateEditJ, retingJournal.IndJournalIdIndJ, retingJournal.IdEdt, retingJournal.YearJ);
		}

		public async Task Update(RetingJournal retingJournal)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			var parameter = new SqlParameter("@impactFactor", retingJournal.ValumeInd)
			{
				Scale = 3,
			};
			context.Database
						.ExecuteSqlRaw("UPDATE reting_Journal SET Valume_Ind = @impactFactor WHERE id_Edt = {1} AND yearJ = {2}",
						parameter, retingJournal.IdEdt, retingJournal.YearJ);
		}
		#endregion

		private T GetValue<T>(string value)
		{
			return (T)Convert.ChangeType(value, typeof(T));
		}

		/// <inheritdoc/>
		public async Task<Dictionary<int, decimal>?> FindAsync(string issn)
		{
			using var httpClient = new HttpClient();
			var html = await httpClient.GetStringAsync(string.Format(JOURNAL_PAGE_LINK_FORMAT, issn));

			var htmlDocument = new HtmlDocument();
			htmlDocument.LoadHtml(html);
			var link = htmlDocument.DocumentNode.SelectNodes("//a").Single(x => x.GetAttributeValue(HREF_ATTRIBUTE_NAME, string.Empty).Contains(JOURNAL_SEARCH)).GetAttributeValue(HREF_ATTRIBUTE_NAME, string.Empty);

			html = await httpClient.GetStringAsync(string.Format(JOURNAL_LINK_FORMAT, link));
			htmlDocument = new HtmlDocument();
			htmlDocument.LoadHtml(html);
			var sjrNode = htmlDocument.DocumentNode.SelectNodes("//table");
			var table = sjrNode.FirstOrDefault(x => x.InnerHtml.Contains("sjr", StringComparison.InvariantCultureIgnoreCase));
			var body = table?.ChildNodes.Single(x => x.Name.Contains("body", StringComparison.InvariantCultureIgnoreCase));

			if (body is null)
			{
				return null;
			}

			var result = new Dictionary<int, decimal>();
			foreach (HtmlNode row in body.SelectNodes("tr"))
			{
				var cells = row.SelectNodes("th|td");
				result.Add(int.Parse(cells[0].InnerText), GetValue<decimal>(cells[1].InnerText));
			}

			return result;
		}

		/// <inheritdoc/>
		public async Task UpdateImpactFactorAsync(int editionId, Dictionary<int, decimal> impactFactors)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			var edition = context.Editions.SingleOrDefault(x => x.IdEdt == editionId);

			if (edition is null)
			{
				throw new InvalidOperationException();
			}

			var name = "Импакт-фактор";
			foreach (var impactFactor in impactFactors)
			{
				var indJournal = context.IndJournals.First(f => f.NameIndJ == name).IdIndJ;
				var reting = new RetingJournal()
				{
					IdEdt = edition.IdEdt,
					ValumeInd = Convert.ToDecimal(impactFactor.Value),
					IndJournalIdIndJ = indJournal,
					DateEditJ = DateTime.Now,
					YearJ = impactFactor.Key.ToString(),
				};

				var retingJournal = await context.RetingJournals.FirstOrDefaultAsync(f => f.IdEdt == edition.IdEdt && f.YearJ == impactFactor.Key.ToString());

				if (retingJournal is null)
				{
					await InsertInto(reting);
				}
				else if (retingJournal.ValumeInd != impactFactor.Value)
				{
					await Update(reting);
				}
			}

			context.SaveChanges();
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<Edition>> UpdateAllImpactFactorsAsync()
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			var errorEditions = new List<Edition>();
			var editions = context.Editions.ToList();
			foreach (var edition in editions)
			{
				try
				{
					var impactFactors = await FindAsync(edition.Issn) ?? new();
					await UpdateImpactFactorAsync(edition.IdEdt, impactFactors);
				}
				catch
				{
					errorEditions.Add(edition);
				}
			}

			return errorEditions;
		}
	}
}
