using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PublishActivity.Data;
using PublishActivity.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishActivity.Services.Services
{

	/// <summary>
	/// Тип издания
	/// </summary>
	public enum EditionType
	{
		/// <summary>
		/// Журнал
		/// </summary>
		Journal,

		/// <summary>
		/// Книга
		/// </summary>
		Book,
	}

	public sealed class ReportFilter
	{
		/// <inheritdoc cref="Data.AbstractBase" path="/summary/node()" />
		public AbstractBase? AbstractBase { get; set; }

		/// <summary>
		/// тип публикации
		/// </summary>
		public int? SprStructureId { get; set; }

		/// <summary>
		/// Нижняя граница года
		/// </summary>
		public int? LowerYear { get; set; }

		/// <summary>
		/// Верхняя граница года
		/// </summary>
		public int? UpperYear { get; set; }

		public bool IsSummaryImpactFactor { get; set; }
	}

	public static class FilterHelper
	{
		public static IEnumerable<StructuralPart>? GetPublicationsByType(this IEnumerable<StructuralPart> structuralParts, ReportFilter filter)
		{
			if (filter.SprStructureId is null)
			{
				return structuralParts;
			}
			else
			{
				return structuralParts.Where(x => x.SprStructureIdTypePart == filter.SprStructureId);
			}
		}

		public static IEnumerable<StructuralPart>? GetPublicationsByBase(this IEnumerable<StructuralPart> structuralParts, ReportFilter filter)
		{
			return structuralParts;
		}
	}


	public class ReportsService
	{
		private readonly IDbContextFactory<BasePpsContext> _dbContextFactory;

		public ReportsService(IDbContextFactory<BasePpsContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
		}

		public Task<IEnumerable<StructuralPart>> GetImpactFactor(ReportFilter filter, ref decimal summaryImpactFactor)
		{
			using var context = _dbContextFactory.CreateDbContext();
			if (filter.IsSummaryImpactFactor)
			{
				if (filter.AbstractBase is AbstractBase.All)
				{
					var publications = context.StructuralParts
						.Include(x => x.EditionIdEdtNavigation)
						.Where(x => !string.IsNullOrWhiteSpace(x.EditionIdEdtNavigation.Issn))
						.ToList();

					foreach (var publication in publications)
					{
						var impactFactor = context.RetingJournals.FirstOrDefault(x => x.IdEdt == publication.EditionIdEdt)?.ValumeInd;
						if (impactFactor is { } value)
						{
							summaryImpactFactor += value;
						}
					}

					return Task.FromResult((IEnumerable<StructuralPart>)publications);
				}
				else
				{
					throw new NotImplementedException();
				}
			}
			else
			{
				throw new NotImplementedException();
			}
		}

		public async Task<IEnumerable<StructuralPart>?> GetReport(ReportFilter filter)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();

			IEnumerable<StructuralPart>? publications = context.StructuralParts.Include(x => x.EditionIdEdtNavigation).ToList();
			publications = publications.GetPublicationsByType(filter);

			if (filter.LowerYear is { } down && filter.UpperYear is { } up)
			{
				publications = publications?.Where(x => Convert.ToInt32(x.EditionIdEdtNavigation.Year) >= down && Convert.ToInt32(x.EditionIdEdtNavigation.Year) <= up);
			}

			return publications;
		}


	}
}
