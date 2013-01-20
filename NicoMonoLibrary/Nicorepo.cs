using System;
using System.Net;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;
using HtmlAgilityPack;

namespace NicoMonoLibrary
{
	public class Nicorepo
	{
		static Encoding encoder = Encoding.GetEncoding("UTF-8");
		NicoUser _user;
		public List<string> htmls = new List<string>();
		public List<INicorepoItem> items = new List<INicorepoItem>();
		string nexturl = "http://www.nicovideo.jp/my/top/all?innerPage=1&mode=next_page";
		public Nicorepo (NicoUser user)
		{
			_user = user;
		}
		public void GetNextPage ()
		{
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create (nexturl);
			req.CookieContainer = _user.cc;
			
			WebResponse res = req.GetResponse ();
			
			Stream resStream = res.GetResponseStream ();
			StreamReader sr = new StreamReader (resStream, encoder);
			string html = sr.ReadToEnd ();
			sr.Close ();
			resStream.Close ();
			htmls.Add (html);
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
			nexturl = "http://www.nicovideo.jp" + nicorepoPage.SelectSingleNode("div[@class='next-page']/a[@class='next-page-link']/@href").InnerText;
		}
	}
}

