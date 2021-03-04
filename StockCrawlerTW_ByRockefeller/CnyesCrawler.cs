using System;
using System.Text;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.Linq;

namespace StockCrawlerTW_ByRockefeller
{
    internal class CnyesCrawler
    {
        internal static async Task BasicInfoCrawlerAsync(string id)
        {
            string url = "https://invest.cnyes.com/twstock/TWS/" + id;
            HtmlWeb webClient = new HtmlWeb();
            webClient.OverrideEncoding = Encoding.UTF8;
            HtmlAgilityPack.HtmlDocument htmlDocument = webClient.Load(url);
            Stock stock = new Stock();
            stock.codeName = id;
            stock.stockId = htmlDocument.DocumentNode.Descendants("h1").
                Where(node => node.GetAttributeValue("class", "").Equals("jsx-586595940")).FirstOrDefault().
                Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("main_subTitle")).
                FirstOrDefault().InnerText;
            HtmlNode profileData = htmlDocument.DocumentNode.Descendants("div").
                Where(node => node.GetAttributeValue("class", "").Contains("profile-data")).FirstOrDefault();
            stock.tradingVolume = profileData.Descendants("div").
                Where(node => node.GetAttributeValue("class", "").Contains("data-block--wider")).FirstOrDefault().
                Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("block-value")).
                FirstOrDefault().InnerText;
            stock.maxPrice = profileData.Descendants("div").
                Where(node => node.GetAttributeValue("class", "").Contains("data-block")).Skip(1).FirstOrDefault().
                Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("block-value")).
                FirstOrDefault().InnerText.Split(' ').LastOrDefault();
            stock.minPrice = profileData.Descendants("div").
                Where(node => node.GetAttributeValue("class", "").Contains("data-block")).Skip(1).FirstOrDefault().
                Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("block-value")).
                FirstOrDefault().InnerText.Split(' ').FirstOrDefault();
            stock.openingPrice = profileData.Descendants("div").
                Where(node => node.GetAttributeValue("class", "").Contains("data-block")).Skip(4).FirstOrDefault().
                Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("block-value")).
                FirstOrDefault().InnerText;
            stock.closingPrice = profileData.Descendants("div").
                Where(node => node.GetAttributeValue("class", "").Contains("data-block")).Skip(5).FirstOrDefault().
                Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("block-value")).
                FirstOrDefault().InnerText;
            stock.PERatio = profileData.Descendants("div").
                Where(node => node.GetAttributeValue("class", "").Contains("data-block")).Skip(6).FirstOrDefault().
                Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("block-value")).
                FirstOrDefault().InnerText;
            stock.marketValue = profileData.Descendants("div").
                Where(node => node.GetAttributeValue("class", "").Contains("data-block")).LastOrDefault().
                Descendants("div").Where(node => node.GetAttributeValue("class", "").Contains("block-value")).
                FirstOrDefault().InnerText;
            stock.tradingMoney = htmlDocument.DocumentNode.Descendants("div").
                Where(node => node.GetAttributeValue("class", "").Contains("info-lp")).FirstOrDefault().
                Descendants("span").FirstOrDefault().InnerText;
            stock.tradingDate = DateTime.Now;
            stock.id = DbAction.getId();
            DbAction.addStock(stock);
        }
    }
}
