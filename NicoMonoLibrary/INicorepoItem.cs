using System;
using System.Xml;
using System.Xml.XPath;

namespace NicoMonoLibrary
{
	public interface INicorepoItem
	{
		string ClassName
		{
			get;
		}

		void Parser(XmlNode node);
	}
}

