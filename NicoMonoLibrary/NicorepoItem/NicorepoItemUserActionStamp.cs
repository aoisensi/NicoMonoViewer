using System;
using HtmlAgilityPack;

namespace NicoMonoLibrary
{
	public class NicorepoItemUserActionStamp : INicorepoItem
	{
		public string ClassName { get { return className;	} }
		
		const string className = "log-user-action-stamp";

		string userURL;
		string userName;
		string stampName;
		string stampURL;
		string stampImageURL;
		NicorepoItemSubLongago longago;
		NicorepoItemSubNicoru nicoru;

		public virtual void Parser(HtmlNode node){
			userURL = node.SelectSingleNode("div[@class='log-content']/div[@class='log-body']/a[last()]").Attributes["href"].Value;
			userName = node.SelectSingleNode("div[@class='log-content']/div[@class='log-body']/a[last()]").InnerText;
			stampName = node.SelectSingleNode("div[@class='log-content']/div[@class='log-details log-target log-target-stamp']/div[@class='log-target-info']/a").InnerText;
			stampURL = node.SelectSingleNode("div[@class='log-content']/div[@class='log-details log-target log-target-stamp']/div[@class='log-target-info']/a").Attributes["href"].Value;
			stampImageURL = node.SelectSingleNode("div[@class='log-content']/div[@class='log-details log-target log-target-stamp']/div[@class='log-target-thumbnail']/a/img").Attributes["data-src"].Value;
			longago = new NicorepoItemSubLongago(node);
			nicoru = new NicorepoItemSubNicoru(node);
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

		public string StampName {
			get {
				return stampName;
			}
		}

		public string StampURL {
			get {
				return stampURL;
			}
		}

		public string StampImageURL {
			get {
				return stampImageURL;
			}
		}

		public DateTime Longago {
			get {
				return longago.Longago();
			}
		}

		public Nicoru Nicoru {
			get {
				return new Nicoru(String.Format("9:{0}", nicoru.Nicoru));
			}
		}
	}
}

