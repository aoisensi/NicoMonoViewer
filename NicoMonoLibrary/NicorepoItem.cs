using System;
using System.Xml;
using System.Xml.XPath;

namespace NicoMonoLibrary
{
	public class NicorepoItem
	{
		static INicorepoItem[] _nicorepoItem;
		static INicorepoItem _nicorepoItemUnknow;

		static NicorepoItem ()
		{
			_nicorepoItem = new INicorepoItem[]{
				new NicorepoItemCommunityLiveBroadcast()
			};
			_nicorepoItemUnknow = new NicorepoItemUnknow();
		}

		public static INicorepoItem CreateInstance (XmlNode node)
		{
			string[] className = node.Attributes["class"].Value.Split(' ');
			string type = className[className.Length - 1];
			foreach (INicorepoItem item in _nicorepoItem) {
				if(type == item.ClassName){
					item.Parser(node);
					return item;
				}
			}
			_nicorepoItemUnknow.Parser(node);
			return _nicorepoItemUnknow;
		}
	}
}

