using System;

namespace EventBroker
{
    /// <summary>
    /// Create using singleton pattern
    /// </summary>
    public class EBroker
    {
        private readonly MultiDictionary<string, Delegate> subscriptions;
        public EBroker()
        {
            this.subscriptions = new MultiDictionary<string, Delegate>();
        }

        public void Publish<T>(string name, object sender, T args)
        {
            foreach (Delegate handler in subscriptions[name])
            {
                handler.DynamicInvoke(sender, args);
            }
        }

        public void Subscribe(string name, Delegate handler)
        {
            subscriptions.Add(name, handler);
        }
    }
}
