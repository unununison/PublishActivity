using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System.IO;
using System.Text;

namespace PublishActivity.API.Services
{
	public class ImpactFactorService
	{

		private const string SCIMAGO_LINK = "https://www.scimagojr.com/";
		private const string JOURNAL_SEARCH = "journalsearch.php";
		private const string SCIMAGO_URI = SCIMAGO_LINK + JOURNAL_SEARCH + "?q=";
		private const string SCRIPT_SELECTOR = "script";
		private const string TAG_A_SELECTOR = "a";
		private const string HREF_ATTRIBUTE_NAME = "href";
		private const string SCRIPT_TYPE = "text/javascript";
		private const string IMPACT_FACTOR_SUBSTRING_START = "var datasjr = ";
		private const string IMPACT_FACTOR_SUBSTRING_END = "var dssjr=new viz.Dataset";
		private const string IMPACT_FACTOR_VARIABLE = "datasjr";
		private const string SJR_SEPARATOR = ";";
		private const string OLD_REPLACE = ".";
		private const string NEW_REPLACE = ",";


		#region Private methods

		private static async Task<IHtmlDocument?> GetHtmlDocument(string url)
		{
			try
			{
				using var httpClient = new HttpClient();
				var httpStream = await httpClient.GetStringAsync(url);
				var htmlParser = new HtmlParser();

				return await htmlParser.ParseDocumentAsync(httpStream);
			}
			catch
			{
				return null;
			}
		}

		private static async Task<IHtmlDocument?> GetHtmlDocumentOld(string url)
		{
			try
			{
				using var httpClient = new HttpClient();
				using var httpStream = await httpClient.GetStreamAsync(url);
				var htmlParser = new HtmlParser();

				return await htmlParser.ParseDocumentAsync(httpStream);
			}
			catch
			{
				return null;
			}
		}
		#endregion

		/// <inheritdoc/>
		public async Task<Dictionary<int, decimal>?> FindAsyncOld(string issn)
		{
			var downloadString = string.Concat(SCIMAGO_URI, issn);

			try
			{
				var html = await GetHtmlDocumentOld(downloadString);

				if (html is null)
				{
					return null;
				}

				var journalRef = html
					.QuerySelectorAll(TAG_A_SELECTOR)
					.Single(x => x.GetAttribute(HREF_ATTRIBUTE_NAME)?.Contains(JOURNAL_SEARCH) ?? false).GetAttribute(HREF_ATTRIBUTE_NAME);

				/*html = await GetHtmlDocumentOld(SCIMAGO_LINK + journalRef);

				if (html is null)
				{
					return null;
				}*/

				/*var script = html
					.QuerySelectorAll(SCRIPT_SELECTOR)
					.Single(x => ((IHtmlScriptElement)x).Type == SCRIPT_TYPE && x.InnerHtml.Contains(IMPACT_FACTOR_VARIABLE))
					.OuterHtml;*/

				using var httpClient = new HttpClient();
				using var httpStream = await httpClient.GetStreamAsync(SCIMAGO_LINK + journalRef);

				using var streamReader = new StreamReader(httpStream);
				var script = streamReader.ReadToEnd();
				var start = script.IndexOf(IMPACT_FACTOR_SUBSTRING_START);
				var end = script.IndexOf(IMPACT_FACTOR_SUBSTRING_END);

				var impactFactorValues = script
					.Substring(start + IMPACT_FACTOR_SUBSTRING_START.Length, end - start - IMPACT_FACTOR_SUBSTRING_END.Length - 1)
					.Split("\\n")
					.Skip(1);

				var result = new Dictionary<int, decimal>();

				foreach (var impactFactorValue in impactFactorValues)
				{
					var yearAndValue = impactFactorValue.Split(SJR_SEPARATOR);
					var year = Convert.ToInt32(yearAndValue[0]);
					var value = Convert.ToDecimal(yearAndValue[1].Replace(OLD_REPLACE, NEW_REPLACE));

					result.Add(year, value);
				}

				return result;
			}
			catch
			{
				return null;
			}
		}

		/// <inheritdoc/>
		public async Task<Dictionary<int, decimal>?> FindAsync(string issn)
		{
			var downloadString = string.Concat(SCIMAGO_URI, issn);

			try
			{
				var html = await GetHtmlDocument(downloadString);

				if (html is null)
				{
					return null;
				}

				var journalRef = html
					.QuerySelectorAll(TAG_A_SELECTOR)
					.Single(x => x.GetAttribute(HREF_ATTRIBUTE_NAME)?.Contains(JOURNAL_SEARCH) ?? false).GetAttribute(HREF_ATTRIBUTE_NAME);

				html = await GetHtmlDocument(SCIMAGO_LINK + journalRef);

				if (html is null)
				{
					return null;
				}

				var script = html
					.QuerySelectorAll(SCRIPT_SELECTOR)
					.Single(x => ((IHtmlScriptElement)x).Type == SCRIPT_TYPE && x.InnerHtml.Contains(IMPACT_FACTOR_VARIABLE))
					.OuterHtml;

				var start = script.IndexOf(IMPACT_FACTOR_SUBSTRING_START);
				var end = script.IndexOf(IMPACT_FACTOR_SUBSTRING_END);

				var impactFactorValues = script
					.Substring(start + IMPACT_FACTOR_SUBSTRING_START.Length, end - start - IMPACT_FACTOR_SUBSTRING_END.Length - 1)
					.Split("\\n")
					.Skip(1);

				var result = new Dictionary<int, decimal>();

				foreach (var impactFactorValue in impactFactorValues)
				{
					var yearAndValue = impactFactorValue.Split(SJR_SEPARATOR);
					var year = Convert.ToInt32(yearAndValue[0]);
					var value = Convert.ToDecimal(yearAndValue[1].Replace(OLD_REPLACE, NEW_REPLACE));

					result.Add(year, value);
				}

				return result;
			}
			catch
			{
				return null;
			}
		}
	}
}
