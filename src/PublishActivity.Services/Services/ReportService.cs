using Microsoft.EntityFrameworkCore;
using PublishActivity.Data;
using PublishActivity.Data.Models;
using PublishActivity.Services.Services.Interfaces;

namespace PublishActivity.Services.Services
{
	public class ReportService : IReportService
	{
		private readonly IDbContextFactory<BasePpsContext> _dbContextFactory;

		public ReportService(IDbContextFactory<BasePpsContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		/*private KeyValuePair<string, string> GetKey1()
		{
			var tmp1 = _context.TmpExports1.Where(w => w.Year == YearReport).ToList();
			tmp = tmp1.GroupBy(g => g.NamePart).ToList();
			return new("Опубликовано статей в рецензируемых научных журналах", tmp.Count().ToString());
		}*/

		public Dictionary<string, string> GetCustomReport(string keys)
		{
			throw new NotImplementedException();
			//	var allKeys = keys.Split(";").Select(x => Convert.ToInt32(x));

		}

		public Dictionary<string, string> GetForm1Report()
		{
			throw new NotImplementedException();
		}

		public Dictionary<string, string> GetForm2Report()
		{
			throw new NotImplementedException();
		}

		public Dictionary<string, string> GetFSMNOReport()
		{
			throw new NotImplementedException();
		}

		public async Task<ImpactFactorResult> GetImpactFactor(string lowerBoundYear, string upperBoundYear)
		{
			using var context = _dbContextFactory.CreateDbContext();
			var lowerYear = Convert.ToInt32(lowerBoundYear);
			var upperYear = Convert.ToInt32(upperBoundYear);
			var edtitionIds = context.Editions
				.Where(x => Convert.ToInt32(x.Year) >= lowerYear && Convert.ToInt32(x.Year) <= upperYear && !string.IsNullOrWhiteSpace(x.Issn))
				.Select(x => x.IdEdt)
				.ToList();

			var retings = context.RetingJournals
				.Include(x => x.IdEdtNavigation)
				.Where(x => x.IdEdt != null && edtitionIds.Contains((int)x.IdEdt))
				.ToList();

			var impactFactor = retings.Sum(x => x.ValumeInd);

			var result = context.StructuralParts.ToList().Where(x => retings.Any(y => y.IdEdtNavigation.IdEdt == x.EditionIdEdt));
			return new()
			{
				ImpactFactor = impactFactor,
				StructuralParts = result,
			};
		}

		public async Task<IEnumerable<StructuralPart>> GetLanguages(Filters filters)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();

			var structuralParts = context.StructuralParts
				.Include(x => x.EditionIdEdtNavigation)
				.Include(x => x.SprStructureIdTypePartNavigation)
				.Include(x => x.IdLanguageNavigation)
				.Where(x => x.IdLanguage == filters.LanguageId)
				.ToList();

			return structuralParts;
		}

		public async Task<IEnumerable<StructuralPart>> GetYears(Filters filters)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();

			var structuralParts = context.StructuralParts
				.Include(x => x.EditionIdEdtNavigation)
				.Include(x => x.SprStructureIdTypePartNavigation)
				.Include(x => x.IdLanguageNavigation)
				.Where(x => Convert.ToInt32(x.EditionIdEdtNavigation.Year) >= Convert.ToInt32(filters.LowerBoundYear)
					&& Convert.ToInt32(x.EditionIdEdtNavigation.Year) <= Convert.ToInt32(filters.UpperBoundYear))
				.ToList();

			return structuralParts;
		}

