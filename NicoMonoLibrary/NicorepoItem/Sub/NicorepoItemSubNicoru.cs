using System;
using HtmlAgilityPack;

namespace NicoMonoLibrary
{
	class NicorepoItemSubNicoru
	{
		string _token;

		public NicorepoItemSubNicoru(HtmlNode node)
		{
			_token = node.SelectSingleNode(".//span").Attributes["data-nicorepo"].Value;
		}

		public string Nicoru {
			get {
				return _token;
			}
		}

	}
}

