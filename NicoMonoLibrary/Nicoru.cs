using System;
using System.Net;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using System.Web;

namespace NicoMonoLibrary
{
	public class Nicoru
	{
		string _nicoru;

		public Nicoru (string nicoru)
		{
			_nicoru = nicoru;
		}

		public Json.Nicoru Nicorare(NicoUser user)
		{
			string url = "http://ru-cliapi.nicovideo.jp/1/item/nicorare_count";
			return Post(user,url);
		}

		public void DoNicoru(NicoUser user)
		{
			string url = "http://ru-cliapi.nicovideo.jp/1/item/nicoru";
			Json.Nicoru json = Post(user,url);
			if(json.Error != null){
				throw new Exception(String.Format("ニコるのに失敗しました {0} {1} {2} {3}",json.Status,json.StatusCode,json.Error.Code,json.Error.Description));
			}
		}

		Json.Nicoru Post(NicoUser user,string url){
			string data = String.Format("items={1}&token={0}",user.Token,_nicoru);
			byte[] datab = Encoding.UTF8.GetBytes(data);
			WebRequest req = WebRequest.Create(url);
			req.Method = "POST";
			req.ContentType = "application/x-www-form-urlencoded";
			req.ContentLength = datab.Length;
			
			Stream st = req.GetRequestStream();
			st.Write(datab,0,data.Length);
			st.Close();
			WebResponse res = req.GetResponse();
			DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Json.Nicoru));
			Stream resst = res.GetResponseStream();
			return (Json.Nicoru)ser.ReadObject(resst);
		}
	}
}
