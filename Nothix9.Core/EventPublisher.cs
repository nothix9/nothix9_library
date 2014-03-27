using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Concurrency;
using System.Threading;

namespace Nothix9.Core
{
    public class EventPublisher : IEventPublisher
    {
        private readonly ConcurrentDictionary<Type, object> subjects
            = new ConcurrentDictionary<Type, object>();

        public IObservable<TEvent> GetEvent<TEvent>()
        {
            var subject =
                (ISubject<TEvent>)subjects.GetOrAdd(typeof(TEvent),
                            t => new Subject<TEvent>());
            return subject.AsObservable();
        }

        public void Publish<TEvent>(TEvent publishedEvent)
        {
            //ThreadPool.QueueUserWorkItem(
            //    new WaitCallback(PerformEvent));

            object subject;
            if (subjects.TryGetValue(typeof(TEvent), out subject))
            {
                ((ISubject<TEvent>)subject).OnNext(publishedEvent);
            }
        }

        private void PerformEvent<TEvent>(TEvent publishedEvent)
        {
            object subject;
            if (subjects.TryGetValue(typeof(TEvent), out subject))
            {
                ((ISubject<TEvent>)subject).OnNext(publishedEvent);
            }
        }
    }
}
