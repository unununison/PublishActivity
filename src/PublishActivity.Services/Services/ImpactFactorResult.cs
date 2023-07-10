using PublishActivity.Data.Models;

namespace PublishActivity.Services.Services
{
	public sealed class ImpactFactorResult
	{
		public decimal ImpactFactor { get; set; }
		public IEnumerable<StructuralPart>? StructuralParts { get; set; }
	}
}
