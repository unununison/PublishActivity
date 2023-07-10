using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PublishActivity.Data;
using PublishActivity.Data.Models;
using PublishActivity.Services.Services.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Reports.Components.Report
{
	public partial class ReportImpactFactorFilter
	{
		[Inject]
		public IDbContextFactory<BasePpsContext> _dbContextFactory { get; set; } = null!;

		[Inject]
		public IReportService _reportService { get; set; } = null!;

		private PublishActivity.Data.Filters _filters = null!;
		private ViewModel _viewModel = null!;

		private bool _isLoading;
		private decimal _impactFactor;

		private IEnumerable<StructuralPart> _impactFactorStructuralParts = null!;
		private IEnumerable<StructuralPart> _structuralParts = null!;

		private int? _citations;

		protected override async Task OnInitializedAsync()
		{
			_filters = new();
			_filters.AbstractBase = AbstractBase.All;
			_viewModel = new(_dbContextFactory);

			await base.OnInitializedAsync();
		}

		private void Clear()
		{
			_filters = new();
			_filters.AbstractBase = AbstractBase.All;
		}

		protected override async Task OnParametersSetAsync()
		{
			await base.OnParametersSetAsync();
		}

		private void SelectImpactFactor()
		{
			if (_filters.IsImpactFactorSelected)
			{
				_filters.LowerBoundImpactFactorYear = null;
				_filters.UpperBoundImpactFactorYear = null;
			}

			_filters.IsImpactFactorSelected = !_filters.IsImpactFactorSelected;
		}

		private async Task GetReport()
		{
			_isLoading = true;
			await Task.Delay(1);
			_structuralParts = new List<StructuralPart>();
			await InvokeAsync(StateHasChanged);
			if (_filters.IsImpactFactorSelected)
			{
				var report = await _reportService.GetImpactFactor(_filters.LowerBoundImpactFactorYear, _filters.UpperBoundImpactFactorYear);
				_impactFactor = report.ImpactFactor;
				_impactFactorStructuralParts = report.StructuralParts;
			}


			_structuralParts = await _reportService.GetAbstractBases(_filters);

			var publs = await _reportService.GetYears(_filters);

			if (_filters.LowerBoundYear is { } && _filters.UpperBoundYear is { })
			{
				if (publs.Any())
				{
					_structuralParts = _structuralParts.Where(x => publs.Any(y => y.IdPart == x.IdPart)).ToList();
				}
				else
				{
					_structuralParts = new List<StructuralPart>();
				}
			}

			publs = await _reportService.GetLanguages(_filters);

			if (_filters.LanguageId is { })
			{
				if (publs.Any())
				{
					_structuralParts = _structuralParts.Where(x => publs.Any(y => y.IdPart == x.IdPart)).ToList();
				}
				else
				{
					_structuralParts = new List<StructuralPart>();
				}
			}

			publs = await _reportService.GetAuthor(_filters);

			if (_filters.InputAuthor is { })
			{
				if (publs.Any())
				{
					_structuralParts = _structuralParts.Where(x => publs.Any(y => y.IdPart == x.IdPart)).ToList();
				}
				else
				{
					_structuralParts = new List<StructuralPart>();
				}
			}

			publs = await _reportService.GetAuthorYears(_filters);

			if (_filters.LowerBoundAge is { } && _filters.UpperBoundAge is { })
			{
				if (publs.Any())
				{
					_structuralParts = _structuralParts.Where(x => publs.Any(y => y.IdPart == x.IdPart)).ToList();
				}
				else
				{
					_structuralParts = new List<StructuralPart>();
				}
			}

			publs = await _reportService.GetPublicationType(_filters);

			if (_filters.PublicationTypeId is { })
			{
				if (publs.Any())
				{
					_structuralParts = _structuralParts.Where(x => publs.Any(y => y.IdPart == x.IdPart)).ToList();
				}
				else
				{
					_structuralParts = new List<StructuralPart>();
				}
			}

			publs = await _reportService.GetPublishType(_filters);

			if (_filters.PublishType is { })
			{
				if (publs.Any())
				{
					_structuralParts = _structuralParts.Where(x => publs.Any(y => y.IdPart == x.IdPart)).ToList();
				}
				else
				{
					_structuralParts = new List<StructuralPart>();
				}
			}

			publs = await _reportService.GetIssn(_filters);

			if (_filters.Issn is { })
			{
				if (publs.Any())
				{
					_structuralParts = _structuralParts.Where(x => publs.Any(y => y.IdPart == x.IdPart)).ToList();
				}
				else
				{
					_structuralParts = new List<StructuralPart>();
				}
			}

			publs = await _reportService.GetIsbn(_filters);

			if (_filters.Isbn is { })
			{
				if (publs.Any())
				{
					_structuralParts = _structuralParts.Where(x => publs.Any(y => y.IdPart == x.IdPart)).ToList();
				}
				else
				{
					_structuralParts = new List<StructuralPart>();
				}
			}

			publs = await _reportService.GetSprFormatInfos(_filters);

			if (_filters.SprFormatInfoId is { })
			{
				if (publs.Any())
				{
					_structuralParts = _structuralParts.Where(x => publs.Any(y => y.IdPart == x.IdPart)).ToList();
				}
				else
				{
					_structuralParts = new List<StructuralPart>();
				}
			}

			publs = await _reportService.GetOfficeDeparts(_filters);

			if (_filters.OfficeDepartId is { })
			{
				if (publs.Any())
				{
					_structuralParts = _structuralParts.Where(x => publs.Any(y => y.IdPart == x.IdPart)).ToList();
				}
				else
				{
					_structuralParts = new List<StructuralPart>();
				}
			}

			publs = await _reportService.GetDiffSovets(_filters);

			if (_filters.DifSovetId is { })
			{
				if (publs.Any())
				{
					_structuralParts = _structuralParts.Where(x => publs.Any(y => y.IdPart == x.IdPart)).ToList();
				}
				else
				{
					_structuralParts = new List<StructuralPart>();
				}
			}

			publs = await _reportService.GetThematics(_filters);

			if (_filters.IdThematic is { })
			{
				if (publs.Any())
				{
					_structuralParts = _structuralParts.Where(x => publs.Any(y => y.IdPart == x.IdPart)).ToList();
				}
				else
				{
					_structuralParts = new List<StructuralPart>();
				}
			}

			publs = await _reportService.GetLevels(_filters);

			if (_filters.LevelEdition is { })
			{
				if (publs.Any())
				{
					_structuralParts = _structuralParts.Where(x => publs.Any(y => y.IdPart == x.IdPart)).ToList();
				}
				else
				{
					_structuralParts = new List<StructuralPart>();
				}
			}

			if (_structuralParts.Any())
			{
				//_citations = _structuralParts.Sum(x => x.EditionIdEdtNavigation.Volume)
			}

			_isLoading = false;
			await InvokeAsync(StateHasChanged);
		}
	}
}
