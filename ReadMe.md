# 台股即時資訊爬蟲DLL

## 儲存資訊

### Stock類別

```C#
    public class Stock
    {
        /// <summary>
        /// 資料識別號碼
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 證券代號
        /// </summary>
        public string codeName { get; set; }
        /// <summary>
        /// 證券名稱
        /// </summary>
        public string stockId { get; set; }
        /// <summary>
        /// 交易量
        /// </summary>
        public string tradingVolume { get; set; }
        /// <summary>
        /// 成交金額
        /// </summary>
        public string tradingMoney { get; set; }
        /// <summary>
        /// 開盤價
        /// </summary>
        public string openingPrice { get; set; }
        /// <summary>
        /// 收盤價
        /// </summary>
        public string closingPrice { get; set; }
        /// <summary>
        /// 最高價
        /// </summary>
        public string maxPrice { get; set; }
        /// <summary>
        /// 最低價
        /// </summary>
        public string minPrice { get; set; }
        /// <summary>
        /// 價差
        /// </summary>
        public string spread { get; set; }
        /// <summary>
        /// 交易額
        /// </summary>
        public string tradingTurnover { get; set; }
        /// <summary>
        /// 本益比
        /// </summary>
        public string PERatio { get; set; }
        /// <summary>
        /// 市值
        /// </summary>
        public string marketValue { get; set; }
        /// <summary>
        /// 交易日
        /// </summary>
        public DateTime tradingDate { get; set; }
    }
```

### SQLite資料庫格式

![](https://i.imgur.com/Oz85qFt.png)

## 提供方法



```C#
    public class DbAction
    {
        /// 新增單一股票資訊
        public static void addStock(Stock stock)
        /// 新增多個股票資訊
        public static void addStocks(IEnumerable<Stock> stocks)
        /// 移除單一股票資訊
        public static void removeStock(Stock stock)
        /// 移除多個股票資訊
        public static void removeStocks(IEnumerable<Stock> stocks)
        /// 移除所有股票資訊
        public static void removeAllStocks()
        /// 以id搜尋
        public static List<Stock> searchStocks(int id)
        /// 以名稱搜尋或代號
        public static List<Stock> searchStocks(string name)
        /// 以時間區段搜尋
        public static List<Stock> searchStocks(DateTime start, DateTime end)
        /// 以成交金額區段搜尋
        public static List<Stock> searchStocks(int max, int min)
    }
    public class CrawlerAction
    {
        /// 以股票代號爬取基本資訊
        public static Task BasicInfoCrawlerAsync(string codeName)
    }
```



## 使用範例

參考 `StockCrawlerTW_ByRockefeller.dll`

將`myStock.db`放至專案目錄

```C#
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
```



成果檢視

![](https://i.imgur.com/IccaUky.png)



## 更新資訊

* 2021/03/04 初版



## 注意事項

* 爬蟲使用時請務必加上延遲時間，減少伺服器負擔