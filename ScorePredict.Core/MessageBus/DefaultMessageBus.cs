using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScorePredict.Core.MessageBus
{
    public class DefaultMessageBus : IBus
    {
        public IDictionary<Type, IList<object>> ActionDictionary { get; private set; }

        public DefaultMessageBus()
        {
            ActionDictionary = new Dictionary<Type, IList<object>>();
        }

        public void Publish<T>(T message) where T : IMessage
        {
            if (ActionDictionary.ContainsKey(typeof (T)))
            {
                foreach (var action in ActionDictionary[typeof (T)])
                {
                    var thisAction = (Action<T>)action;
                    thisAction.Invoke(message);
                }
            }
        }

        public void ListenFor<T>(Action<T> action) where T : IMessage
        {
            if (!ActionDictionary.ContainsKey(typeof (T)))
            {
                ActionDictionary.Add(typeof (T), new List<object>());
            }

            ActionDictionary[typeof(T)].Add(action);
        }
    }
}
