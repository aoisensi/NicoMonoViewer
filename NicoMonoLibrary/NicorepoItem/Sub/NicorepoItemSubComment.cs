using System;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace NicoMonoLibrary
{
	public class NicorepoItemSubComment
	{
		HtmlNode _node;


		List<NicorepoItemSubCommentItem> _items = new List<NicorepoItemSubCommentItem>();
		public NicorepoItemSubComment (HtmlNode node)
		{
			_node = node;
			HtmlNode items = _node.SelectSingleNode("div[@class='log-content']/div[@class='log-reslist']");
			foreach (HtmlNode item in items.ChildNodes)
			{
				try{
					var append = new NicorepoItemSubCommentItem(item);
					append.Parser();
					_items.Add(append);
				}catch{
					continue;
				}
			}
		}

		public HtmlNode Node {
			get {
				return _node;
			}
		}
	}
}

