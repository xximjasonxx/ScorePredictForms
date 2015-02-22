using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScorePredict.Core.MessageBus
{
    public class DefaultMessageBus : IBus
    {
        public IDictionary<Type, IList<Action>> ActionDictionary { get; private set; }

        public DefaultMessageBus()
        {
            ActionDictionary = new Dictionary<Type, IList<Action>>();
        }

        public void Publish<T>() where T : IMessage
        {
            if (ActionDictionary.ContainsKey(typeof (T)))
            {
                foreach (var action in ActionDictionary[typeof (T)])
                {
                    var thisAction = action;
                    Task.Run(() => thisAction.Invoke());        // fire and forget
                }
            }
        }

        public void ListenFor<T>(Action action) where T : IMessage
        {
            if (!ActionDictionary.ContainsKey(typeof (T)))
            {
                ActionDictionary.Add(typeof (T), new List<Action>());
            }

            ActionDictionary[typeof(T)].Add(action);
        }
    }
}
