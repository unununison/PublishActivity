using System;
using System.Collections.Generic;

namespace Reports.Data;

/// <summary>
/// Импакт-фактор
/// </summary>
public sealed class ImpactFactor
{
	private const string URI_FORMAT = "https://www.scimagojr.com/journalsearch.php?q={0}";
	
	/// <summary>
	/// Issn журнала
	/// </summary>
	public string Issn { get; set; }

	/// <summary>
	/// Название журнала
	/// </summary>
	public string EditionName { get; set; }

	/// <summary>
	/// значения импакт-фактора
	/// </summary>
	public Dictionary<int, decimal> Values { get; set; }

	/// <summary>
	/// Ссылка на scimagojr
	/// </summary>
	public string HtmlLink => string.Format(URI_FORMAT, Issn);

	public ImpactFactor()
	{
		Issn = string.Empty;
		Values = new();
	}
}
