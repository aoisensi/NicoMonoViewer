using System;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using System.Collections;

namespace NicoMonoLibrary
{
	public class User
	{
		CookieContainer cc;
		string _xml;
		public User (string email, string password)
		{
			string url = "https://secure.nicovideo.jp/secure/login?site=nicolive";
			//ログイン・ページへのアクセスパラメタ
			Hashtable vals = new Hashtable();
			//vals["next_url"] = "recent?tab=common";
			vals["next_url"] = "";
			vals["mail"] = email;
			vals["password"] = password;

			//パラメタを"param1=value1&param2=value2"の形にまとめる
			string param = "";
			foreach (string k in vals.Keys)
			{
				param += String.Format("{0}={1}&", k, vals[k]);
			}
			byte[] data = Encoding.ASCII.GetBytes(param);

			//HTTP POSTリクエストの作成
			cc = new CookieContainer(); //認証用クッキーを格納するコンテナ
			WebRequest wreq = WebRequest.Create(url);
			HttpWebRequest req = (HttpWebRequest)wreq;
			req.Method = "POST";
			req.ContentType = "application/x-www-form-urlencoded";
			req.ContentLength = data.Length;
			req.CookieContainer = cc;

			//POSTを実行
			Stream reqStream = req.GetRequestStream();
			reqStream.Write(data, 0, data.Length);
			reqStream.Close();

			//HTTP GETによるクッキーの取得
			//GET実行
			WebResponse res = req.GetResponse();
			Stream resStream = res.GetResponseStream();

			Encoding encoder = Encoding.GetEncoding("UTF-8");
			StreamReader sr = new StreamReader(resStream, encoder);
			_xml = sr.ReadToEnd();
			sr.Close();
			resStream.Close();

			//Console.WriteLine("○ログインAPIレスポンス取得");
			//Console.WriteLine(xml);//表示
			//Console.WriteLine();

			//XMLファイル保存サンプル
			//StreamWriter sw = new StreamWriter(@"C:hogeNicoLiveOneCommentGetter.log");
			//sw.Write(xml);
			//sw.Close();
		}

		public string xml {
			get {
				return _xml;
			}
		}
	}
}

