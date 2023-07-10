using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PublishActivity.Services.Services.Interfaces;
using Reports.Data;
using PublishActivity.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using ExcelLibrary.SpreadSheet;

namespace Reports.Components.Workspaces
{
	public sealed class ErrorEdition
	{
		public string Name { get; set; }

		public string Issn { get; set; }

		public string Json { get; set; }

		public bool IsUpdated { get; set; }
	}
	public partial class ImpactFactorUpdate
	{
		[Inject]
		public IImpactFactorService _impactFactorService { get; set; }

		[Inject]
		public IDbContextFactory<BasePpsContext> _dbContextFactory { get; set; }

		public ImpactFactor ImpactFactor { get; set; }

		private string _progressMessage;
		private double _progress;
		public string ProgressBar => $"{_progress.ToString().Replace(',', '.')}%";

		private List<Edition> _editions;
		private List<ErrorEdition> _errorEditions = new List<ErrorEdition>();

		private bool _isFindStart;
		private bool _hasFindingError;

		private bool _isUpdateStart;

		private bool _canUpdateAll;
		private async Task<bool> CheckConnection()
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			try
			{
				context.Database.GetDbConnection().Open();
				if (context.Database.GetDbConnection().State == System.Data.ConnectionState.Open)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{
				return false;
			}
		}
		private async Task InitializeEditions()
		{
			_canUpdateAll = await CheckConnection();
			if (_canUpdateAll)
			{
				await using var context = await _dbContextFactory.CreateDbContextAsync();
				_editions = context.Editions.Where(x => x.Issn != null && !string.IsNullOrWhiteSpace(x.Issn)).ToList();
			}
		}

		protected override async Task OnInitializedAsync()
		{
			await InitializeEditions();
			await base.OnInitializedAsync();
		}

		protected override async Task OnParametersSetAsync()
		{
			SetParameters();
			await base.OnParametersSetAsync();
		}

		private void SetParameters()
		{
			_isIssnCorrect = true;
			_isUpdateStart = false;
			_progressMessage = string.Empty;
			_isFindStart = false;
			_hasFindingError = false;
			ImpactFactor = new();
		}

		private bool _isIssnCorrect;
		private void CheckIssn()
		{
			var issn = ImpactFactor.Issn;
			if (issn.Length < 8 || issn.Length > 10)
			{
				_isIssnCorrect = false;
			}
		}

		private async Task FindAndUpdateAsync()
		{
			CheckIssn();

			if (_isIssnCorrect)
			{
				var issn = ImpactFactor.Issn;
				var editionName = ImpactFactor.EditionName;
				SetParameters();
				_isFindStart = true;
				await Task.Delay(1);
				_hasFindingError = false;
				try
				{
					var impactFactors = await _impactFactorService.FindAsync(issn);
					ImpactFactor = new()
					{
						EditionName = editionName,
						Issn = issn,
						Values = impactFactors,
					};

					Workbook workbook = new Workbook();
					Worksheet worksheet = new Worksheet("ImpactFactor");
					int i = 0;
					foreach(var value in ImpactFactor.Values)
					{
						worksheet.Cells[i, 0] = new Cell(value.Key);
						worksheet.Cells[i, 1] = new Cell(value.Value.ToString());
						i++;
					}

					workbook.Worksheets.Add(worksheet);
					workbook.Save("ImpactFactor.xls");
				}
				catch
				{
					_hasFindingError = true;
				}
				_isFindStart = false;
			}
			await Task.Delay(1);
			StateHasChanged();
		}

		private async Task UpdateAllAsync()
		{
			SetParameters();
			_progressMessage = string.Empty;
			_errorEditions = new();
			_isUpdateStart = true;
			ImpactFactor = new();
			await using var context = await _dbContextFactory.CreateDbContextAsync();

			var count = 0;
			var step = 100d / _editions.Count;
			SetProgress(step, $"Обновлено {count} из {_editions.Count}. Ошибок {_errorEditions.Count}");

			foreach (var edition in _editions.GroupBy(x => x.Issn))
			{
				try
				{
					var impactFactors = await _impactFactorService.FindAsync(edition.Key);
					if (impactFactors is null)
					{
						_errorEditions.Add(new ErrorEdition()
						{
							Name = edition.First().NameEdt,
							Issn = edition.First().Issn
						});
						continue;
					}
					else
					{
						foreach (var editionItem in edition)
						{
							await _impactFactorService.UpdateImpactFactorAsync(editionItem.IdEdt, impactFactors);
							count++;
							SetProgress(step, $"Обновлено {count} из {_editions.Count}. Ошибок {_errorEditions.Count}");
						}
					}
				}
				catch
				{
					var retingJournal = context.RetingJournals.ToList().FirstOrDefault(f => edition.Any(x => x.IdEdt == f.IdEdt));
					if (retingJournal is null)
					{
						_errorEditions.Add(new ErrorEdition()
						{
							Name = edition.First().NameEdt,
							Issn = edition.First().Issn
						});
					}
				}

			}

			_isUpdateStart = false;
			StateHasChanged();
		}

		private async Task UpdateByJson(string json, string issn, ErrorEdition errorEdition)
		{
			try
			{
				var impactFactors = JsonSerializer.Deserialize<Dictionary<int, decimal>>(json);
				await using var context = await _dbContextFactory.CreateDbContextAsync();
				var editions = context.Editions.Where(x => x.Issn == issn).AsNoTracking().ToList();
				foreach (var edition in editions)
				{
					await _impactFactorService.UpdateImpactFactorAsync(edition.IdEdt, impactFactors);
				}
				errorEdition.IsUpdated = true;
			}
			catch
			{
				errorEdition.IsUpdated = false;
			}
		}

		private async void SetProgress(double progressStep, string message)
		{
			_progressMessage = message;
			_progress += progressStep;
			await InvokeAsync(StateHasChanged);
		}

		private bool CheckDisable() => _isUpdateStart || _isFindStart;
	}
}
