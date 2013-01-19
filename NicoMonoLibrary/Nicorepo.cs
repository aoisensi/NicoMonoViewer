using System;
using System.Net;
using System.IO;
using System.Text;

namespace NicoMonoLibrary
{
	public class Nicorepo
	{
		static Encoding encoder = Encoding.GetEncoding("UTF-8");
		User _user;
		public string result;
		public Nicorepo (User user)
		{
			_user = user;
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://www.nicovideo.jp/api/my/tlget?is_mypage=1");
			req.CookieContainer = user.cc;

			WebResponse res = req.GetResponse();

			Stream resStream = res.GetResponseStream();
			StreamReader sr = new StreamReader(resStream, encoder);
			result = sr.ReadToEnd();
			sr.Close();
			resStream.Close();
		}
	}
}

