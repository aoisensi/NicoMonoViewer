using System;
using HtmlAgilityPack;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace NicoMonoLibrary
{
	public class FormAction
	{
		public static Stream Post (HtmlNode formNode)
		{
			string data = "";
			string url = formNode.Attributes["action"].Value;
			foreach(HtmlNode inputNode in formNode.SelectNodes(".//input[@type='text' or @type='hidden']"))
			{
				string name = inputNode.Attributes["name"].Value;
				string value = inputNode.Attributes["value"].Value;
				data += String.Format("{0}={1}&",name,value);
			}

			byte[] datab = Encoding.UTF8.GetBytes(data);
			WebRequest req = WebRequest.Create(url);
			req.Method = "POST";
			req.ContentType = "application/x-www-form-urlencoded";
			req.ContentLength = datab.Length;
			
			Stream st = req.GetRequestStream();
			st.Write(datab,0,data.Length);
			st.Close();
			WebResponse res = req.GetResponse();
			DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Json.NicoruResponse));
			return res.GetResponseStream();
		}
	}
}

