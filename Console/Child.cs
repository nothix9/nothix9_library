using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console
{
    public class Child
    {
        public int ID { get; set; }


        internal void Count(int counter)
        {
            System.Console.WriteLine(string.Format("child {0} - counts {1}", ID, counter));
        }

        internal void AnnounceOut()
        {
            System.Console.WriteLine(string.Format("child {0} - ok im out", ID));
        }

        internal void AnnounceWinner()
        {
            System.Console.WriteLine(string.Format("child {0} - Im the last one, Im the winner!", ID));
        }
    }
}
