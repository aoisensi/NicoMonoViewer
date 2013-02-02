using System;
using HtmlAgilityPack;

namespace NicoMonoLibrary
{
	public class NicorepoItem
	{
		public static INicorepoItem CreateInstance (HtmlNode node)
		{
			string[] className = node.Attributes ["class"].Value.Split (' ');
			INicorepoItem item;
			if(Array.IndexOf(className,"log-community-live-broadcast") != -1){
				item = new NicorepoItemCommunityLiveBroadcast();
			}else{
				item = new NicorepoItemUnknow();
			}
			item.Parser(node);
			return item;
		}
	}
}

