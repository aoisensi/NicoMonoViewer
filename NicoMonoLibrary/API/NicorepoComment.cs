using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace NicoMonoLibrary
{
	public class NicorepoComment
	{
		NicorepoItemSubComment _comment;
		public NicorepoComment (NicorepoItemSubComment comment)
		{
			_comment = comment;
		}

		public Json.NicorepoResResponse Post(string text)
		{
			HtmlNode FormNode = _comment.Node.LastChild;
			FormNode.SelectSingleNode("//form[@name='message']").Attributes["value"].Value = text;
			DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Json.NicoruResponse));
			Stream resst = FormAction.Post(_comment.Node.LastChild);
			return (Json.NicorepoResResponse)ser.ReadObject(resst);
		}
	}
}

