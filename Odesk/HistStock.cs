using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odesk
{
    public class HistStock
    {
        [CsvField(Index = 0)]
        public string EventDate { get; set; }

        [CsvField(Index = 1)]
        public string PositiveStock { get; set; }

        [CsvField(Index = 2)]
        public double Open { get; set; }

        [CsvField(Index = 3)]
        public double High { get; set; }

        [CsvField(Index = 4)]
        public double Low { get; set; }

        [CsvField(Index = 5)]
        public double Close { get; set; }

        [CsvField(Index = 6)]
        public string Volume { get; set; }

        [CsvField(Index = 6)]
        public string Max { get; set; }

        [CsvField(Index = 6)]
        public string High2 { get; set; }

        [CsvField(Index = 6)]
        public string Diff { get; set; }

        [CsvField(Ignore = true)]
        public DateTime Date { get { return Convert.ToDateTime(EventDate); } }
        					


    }
}
