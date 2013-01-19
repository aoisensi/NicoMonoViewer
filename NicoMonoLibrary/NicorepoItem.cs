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
		public NicorepoItem (string linode)
		{
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(linode);
			try{
				HtmlNode tre = doc.DocumentNode.SelectSingleNode("/li/div[@class='userThumb friend']");
				isFriend = doc.DocumentNode.SelectSingleNode("/li/div[@class='userThumb friend']") != null;
			}catch(System.NullReferenceException e){
				isFriend = false;
			}
			try{
				HtmlNode tre = doc.DocumentNode.SelectSingleNode("/li/div[@class='userThumb']");
				isUserThumb = doc.DocumentNode.SelectSingleNode("/li/div[@class='userThumb']") != null;
			}catch(System.NullReferenceException e){
				isUserThumb = false;
			}
			try{
				isRepThumb = doc.DocumentNode.SelectSingleNode("/li/div[@class='repThumb']/") != null;
			}catch(System.NullReferenceException e){
				isRepThumb = false;
			}
		}
	}

	public enum NicorepoItemType{
		Nothing,
		ComLiveStart,
		Other
	}
}

