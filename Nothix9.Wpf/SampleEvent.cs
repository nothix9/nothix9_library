using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nothix9.Wpf
{
    public class NumberCountedEvent
    {
        private int i;

        public NumberCountedEvent(int i)
        {
            // TODO: Complete member initialization
            this.i = i;
            NumberCount = i.ToString();
        }
        public string NumberCount { get; set; }
    }
}
