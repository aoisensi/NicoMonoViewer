using System;
using HtmlAgilityPack;

namespace NicoMonoLibrary
{
	public class NicorepoItem
	{
		bool isFriend = true;
		bool isUserThumb = true;
		bool isRepThumb = true;
		NicorepoItemType type;
		public NicorepoItem (HtmlNode node)
		{

			isFriend = node.SelectSingleNode("div[@class='userThumb friend']") != null;

			isUserThumb = node.SelectSingleNode("div[@class='userThumb']") != null;

			isRepThumb = node.SelectSingleNode("div[@class='repThumb']/") != null;

		}
	}

	public enum NicorepoItemType{
		Nothing,
		ComLiveStart,
		Other
	}
}

