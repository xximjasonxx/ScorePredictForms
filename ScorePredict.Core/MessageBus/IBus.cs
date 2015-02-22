using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Core.MessageBus
{
    public interface IBus
    {
        void Publish<T>() where T : IMessage;
        void ListenFor<T>(Action action) where T : IMessage;
    }
}
