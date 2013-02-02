using System;
using HtmlAgilityPack;

namespace NicoMonoLibrary
{
	public class NicorepoItem
	{
		public static INicorepoItem CreateInstance (HtmlNode node)
		{
			string[] className = node.Attributes ["class"].Value.Split (' ');
			if(Array.IndexOf(className,"log-community-live-broadcast")){
				return new NicorepoItemCommunityLiveBroadcast().Parser(node);
			}else{
				return new NicorepoItemUnknow().Parser(node);
			}
		}
	}
}

