using System;
using HtmlAgilityPack;
using System.Globalization;

namespace NicoMonoLibrary
{
	public class NicorepoItemCommunityLiveReserve : NicorepoItemCommunityLiveBroadcast
	{
		const string className = "log-community-live-reserve";
		
		DateTime broadcastTime;

		public NicorepoItemCommunityLiveReserve() : base()
		{

		}

		public override void Parser (HtmlNode node)
		{
			base.Parser (node);
			string time = node.SelectSingleNode("div[@class='log-content']/div[@class='log-body']").LastChild.OuterHtml;
			broadcastTime = DateTime.ParseExact(time,"さんがyy年MM月dd日hh:mmに生放送を予約しました。",null,DateTimeStyles.AllowWhiteSpaces);
		}

		public DateTime BroadcastTime{
			get {
				return broadcastTime;
			}
		}

	}
}

