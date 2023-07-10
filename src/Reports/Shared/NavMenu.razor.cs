using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Reports.Shared
{
	public partial class NavMenu : ComponentBase
	{
		/// <summary>
		/// Информация о компонентах
		/// </summary>
		[Parameter]
		public List<ComponentInfoDto>? ComponentsInfo { get; set; }
	}
}
