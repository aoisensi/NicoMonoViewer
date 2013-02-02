using System;
using HtmlAgilityPack;

namespace NicoMonoLibrary
{
	public class NicorepoItemUnknow : INicorepoItem
	{
		public string ClassName { get { return null; } }

		string html;

		public void Parser (HtmlNode node)
		{
			html = node.OuterHtml;
		}

		public string Html {
			get {
				return html;
			}
		}
	}
}

