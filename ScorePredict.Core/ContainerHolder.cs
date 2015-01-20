using System;
using Autofac;

namespace ScorePredict.Core
{
    public class ContainerHolder
    {
        private static IContainer _container;

        public static IContainer Current
        {
            get
            {
                if (_container == null)
                    throw new InvalidOperationException("ContainerHolder has notbeen initialized");

                return _container;
            }
        }

        public static void Initialize(IContainer container)
        {
            _container = container;
        }
    }
}
