using Nothix9.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reactive.Linq;
using System.Reactive;
using System.Threading;

namespace Nothix9.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EventPublisher _eventPublisher;

        public MainWindow()
        {
            InitializeComponent();
            SubscribeToEvents();

        }

        private void SubscribeToEvents()
        {

            _eventPublisher = new EventPublisher();
            var numberCountedObserver = Observer.Create<NumberCountedEvent>(new Action<NumberCountedEvent>(OnNumberCounted));
            _eventPublisher.GetEvent<NumberCountedEvent>()
                .ObserveOnDispatcher()
                .Subscribe(numberCountedObserver);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(PerformLongCount));

            
        }

        private void PerformLongCount(object obj)
        {
            ObjectCounter counter = new ObjectCounter(_eventPublisher);
            counter.Start();
        }

        public void OnNumberCounted(NumberCountedEvent value)
        {
            txtBox.AppendText(string.Format("{0}\n", value.NumberCount));
        }
    }
}
