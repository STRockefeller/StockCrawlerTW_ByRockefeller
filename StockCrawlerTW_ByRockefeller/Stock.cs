using System;
using Microsoft.EntityFrameworkCore;

namespace StockCrawlerTW_ByRockefeller
{
    public class StockContext:DbContext
    {
        public DbSet<Stock> stocks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite("Data Source=myStock.db");
    }
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
}
