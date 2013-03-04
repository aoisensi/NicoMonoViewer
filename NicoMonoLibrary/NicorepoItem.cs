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
			if (Array.IndexOf (className, "log-community-live-broadcast") != -1) {
				item = new NicorepoItemCommunityLiveBroadcast ();
			} else if (Array.IndexOf (className, "log-community-live-reserve") != -1) {
				item = new NicorepoItemCommunityLiveReserve ();
			} else if (Array.IndexOf (className, "log-user-action-stamp") != -1) {
				item = new NicorepoItemUserActionStamp();
			} else {
				item = new NicorepoItemUnknow ();
			}
			item.Parser(node);
			return item;
		}
	}
}

