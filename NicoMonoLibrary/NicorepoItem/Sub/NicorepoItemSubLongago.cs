using System;
using HtmlAgilityPack;

namespace NicoMonoLibrary
{
	class NicorepoItemSubLongago
	{
		HtmlNode _node;
		bool _nicoried = false;
		public NicorepoItemSubLongago(HtmlNode node)
		{
			_node = node;
		}
		
		public DateTime Longago()
		{
			string uct = _node.SelectSingleNode(".//time[@class='relative']").Attributes["datetime"].Value;
			return DateTime.Parse(uct);
		}
	}
}

