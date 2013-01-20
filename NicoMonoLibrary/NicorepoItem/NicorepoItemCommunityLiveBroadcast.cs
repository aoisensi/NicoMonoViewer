using System;
using HtmlAgilityPack;

namespace NicoMonoLibrary
{
	public class NicorepoItemCommunityLiveBroadcast : INicorepoItem
	{
		public string ClassName { get { return "log-community-live-broadcast";	} }

		string communityURL;
		string communityName;
		string communityThumbnailURL;
		string userURL;
		string userName;
		string broadcastURL;
		string broadcastTitle;

		public void Parser (HtmlNode node)
		{
			communityThumbnailURL = node.SelectSingleNode("div[@class='log-author ']/a/img[@class='nicorepo-lazyimage']").Attributes["data-src"].Value;
			communityURL = node.SelectSingleNode("div[@class='log-content']/div[@class='log-body']/a[@class='author-community']").Attributes["href"].Value;
			communityName = node.SelectSingleNode("div[@class='log-content']/div[@class='log-body']/a[@class='author-community']").InnerText;
			userURL = node.SelectSingleNode("div[@class='log-content']/div[@class='log-body']/a[last()]").Attributes["href"].Value;
			userName = node.SelectSingleNode("div[@class='log-content']/div[@class='log-body']/a[last()]").InnerText;
			//なんかうまく行かないのでボツ
			//communityThumbnailURL = node.SelectSingleNode("div[@class='log-content']/div[@class='log-details log-target log-target-live-program']/div[@class='log-target-thumbnail']/a/img[@class='live_program']").Attributes["src"].Value;
			broadcastURL = node.SelectSingleNode("div[@class='log-content']/div[@class='log-details log-target log-target-live-program']/div[@class='log-target-info']/a").Attributes["href"].Value;
			broadcastTitle = node.SelectSingleNode("div[@class='log-content']/div[@class='log-details log-target log-target-live-program']/div[@class='log-target-info']/a").InnerText;
		}

		public string CommunityURL {
			get {
				return communityURL;
			}
		}

		public string CommunityName {
			get {
				return communityName;
			}
		}

		public string CommunityThumbnailURL {
			get {
				return communityThumbnailURL;
			}
		}

		public string UserURL {
			get {
				return userURL;
			}
		}

		public string UserName {
			get {
				return userName;
			}
		}

		public string BroadcastURL {
			get {
				return broadcastURL;
			}
		}

		public string BroadcastTitle {
			get {
				return broadcastTitle;
			}
		}
	}
}

