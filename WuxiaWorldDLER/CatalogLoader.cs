using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;

namespace WuxiaWorldDLER
{
    public class CatalogLoader
    {
        private String baseUrl = "http://www.wuxiaworld.com/";
        private HtmlDocument catalogDocument;

        public CatalogLoader()
        {
            HtmlWeb web = new HtmlWeb();
            catalogDocument = web.Load(baseUrl);
        }
        
        public List<Series> GetCatalog()
        {
            List<Series> allSeries = new List<Series>();

            // Load Chinese Series
            allSeries.AddRange(LoadSeries("menu-item-2165", false));
            // Load Completed Series
            allSeries.AddRange(LoadSeries("menu-item-12207", true));

            return allSeries;

        }

        private List<Series> LoadSeries(String id, Boolean isComplete)
        {
            List<Series> seriesToLoad = new List<Series>();
            HtmlNodeCollection seriesAnchors = catalogDocument.DocumentNode.SelectNodes($"//li[@id='{id}']/ul/li/a");

            foreach (HtmlNode seriesAnchor in seriesAnchors)
            {
                seriesToLoad.Add(new Series(seriesAnchor.InnerText, seriesAnchor.GetAttributeValue("href", ""), isComplete));
            }

            return seriesToLoad;
        }
    }
}
