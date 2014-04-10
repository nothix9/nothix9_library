using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DownloadAsynchronously();
            System.Console.WriteLine("Waiting to finish on thread {0}....", 
                Thread.CurrentThread.ManagedThreadId);
            System.Console.ReadLine();
        }

        private static void DownloadAsynchronously()
        {
            string[] urls =
            {
                "http://www.pluralsight-training.net/microsoft/",
                "http://www.microsoft.com/en/us/default.aspx",
                "http://twitter.com/odetocode"
            };

            Parallel.ForEach(urls, url =>
            {
                var client = new WebClient();
                var html = client.DownloadString(url.ToString());
                System.Console.WriteLine("Download {0} chars from {1} on thread {2}",
                    html.Length, url, Thread.CurrentThread.ManagedThreadId);
            });


        }

        private static void Download(string url)
        {
            var client = new WebClient();
            client.DownloadStringCompleted += client_DownloadStringCompleted;
            client.DownloadStringAsync(new Uri(url), url);
        }

        static void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            var html = e.Result;
            var url = e.UserState as string;

            System.Console.WriteLine("Download {0} chars from {1} on thread {2}",
                html.Length, url, Thread.CurrentThread.ManagedThreadId);
        }




    }
      //var client = new WebClient();
      //      var html = client.DownloadString(url.ToString());
      //      System.Console.WriteLine("Download {0} chars from {1} on thread {2}",
      //          html.Length, url, Thread.CurrentThread.ManagedThreadId);

}


