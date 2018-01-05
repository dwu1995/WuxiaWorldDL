using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WuxiaWorldDLER
{
    class Program
    {
        static void Main(string[] args)
        {
            Series seriesToLoad = SelectSeries();
            SeriesLoader seriesLoader = new SeriesLoader(seriesToLoad);
            seriesLoader.SaveSeries();

            //const int chapterOffset = 2;

            //for (int chapter = 450; chapter <= 453; chapter++)
            //{
            //    ChapterLoader chapterLoader = new ChapterLoader(chapter);
            //    string body = chapterLoader.GetChapterBody();
            //    ChapterXHTMLCreator htmlCreator = new ChapterXHTMLCreator("Tales of Demons and Gods", chapter, body);
            //    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"xhtml/section-0{chapter + chapterOffset}.xhtml");
            //    Directory.CreateDirectory(Path.GetDirectoryName(path));
            //    htmlCreator.SaveChapter(path);
            //}
        }

        static Series SelectSeries()
        {
            CatalogLoader catalogLoader = new CatalogLoader();
            List<Series> allSeries = catalogLoader.GetCatalog();


            for (int i = 0; i < allSeries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allSeries[i].Name}");
            }

            Console.WriteLine("Please select a series");
            int selectedIndex = int.Parse(Console.ReadLine()) - 1;

            while (selectedIndex < 0 || selectedIndex >= allSeries.Count)
            {
                Console.WriteLine("Invalid series, please select a valid series");
                selectedIndex = int.Parse(Console.ReadLine()) - 1;
            }

            return allSeries[selectedIndex];
        }
    }
}
