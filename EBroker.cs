using System;
using System.Collections.Generic;
using System.Linq;

namespace EventBroker
{
    /// <summary>
    /// Create using singleton pattern
    /// </summary>
    public class EBroker
    {
        private readonly List<Subscriber> subscriptions;
        public EBroker()
        {
            this.subscriptions = new List<Subscriber>();
        }

        public void Publish<T>(string name, object sender, T args)
        {
            IEnumerable<Subscriber> subs = subscriptions.Where(x => x.EvName == name);
            for(int i = 0; i < subs.Count(); i++)
            {
                subscriptions[i].Handler.DynamicInvoke(sender, args);
            }
        }

        public void Subscribe(string name, Delegate handler, object sender)
        {
            subscriptions.Add(new Subscriber(name, sender.GetHashCode(), handler));
        }

        public void Unsubscribe(string name)
        {
            subscriptions.RemoveAll(x => x.EvName == name);
        }

        public void Unsubscribe(string name, object sender)
        {
            subscriptions.RemoveAll(x => x.EvName == name && x.SenderHash == sender.GetHashCode());
        }
    }
}
