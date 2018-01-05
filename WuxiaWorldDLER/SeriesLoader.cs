using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;

namespace WuxiaWorldDLER
{
    public class SeriesLoader
    {
        private Series series;

        public SeriesLoader(Series series)
        {
            this.series = series;
        }

        public void SaveSeries()
        {
            List<String> allChapters = GetAllChapters();
            for (int i = 0; i < allChapters.Count; i++)
            {
                String chapterUrl = allChapters[i];
                ChapterLoader chapterLoader = new ChapterLoader(chapterUrl);
                string body = chapterLoader.GetChapterBody();

                Console.WriteLine(chapterUrl);

                SaveChapter(i + 1, body);
            }
        }

        private void SaveChapter(int chapterNumber, String body)
        {
            ChapterXHTMLCreator htmlCreator = new ChapterXHTMLCreator(series.Name, chapterNumber, body);
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"xhtml/{series.Name}/chap{chapterNumber}.xhtml");
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            htmlCreator.SaveChapter(path);
        }

        private List<String> GetAllChapters()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument seriesDocument = web.Load(series.Url);

            return seriesDocument.DocumentNode.SelectNodes("//div[@itemprop='articleBody']//a").Select(n => n.GetAttributeValue("href", "")).Distinct().ToList();
        }
    }
}
