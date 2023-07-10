namespace PublishActivity.Data
{
	/// <summary>
	/// Реферативная база данных
	/// </summary>
	public enum AbstractBase
	{
		/// <summary>
		/// Scopus
		/// </summary>
		[AbstractBaseName("Scopus")]
		Scopus,

		/// <summary>
		/// Web of Science
		/// </summary>
		[AbstractBaseName("Web of Science")]
		WebOfScience,

		/// <summary>
		/// ELibrary
		/// </summary>
		[AbstractBaseName("ELibrary")]
		ELibrary,

		/// <summary>
		/// Все базы данных
		/// </summary>
		[AbstractBaseName("Все реферативные базы данных")]
		All
	}
}
