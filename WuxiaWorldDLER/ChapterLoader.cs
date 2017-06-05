using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;

namespace WuxiaWorldDLER
{
    public class ChapterLoader
    {

        private static string baseUrl = "http://www.wuxiaworld.com/tdg-index/tdg-chapter-{0}/";
        private int chapter;
        public ChapterLoader(int chapter)
        {
            this.chapter = chapter;
        }

        public string GetChapterBody()
        {
            HtmlNode body = GetChapterDocument().DocumentNode.SelectSingleNode("//div[@itemprop='articleBody']");

            if (body == null)
                return "";

            RemoveHrs(body);
            RemoveFirstAndListChild(body);
            RemoveFirstAndListChild(body);

            return body.WriteContentTo();
        }

        private HtmlDocument GetChapterDocument()
        {
            string url = string.Format(baseUrl, chapter);
            HtmlWeb web = new HtmlWeb();
            HtmlDocument chapterDocument = web.Load(url);

            return chapterDocument;
        }

        private void RemoveHrs(HtmlNode node)
        {
            HtmlNodeCollection hrs = node.SelectNodes("hr");

            if (hrs.Count == 0)
                return;

            foreach (HtmlNode hr in hrs)
            {
                hr.Remove();
            }

        }

        private void RemoveFirstAndListChild(HtmlNode node)
        {
            HtmlNode firstChild = node.FirstChild;
            HtmlNode lastChild = node.LastChild;

            firstChild.Remove();
            lastChild.Remove();
        }
    }
}
