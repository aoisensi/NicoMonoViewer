using System;
using HtmlAgilityPack;

namespace NicoMonoLibrary
{
	public class NicorepoItem
	{
		static INicorepoItem[] _nicorepoItem;
		static INicorepoItem _nicorepoItemUnknow;

		static NicorepoItem ()
		{
			_nicorepoItem = new INicorepoItem[]{
				new NicorepoItemCommunityLiveBroadcast()
			};
			_nicorepoItemUnknow = new NicorepoItemUnknow();
		}

		public static INicorepoItem CreateInstance (HtmlNode node)
		{
			string[] className = node.Attributes["class"].Value.Split(' ');
			string type = className[className.Length - 1];
			foreach (INicorepoItem item in _nicorepoItem) {
				if(type == item.ClassName){
					item.Parser(node);
					return item;
				}
			}
			_nicorepoItemUnknow.Parser(node);
			return _nicorepoItemUnknow;
		}
	}
}

