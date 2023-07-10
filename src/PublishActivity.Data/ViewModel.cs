using Microsoft.EntityFrameworkCore;
using PublishActivity.Data.Models;

namespace PublishActivity.Data
{
	public sealed class ViewModel
	{
		private IDbContextFactory<BasePpsContext> _dbContextFactory;

		public AbstractBase[] AbstractBases { get; set; }

		public IEnumerable<Author> Authors { get; set; }

		public IEnumerable<string> ImpactFactorYears { get; set; }

		public IEnumerable<string> Years { get; set; }

		public IEnumerable<string> Ages { get; set; }

		public IEnumerable<Language> Languages { get; set; }

		public IEnumerable<SprStructure> PublicationTypes { get; set; }

		public IEnumerable<string> PublishTypes { get; set; }

		public IEnumerable<Tuple<string, string>> Issns { get; set; }

		public IEnumerable<Tuple<string, string>> Isbns { get; set; }

		public IEnumerable<SprFormatInfo> SprFormatInfos { get; set; }

		public IEnumerable<OfficeDepart> OfficeDeparts { get; set; }

		public IEnumerable<D> DifSovets { get; set; }

		public IEnumerable<SprThematic> SprThematics { get; set; }

		public IEnumerable<LevelEdition> LevelEditions { get; set; }

		public ViewModel(IDbContextFactory<BasePpsContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;

			using var context = _dbContextFactory.CreateDbContext();

			AbstractBases = Enum.GetValues<AbstractBase>();
			var years = context.Editions.Select(x => x.Year).ToList();
			ImpactFactorYears = years.Union(years).OrderBy(x => Convert.ToInt32(x)).ToList();

			Years = years.Union(years).OrderBy(x => Convert.ToInt32(x)).ToList();

			Languages = context.Languages.ToList();
			Authors = context.Authors.ToList();
			PublicationTypes = context.SprStructures.ToList();
			PublishTypes = context.Editions.Select(x => x.EdnTypeEd).Distinct().ToList();
			Issns = context.Editions.Select(x => Tuple.Create(x.Issn, x.NameEdt)).Distinct().ToList();
			Isbns = context.Editions.Select(x => Tuple.Create(x.Isbn, x.NameEdt)).Distinct().ToList();
			SprFormatInfos = context.SprFormatInfos.ToList();
			OfficeDeparts = context.OfficeDeparts.ToList();
			DifSovets = context.Ds.ToList();
			SprThematics = context.SprThematics.ToList();
			LevelEditions = context.LevelEditions.ToList();

			var maxAge = DateTime.UtcNow.Year - Convert.ToInt32(context.Authors.Min(x => Convert.ToInt32(x.YearBirth)));
			var minAge = DateTime.UtcNow.Year - Convert.ToInt32(context.Authors.Max(x => Convert.ToInt32(x.YearBirth)));

			Ages = Enumerable.Range(minAge, maxAge - minAge + 1).Select(X => X.ToString()).ToList();
		}

	}
}
