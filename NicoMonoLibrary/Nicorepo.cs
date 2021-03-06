using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace NicoMonoLibrary
{
	public class Nicorepo
	{
		static Encoding encoder = Encoding.GetEncoding("UTF-8");
		NicoUser _user;
		List<INicorepoItem> items;
		string nexturl = "http://www.nicovideo.jp/my/top/all?innerPage=1&mode=next_page";
		public Nicorepo (NicoUser user)
		{
			items = new List<INicorepoItem>();
			_user = user;
		}
		public void GetNextPage ()
		{
			items.Clear();
			WebRequest wreq = WebRequest.Create(nexturl);
			HttpWebRequest req = (HttpWebRequest)wreq;
			req.CookieContainer = _user.cc;
			
			WebResponse res = req.GetResponse ();
			
			Stream resStream = res.GetResponseStream ();
			StreamReader sr = new StreamReader (resStream, encoder);
			string html = sr.ReadToEnd ();
			sr.Close ();
			resStream.Close ();
			HtmlParser(html);
		}

		public void HtmlParser (string html)
		{

			HtmlDocument doc = new HtmlDocument ();

			doc.LoadHtml (html);
			HtmlNode nicorepoPage = doc.DocumentNode.SelectSingleNode("/div[@class='nicorepo']/div[@class='nicorepo-page']");
			HtmlNodeCollection nodes = nicorepoPage.SelectNodes ("div[@class='timeline']/div");
			foreach (HtmlNode node in nodes) {
				items.Add(NicorepoItem.CreateInstance(node));
			}
			nexturl = "http://www.nicovideo.jp" + nicorepoPage.SelectSingleNode("div[@class='next-page']/a[@class='next-page-link']").Attributes["href"].Value.Replace("&amp;","&");;
		}

		public List<INicorepoItem> Items {
			get {
				return items;
			}
		}
	}
}

