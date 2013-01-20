using System;
using HtmlAgilityPack;

namespace NicoMonoLibrary
{
	public interface INicorepoItem
	{
		string ClassName
		{
			get;
		}

		void Parser(HtmlNode node);
	}
}

