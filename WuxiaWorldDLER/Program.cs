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
            const int chapterOffset = 2;

            for (int chapter = 450; chapter <= 453; chapter++)
            {
                ChapterLoader chapterLoader = new ChapterLoader(chapter);
                string body = chapterLoader.GetChapterBody();
                ChapterXHTMLCreator htmlCreator = new ChapterXHTMLCreator("Tales of Demons and Gods", chapter, body);
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"xhtml/section-0{chapter + chapterOffset}.xhtml");
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                htmlCreator.SaveChapter(path);
            }
        }
    }
}
