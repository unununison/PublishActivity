namespace PublishActivity.Data
{
	public sealed class AbstractBaseNameAttribute : Attribute
	{
		/// <summary>
		/// Имя реферативной базы данных
		/// </summary>
		public string Name { get; }

		public AbstractBaseNameAttribute(string name)
		{
			Name = name;
		}
	}
}
