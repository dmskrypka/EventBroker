using System.Collections.Generic;

namespace EventBroker
{
    internal class MultiDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, IList<TValue>> data;

        public IEnumerable<TValue> this[TKey key]
        {
            get => this.data[key];
            set => this.data[key] = new List<TValue>(value);
        }

        public MultiDictionary()
        {
            this.data = new Dictionary<TKey, IList<TValue>>();
        }

        internal void Add(TKey key, TValue value)
        {
            if (this.data.ContainsKey(key))
                this.data[key].Add(value);
            else
                data.Add(key, new List<TValue>() { value });
        }
    }
}
