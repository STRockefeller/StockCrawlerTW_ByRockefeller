using System;
using System.Threading.Tasks;
using StockCrawlerTW_ByRockefeller;

namespace TestConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CrawlerAction.BasicInfoCrawlerAsync("0050");
            await CrawlerAction.BasicInfoCrawlerAsync("0056");
            await CrawlerAction.BasicInfoCrawlerAsync("2330");
            await CrawlerAction.BasicInfoCrawlerAsync("2338");
        }
    }
}
