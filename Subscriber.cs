using System;

namespace EventBroker
{
    internal struct Subscriber
    {
        internal readonly string EvName;
        internal readonly int SenderHash;
        internal readonly Delegate Handler;

        internal Subscriber(string evName, int senderHash, Delegate handler)
        {
            EvName = evName;
            SenderHash = senderHash;
            Handler = handler;
        }
    }
}