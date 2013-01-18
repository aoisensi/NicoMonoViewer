using System;
using System.Collections.Generic;
using System.Text;

namespace CookieGetterMono
{
	/// <summary>
	/// CookieGetterを生成するためのインターフェース
	/// </summary>
	interface IBrowserManager
	{
		/// <summary>
		/// ブラウザの種類
		/// </summary>
		BrowserType BrowserType { get; }

		/// <summary>
		/// 既定のCookieGetterを取得します
		/// </summary>
		/// <returns></returns>
		ICookieGetter CreateDefaultCookieGetter();

		/// <summary>
		/// 利用可能なすべてのCookieGetterを取得します
		/// </summary>
		/// <returns></returns>
		ICookieGetter[] CreateCookieGetters();

		/// <summary>
		/// 現在のOSで利用可能か判断します
		/// </summary>
		/// <returns></returns>
		/// メソッド名思いつかない誰か変えてくれ
		bool IsAbleOS();
		
	}
}
