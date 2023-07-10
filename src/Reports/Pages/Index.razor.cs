using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Reports.Shared;

namespace Reports.Pages
{
	public partial class Index : ComponentBase
	{
		private List<ComponentInfoDto>? componentsInfo;

		protected override async Task OnInitializedAsync()
		{
			if (componentsInfo is null)
			{
				var componentsInfoFileData = File.ReadAllText("components.json");

				componentsInfo = JsonSerializer
					.Deserialize<List<ComponentInfoDto>>(componentsInfoFileData);
			}

			await base.OnInitializedAsync();
		}
	}
}
