using System;
using HtmlAgilityPack;

namespace NicoMonoLibrary
{
	public class NicorepoItem
	{
		bool hasFriend = false;
		bool hasUserThumb = false;
		bool hasRepThumb = false;
		NicorepoItemType type;
		public NicorepoItem (HtmlNode node)
		{
			HtmlNode n1;
			n1 = node.SelectSingleNode ("div[@class='userThumb friend']");
			if (n1 != null) {
				hasFriend = true;
			}

			n1 = node.SelectSingleNode ("div[@class='userThumb']");
			if (n1 != null) {
				hasUserThumb = true;
			}

			n1 = node.SelectSingleNode ("div[@class='repThumb']");
			if (n1 != null) {
				hasRepThumb = true;
			}

		}
	}

	public enum NicorepoItemType{
		Nothing,
		ComLiveStart,
		Other
	}
}

