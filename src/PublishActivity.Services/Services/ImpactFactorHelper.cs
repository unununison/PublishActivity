using Microsoft.EntityFrameworkCore;
using PublishActivity.Data.Models;
using PublishActivity.Services.Services.Interfaces;
using System.Net.Http.Json;

namespace PublishActivity.Services.Services
{
	public class ImpactFactorHelper : IImpactFactorService
	{
		private readonly IDbContextFactory<BasePpsContext> _dbContextFactory;

		public ImpactFactorHelper(IDbContextFactory<BasePpsContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public async Task<Dictionary<int, decimal>?> FindAsync(string issn)
		{
			using var httpClient = new HttpClient();
			return await httpClient.GetFromJsonAsync<Dictionary<int, decimal>>("https://localhost:7281/get/" + issn);
		}

		public Task Update(RetingJournal retingJournal)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Edition>> UpdateAllImpactFactorsAsync()
		{
			throw new NotImplementedException();
		}

		public async Task UpdateImpactFactorAsync(int editionId, Dictionary<int, decimal> impactFactors)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			var edition = context.Editions.SingleOrDefault(x => x.IdEdt == editionId);
			if (edition is null)
			{
				throw new InvalidOperationException();
			}
			using var httpClient = new HttpClient();
			await httpClient.PostAsync("https://localhost:7281/update/" + edition.Issn, null);
		}
	}
}
