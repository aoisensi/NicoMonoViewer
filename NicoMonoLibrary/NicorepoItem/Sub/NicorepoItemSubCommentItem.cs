using System;
using HtmlAgilityPack;

namespace NicoMonoLibrary
{
	public class NicorepoItemSubCommentItem
	{
		HtmlNode _node;
		string _userThumbnailUrl;
		string _userName;
		string _userUrl;
		public NicorepoItemSubCommentItem (HtmlNode node)
		{
			_node = node;
		}

		public void Parser()
		{

		}
	}
}

