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
		User _user;
		public List<string> htmls = new List<string>();
		public List<NicorepoItem> items = new List<NicorepoItem>();
		string nexturl = "http://www.nicovideo.jp/api/my/tlget?is_mypage=1";
		public Nicorepo (User user)
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
			//パーサ

				//"ul[@id='SYS_THREADS' and @class='myContList nicorepo']/li"



		}

		public void HtmlParser (string html)
		{

			HtmlDocument doc = new HtmlDocument ();

			doc.LoadHtml (html);

			HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes ("/ul[@id='SYS_THREADS' and @class='myContList nicorepo']/li");
			foreach (HtmlNode node in nodes) {
				items.Add(new NicorepoItem(node));

			}
		}
	}
}

