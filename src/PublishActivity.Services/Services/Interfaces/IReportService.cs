using PublishActivity.Data;
using PublishActivity.Data.Models;
using System.Runtime.CompilerServices;

namespace PublishActivity.Services.Services.Interfaces
{
	public sealed class ReportResult
	{
		public string Name { get; set; }
		public string Value { get; set; }
		public IEnumerable<StructuralPart> ParticipatingArticles { get; set; }

		public IEnumerable<StructuralPart> NonParticipatingArticles { get; set; }
	}

	public interface IReportService
	{
		Dictionary<string, string> GetForm1Report();
		Dictionary<string, string> GetForm2Report();
		Dictionary<string, string> GetFSMNOReport();
		Dictionary<string, string> GetCustomReport(string keys);

		Task<ImpactFactorResult> GetImpactFactor(string lowerBoundYear, string upperBoundYear);

		Task<IEnumerable<StructuralPart>> GetYears(Filters filters);

		Task<IEnumerable<StructuralPart>> GetLanguages(Filters filters);

		Task<IEnumerable<StructuralPart>> GetAbstractBases(Filters filters);

		Task<IEnumerable<StructuralPart>> GetAuthor(Filters filters);

		Task<IEnumerable<StructuralPart>> GetPublishType(Filters filters);

		Task<IEnumerable<StructuralPart>> GetPublicationType(Filters filters);

		Task<IEnumerable<StructuralPart>> GetIssn(Filters filters);

		Task<IEnumerable<StructuralPart>> GetIsbn(Filters filters);

		Task<IEnumerable<StructuralPart>> GetAuthorYears(Filters filters);

		Task<IEnumerable<StructuralPart>> GetSprFormatInfos(Filters filters);

		Task<IEnumerable<StructuralPart>> GetOfficeDeparts(Filters filters);

		Task<IEnumerable<StructuralPart>> GetDiffSovets(Filters filters);

		Task<IEnumerable<StructuralPart>> GetThematics(Filters filters);

		Task<IEnumerable<StructuralPart>> GetLevels(Filters filters);
	}
}
