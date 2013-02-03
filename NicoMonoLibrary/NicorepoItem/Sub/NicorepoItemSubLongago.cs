using System;
using HtmlAgilityPack;

namespace NicoMonoLibrary
{
	class NicorepoItemSubLongago
	{
		HtmlNode _node;
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

