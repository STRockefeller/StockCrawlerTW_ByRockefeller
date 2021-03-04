using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockCrawlerTW_ByRockefeller
{
    /// <summary>
    /// 資料庫操作類別
    /// </summary>
    public class DbAction
    {
        /// <summary>
        /// 新增單一股票資訊
        /// </summary>
        /// <param name="stock"></param>
        public static void addStock(Stock stock)
        {
            try
            {
                using (StockContext db = new StockContext())
                {
                    db.Add(stock);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); };

        }
        /// <summary>
        /// 新增多個股票資訊
        /// </summary>
        /// <param name="stocks"></param>
        public static void addStocks(IEnumerable<Stock> stocks)
        {
            try
            {
                using (StockContext db = new StockContext())
                {
                    foreach (Stock stock in stocks)
                        db.Add(stock);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); };
        }
        /// <summary>
        /// 移除單一股票資訊
        /// </summary>
        /// <param name="stock"></param>
        public static void removeStock(Stock stock)
        {
            try
            {
                using (StockContext db = new StockContext())
                {
                    db.Remove(stock);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); };
        }
        /// <summary>
        /// 移除多個股票資訊
        /// </summary>
        /// <param name="stocks"></param>
        public static void removeStocks(IEnumerable<Stock> stocks)
        {
            try
            {
                using (StockContext db = new StockContext())
                {
                    foreach (Stock stock in stocks)
                        db.Remove(stock);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); };
        }
        /// <summary>
        /// 移除所有股票資訊
        /// </summary>
        public static void removeAllStocks()
        {
            try
            {
                using (StockContext db = new StockContext())
                {
                    db.stocks.RemoveRange(db.stocks);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); };
        }
        /// <summary>
        /// 以id搜尋
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Stock> searchStocks(int id)
        {
            try
            {
                using (StockContext db = new StockContext())
                {
                    return db.stocks.Where(stock => stock.id == id).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Stock>();
            };
        }
        /// <summary>
        /// 以名稱搜尋或代號
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<Stock> searchStocks(string name)
        {
            try
            {
                using (StockContext db = new StockContext())
                {
                    List<Stock> res = db.stocks.Where(stock => stock.stockId == name).ToList();
                    if (res.Count == 0)
                        res = db.stocks.Where(stock => stock.codeName == name).ToList();
                    return res;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Stock>();
            };
        }
        /// <summary>
        /// 以時間區段搜尋
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static List<Stock> searchStocks(DateTime start, DateTime end)
        {
            try
            {
                using (StockContext db = new StockContext())
                {
                    return db.stocks.Where(stock => stock.tradingDate.CompareTo(start) >= 0 &&
                    stock.tradingDate.CompareTo(end) <= 0).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Stock>();
            };
        }
        /// <summary>
        /// 以成交金額區段搜尋
        /// </summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        public static List<Stock> searchStocks(int max, int min)
        {
            try
            {
                using (StockContext db = new StockContext())
                {
                    return db.stocks.Where(stock => Convert.ToInt32(stock.tradingMoney) < max &&
                    Convert.ToInt32(stock.tradingMoney) > min).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Stock>();
            };

        }
        /// <summary>
        /// 取得資料庫ID
        /// </summary>
        /// <returns></returns>
        internal static int getId()
        {
            try
            {
                using (StockContext db = new StockContext())
                {
                    if (db.stocks.Count() == 0)
                        return 1;
                    return db.stocks.Select(stock => stock.id).Max() + 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            };
        }
    }
    public class CrawlerAction
    {
        /// <summary>
        /// 以股票代號爬取基本資訊
        /// </summary>
        /// <param name="codeName"></param>
        /// <returns></returns>
        public static Task BasicInfoCrawlerAsync(string codeName) => CnyesCrawler.BasicInfoCrawlerAsync(codeName);
    }
}
