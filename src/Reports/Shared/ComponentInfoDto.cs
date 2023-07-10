namespace Reports.Shared
{
	/// <summary>
	/// Модель данных информации о компоненте
	/// </summary>
	public class ComponentInfoDto
	{
		/// <summary>
		/// Иконка компонента
		/// </summary>
		public string Icon { get; set; }

		/// <summary>
		/// Наименование компонента
		/// </summary>
		public string Title { get; set; } 

		/// <summary>
		/// Описание компонента
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Ссылка на страницу компонента
		/// </summary>
		public string PageURL { get; set; }
	}
}
