using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper.Configuration;
using MaasOne.Finance.YahooFinance;
using MaasOne.Base;
using MaasOne.Finance;
using CsvHelper;
using System.IO;

namespace Odesk
{
    public class DateStock
    {
        [CsvField(Index = 0)]
        public DateTime Date { get; set; }

        [CsvField(Index = 1)]
        public string Stock { get; set; }

        [CsvField(Ignore = true)]
        public DateTime LowerBound { get; set; }

        [CsvField(Ignore = true)]
        public DateTime HigherBound { get; set; }

        //private List<HistQuotesData> _historicalData ;

        private List<HistStock> _historicalData;

        public List<HistStock> HistoricalData
        {
            get { return _historicalData; }
            set { _historicalData = value; }
        }

      
        public void SetRangeDate()
        {
            if(Date != default(DateTime))
            {
                LowerBound = Date.SubtractWorkdays(45);
                HigherBound = Date.AddWorkdays(45);
            }
        }

        public void DownLoadStockData()
        {
            SetRangeDate();
            _historicalData = new List<HistStock>();
            //Parameters
            IEnumerable<string> ids = new string[] { Stock };
            IEnumerable<QuoteProperty> properties = new QuoteProperty[] {
                QuoteProperty.Symbol,
                QuoteProperty.TradeDate,
                QuoteProperty.Name,
                QuoteProperty.Open,
                QuoteProperty.HighLimit,
                QuoteProperty.LowLimit,
                QuoteProperty.PreviousClose,
                QuoteProperty.Volume};

            //Download

            HistQuotesDownload dl = new HistQuotesDownload();
            Response<HistQuotesResult> resp = dl.Download(Stock, LowerBound, HigherBound, HistQuotesInterval.Daily);

            //Response/Result
            if (resp.Connection.State == ConnectionState.Success)
            {
                foreach (var qd in resp.Result.Items)
                {

                    var hd = new HistStock();
                    hd.EventDate = qd.TradingDate.ToShortDateString();
                    hd.PositiveStock = Stock;
                    hd.Open = qd.Open;
                    hd.High = qd.High;
                    hd.Low = qd.Low;
                    hd.Close = qd.Close;
                    hd.Volume = qd.Volume.ToString("#,##0");

                    _historicalData.Add(hd);
                }
            }

            _historicalData = _historicalData.OrderByDescending(hd => hd.Date).ToList();
        }

        public void CreateHistCsv()
        {

           
            using (var csv = new CsvWriter(new StreamWriter(string.Format("{0}{1}{2}.csv",Index,Stock,Date.ToString("dd-MM-yyyy")))))
            {
                csv.WriteRecords(_historicalData);
            }
        }

        [CsvField(Ignore = true)]
        public int Index { get; set; }
    }

    public sealed class CustomClassMap : CsvClassMap<DateStock>
    {
        public CustomClassMap()
        {
            Map(m => m.Date).Index(0);
            Map(m => m.Date).Index(1);
            Map(m => m.LowerBound).Ignore();
            Map(m=> m.HigherBound).Ignore();
        }
    }
}
