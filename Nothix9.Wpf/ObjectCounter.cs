using Nothix9.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading;

namespace Nothix9.Wpf
{
    public class ObjectCounter
    {

        private EventPublisher _eventPublisher = new EventPublisher();

        public ObjectCounter(EventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }

        public void Start()
        {
            

            PerformLongCount(1);
        }

        private void PerformLongCount(object obj)
        {
            for (int i = 0; i < 25; i++)
            {
                Thread.Sleep(250);
                _eventPublisher.Publish(new NumberCountedEvent(i));
            }
        }
    
    }
}
