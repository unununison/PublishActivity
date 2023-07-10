using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Reports.Shared
{
	public partial class MainLayout : LayoutComponentBase
	{
		private List<ComponentInfoDto>? componentsInfo;

		/// <summary>
		/// Обработчик события завершения инициализации компонента
		/// </summary>
		protected override async Task OnInitializedAsync()
		{
			if (componentsInfo is null)
			{
				var componentsInfoFileData = File.ReadAllText("components.json");

				componentsInfo = JsonSerializer.Deserialize<List<ComponentInfoDto>>(componentsInfoFileData);
			}

			await base.OnInitializedAsync();
		}
	}
}
