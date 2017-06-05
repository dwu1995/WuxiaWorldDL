using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WuxiaWorldDLER
{
    public class ChapterXHTMLCreator
    {
        private string book { get; set; }
        private int chapter { get; set; }
        private string body { get; set; }

        public ChapterXHTMLCreator(string book, int chapter, string body)
        {
            this.book = book;
            this.chapter = chapter;
            this.body = body;

        }

        public void SaveChapter(string path)
        {

            HtmlDocument chapterHtml = new HtmlDocument();
            HtmlNode chapterDocument = HtmlNode.CreateNode("<html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"en\"></html>");
            HtmlNode.ElementsFlags["meta"] = HtmlElementFlag.Closed;
            HtmlNode.ElementsFlags["link"] = HtmlElementFlag.Closed;

            chapterDocument.AppendChild(CreateHeader());
            chapterDocument.AppendChild(CreateBody());

            chapterHtml.OptionAutoCloseOnEnd = true;
            chapterHtml.DocumentNode.AppendChild(chapterDocument);

            chapterHtml.Save(path, Encoding.UTF8);
        }

        private HtmlNode CreateBody()
        {
            HtmlNode bodyNode = HtmlNode.CreateNode($@"<body class=""calibre""> 
                {body}
                </body>");

            return bodyNode;
        }

        private HtmlNode CreateHeader()
        {
            HtmlNode header = HtmlNode.CreateNode($@"<head></head>");
            HtmlNode title = HtmlNode.CreateNode($"<title>{book} - Ch.{chapter}</title>");
            HtmlNode meta = HtmlNode.CreateNode(@"<meta http-equiv=""Content-Type"" content=""text/html"" charset=""utf-8""/>");
            HtmlNode styleSheet = HtmlNode.CreateNode(@"<link href=""../stylesheet.css"" rel=""stylesheet"" type=""text/css""/>");
            HtmlNode pageStyle = HtmlNode.CreateNode(@"<link href=""../page_styles.css"" rel=""stylesheet"" type=""text/css""/>");

            header.AppendChild(title);
            header.AppendChild(meta);
            header.AppendChild(styleSheet);
            header.AppendChild(pageStyle);

            return header;
        }
    }
}