		public async Task<IEnumerable<StructuralPart>> GetAbstractBases(Filters filters)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			if (filters.AbstractBase is AbstractBase.All)
			{
				return context.StructuralParts
					.Include(x => x.SprStructureIdTypePartNavigation)
					.ToList();
			}
			return new List<StructuralPart>();
		}

		public async Task<IEnumerable<StructuralPart>> GetAuthor(Filters filters)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			var UID = context.Authors.Where(x =>
			filters.InputAuthor.Contains(x.FirstName) &&
			filters.InputAuthor.Contains(x.LastName) &&
			filters.InputAuthor.Contains(x.Patronymic)).FirstOrDefault()?.Uid;

			var structuralParts = context.AuthorPubls
				.Include(x => x.StructuralPartIdPartNavigation)
				.ThenInclude(x => x.EditionIdEdtNavigation)
				.Where(x => x.AuthorUid == UID)
				.ToList()
				.Select(x => x.StructuralPartIdPartNavigation);

			return structuralParts;
		}

		public async Task<IEnumerable<StructuralPart>> GetPublicationType(Filters filters)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			var structuralParts = context.StructuralParts
				.Include(x => x.SprStructureIdTypePartNavigation)
				.Where(x => x.SprStructureIdTypePartNavigation.IdTypePart == filters.PublicationTypeId)
				.ToList();

			return structuralParts;
		}

		public async Task<IEnumerable<StructuralPart>> GetPublishType(Filters filters)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			var structuralParts = context.StructuralParts
				.Include(x => x.EditionIdEdtNavigation)
				.Where(x => x.EditionIdEdtNavigation.EdnTypeEd == filters.PublishType)
				.ToList();

			return structuralParts;
		}

		public async Task<IEnumerable<StructuralPart>> GetIssn(Filters filters)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			var structuralParts = context.StructuralParts
				.Include(x => x.EditionIdEdtNavigation)
				.Where(x => x.EditionIdEdtNavigation.Issn == filters.Issn)
				.ToList();

			return structuralParts;
		}

		public async Task<IEnumerable<StructuralPart>> GetAuthorYears(Filters filters)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			var yd = Convert.ToInt32(filters.LowerBoundAge);
			var yu = Convert.ToInt32(filters.UpperBoundAge);

			var ly = DateTime.UtcNow.Year - yd;
			var ld = DateTime.UtcNow.Year - yu;

			var UIDS = context.Authors.Where(x => Convert.ToInt32(x.YearBirth) >= ld && Convert.ToInt32(x.YearBirth) <= ly).ToList();

			var structuralParts = context.AuthorPubls
				.Include(x => x.StructuralPartIdPartNavigation)
				.ThenInclude(x => x.EditionIdEdtNavigation)
				.ToList()
				.Where(x => UIDS.Any(y => y.Uid == x.AuthorUid))
				.Select(x => x.StructuralPartIdPartNavigation);

			return structuralParts;
		}

		public async Task<IEnumerable<StructuralPart>> GetIsbn(Filters filters)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			var structuralParts = context.StructuralParts
				.Include(x => x.EditionIdEdtNavigation)
				.Where(x => x.EditionIdEdtNavigation.Isbn == filters.Isbn)
				.ToList();

			return structuralParts;
		}

		public async Task<IEnumerable<StructuralPart>> GetSprFormatInfos(Filters filters)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			var structuralParts = context.StructuralParts
				.Include(x => x.EditionIdEdtNavigation)
				.ThenInclude(x => x.SprFormatInfoTypeEdNavigation)
				.Where(x => x.EditionIdEdtNavigation.SprFormatInfoTypeEdNavigation.TypeEd == filters.SprFormatInfoId)
				.ToList();

			return structuralParts;
		}

		public async Task<IEnumerable<StructuralPart>> GetOfficeDeparts(Filters filters)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			var UIDS = context.Authors
				.Include(x => x.OfficeDepartKodOfficeNavigation)
				.Where(x => x.OfficeDepartKodOfficeNavigation.KodOffice == filters.OfficeDepartId).ToList();

			var structuralParts = context.AuthorPubls
				.Include(x => x.StructuralPartIdPartNavigation)
				.ThenInclude(x => x.EditionIdEdtNavigation)
				.ToList()
				.Where(x => UIDS.Any(y => y.Uid == x.AuthorUid))
				.Select(x => x.StructuralPartIdPartNavigation);

			return structuralParts;
		}

		public async Task<IEnumerable<StructuralPart>> GetDiffSovets(Filters filters)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			var authors = context.Ds.Where(x => x.Ds == filters.DifSovetId).ToList();
			var UID = context.Authors.ToList().Where(x =>
			authors.Any(y => y.Fio.Contains(x.FirstName)) &&
			authors.Any(y => y.Fio.Contains(x.LastName)) &&
			authors.Any(y => y.Fio.Contains(x.Patronymic))).ToList();

			var structuralParts = context.AuthorPubls
				.Include(x => x.StructuralPartIdPartNavigation)
				.ThenInclude(x => x.EditionIdEdtNavigation)
				.ToList()
				.Where(x => UID.Any(y => y.Uid == x.AuthorUid))
				.Select(x => x.StructuralPartIdPartNavigation);

			return structuralParts;
		}

		public async Task<IEnumerable<StructuralPart>> GetThematics(Filters filters)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			var thematics = context.SprThematics
				.Where(x => x.IdThematic == filters.IdThematic)
				.ToList();

			var subjectHeads = context.SubjectsHeads
				.Include(x => x.StructuralPartIdPartNavigation)
				.ToList()
				.Where(x => thematics.Any(y => y.IdThematic == x.IdThematic));

			return subjectHeads.Select(x => x.StructuralPartIdPartNavigation);
		}

		public async Task<IEnumerable<StructuralPart>> GetLevels(Filters filters)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			var levels = context.LevelEditions
				.Include(x => x.Editions)
				.ThenInclude(x => x.StructuralParts)
				.Where(x => x.NameLevEdition == filters.LevelEdition)
				.ToList();

			return levels.SelectMany(x => x.Editions.SelectMany(y => y.StructuralParts)).ToList();
		}
	}
}
