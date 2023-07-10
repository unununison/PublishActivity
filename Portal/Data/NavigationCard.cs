namespace Portal.Data
{
	/// <summary>
	/// Структура для карточек перехода на сервисы
	/// </summary>
	public struct NavigationCard
	{
		/// <summary>
		/// Имя сервиса
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Иконка
		/// </summary>
		public string Icon { get; set; }

		/// <summary>
		/// Ссылка на сервис
		/// </summary>
		public string Link { get; set; }

		/// <summary>
		/// Флаг деактивации ссылки
		/// </summary>
		public bool IsDisabled { get; set; }
	}
}