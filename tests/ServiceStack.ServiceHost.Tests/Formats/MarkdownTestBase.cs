﻿using System.Collections.Generic;
using ServiceStack.WebHost.EndPoints.Formats;
using ServiceStack.WebHost.EndPoints.Support.Markdown;

namespace ServiceStack.ServiceHost.Tests.Formats
{
	public class MarkdownTestBase
	{
		private const string PageName = "Page";

		public MarkdownFormat Create(string pageTemplate)
		{
			var markdownFormat = new MarkdownFormat();
			markdownFormat.AddPage(
				new MarkdownPage(markdownFormat, "/path/to/tpl", PageName, pageTemplate));
			
			return markdownFormat;
		}

		public string RenderToHtml(string pageTemplate, Dictionary<string, object> scopeArgs)
		{
			var markdown = Create(pageTemplate);
			var html = markdown.RenderDynamicPageHtml(PageName, scopeArgs);
			return html;
		}

		public string RenderToHtml(string pageTemplate, object model)
		{
			var markdown = Create(pageTemplate);
			var html = markdown.RenderDynamicPageHtml(PageName, model);
			return html;
		}
	}

	public static class MarkdownTestExtensions
	{
		public static string NormalizeNewLines(this string text)
		{
			return text.Replace("\r\n", "\n");
		}
	}
}