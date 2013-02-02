using System;
using HtmlAgilityPack;

namespace NicoMonoLibrary
{
	public class NicorepoItem
	{
		public static INicorepoItem CreateInstance (HtmlNode node)
		{
			string[] className = node.Attributes ["class"].Value.Split (' ');
			string type = className [className.Length - 1];
			INicorepoItem item;
			switch (type) {
			case "log-community-live-broadcast":
				item = new NicorepoItemCommunityLiveBroadcast();
				break;
			default:
				item = new NicorepoItemUnknow();
				break;
			}
			item.Parser(node);
			return item;
		}
	}
}

