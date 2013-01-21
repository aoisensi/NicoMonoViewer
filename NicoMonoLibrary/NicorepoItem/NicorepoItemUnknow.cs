using System;
using System.Xml;
using System.Xml.XPath;

namespace NicoMonoLibrary
{
	public class NicorepoItemUnknow : INicorepoItem
	{
		public string ClassName { get { return null; } }

		string html;

		public void Parser (XmlNode node)
		{
			html = node.OuterXml;
		}

		public string Html {
			get {
				return html;
			}
		}
	}
}

