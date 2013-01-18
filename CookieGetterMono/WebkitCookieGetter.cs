using System;
using System.Collections.Generic;
using System.Text;

namespace CookieGetterMono
{
	class WebkitCookieGetter : CookieGetter
	{		

		public WebkitCookieGetter(CookieStatus status)
			: base(status)
		{ 
		}

		public override System.Net.CookieContainer GetAllCookies()
		{
			if (base.CookiePath == null || !System.IO.File.Exists(base.CookiePath)) {
				throw new CookieGetterException("Webkit�̃N�b�L�[�p�X���������ݒ肳���Ă��܂����B");
			}
			
			try {
				using(System.IO.StreamReader sr = new System.IO.StreamReader(this.Status.CookiePath)){
					while (!sr.EndOfStream) {
						string line = sr.ReadLine();
						if (line.StartsWith("cookies=")) {
							return ParseCookieSettings(line);
						}
					}
				}
			} catch (Exception ex){
				throw new CookieGetterException("Webkit�̃N�b�L�[�擾�ŃG���[���������܂����B", ex);
			}

			throw new CookieGetterException("�w�肳�ꂽ�t�@�C����Webkit�p�̃N�b�L�[���񂪊܂܂��Ă��܂����ł����B");
		}

		private System.Net.CookieContainer ParseCookieSettings(string line)
		{
			System.Net.CookieContainer container = new System.Net.CookieContainer();

			// �N�b�L�[�����̑O�ɂ��Ă����悭�킩���Ȃ��w�b�_�[���������菜��
			// �ΏہF
			// �@\\x�ƂQ���̂P�U�i���l
			// �@\\\\
			// �@\���Ȃ��ꍇ�̐擪�P����
			string matchPattern = "^(\\\\x[0-9a-fA-F]{2})|^(\\\\\\\\)|^(.)|[\"()]";
			System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(matchPattern, System.Text.RegularExpressions.RegexOptions.Compiled);

			string[] blocks = line.Split(new string[] { "\\0\\0\\0" }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string block in blocks) {
				if (block.Contains("=") && block.Contains("domain")) {
					string header = reg.Replace(block, "");
					System.Net.Cookie cookie = ParseCookie(header);
					if (cookie != null) {
						try {
							container.Add(cookie);
						} catch(Exception ex) {
							CookieGetter.Exceptions.Enqueue(ex);
						}
					}
				}
			}

			return container;
		}

		/// <summary>
		/// �N�b�L�[�w�b�_�[���N�b�L�[�ɕϊ�����
		/// </summary>
		/// <param name="header"></param>
		/// <returns></returns>
		private System.Net.Cookie ParseCookie(string header) {
			if (string.IsNullOrEmpty(header)) {
				throw new ArgumentException("header");
			}
			System.Net.Cookie cookie = new System.Net.Cookie();
			bool isCookieHeader = false;

			foreach (string segment in header.Split(new string[]{";"}, StringSplitOptions.RemoveEmptyEntries)) {
				KeyValuePair<string, string> kvp = ParseKeyValuePair(segment.Trim());

				if (string.IsNullOrEmpty(kvp.Key)) {
					isCookieHeader = false;
					break;
				}

				switch (kvp.Key) { 
					case "domain":
						cookie.Domain = kvp.Value;
						isCookieHeader = true;
						break;
					case "expires":
						cookie.Expires = DateTime.Parse(kvp.Value);
						break;
					case "path":
						cookie.Path = kvp.Value;
						break;
					default:
						cookie.Name = kvp.Key;
						cookie.Value = kvp.Value;
						if (cookie.Value != null) {
							cookie.Value = Uri.EscapeDataString(cookie.Value);
						}
						break;
				}
			}
			if (isCookieHeader) {
				return cookie;
			} else {
				return null;
			}
		}

		private KeyValuePair<string, string> ParseKeyValuePair(string exp) {
			int eqindex = exp.IndexOf('=');
			if (eqindex != -1) {
				return new KeyValuePair<string, string>(exp.Substring(0, eqindex), exp.Substring(eqindex+1));
			}

			return new KeyValuePair<string, string>();
		}
	}
}
