using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Injection
{
    public class Resolver
    {
        private static Resolver _current;

        public static Resolver CurrentResolver
        {
            get { return _current ?? (_current = new Resolver()); }
        }

        private bool _isInitialized;

        private Resolver()
        {
            TypeDictionary = new Dictionary<Type, Type>();
            _isInitialized = false;
        }

        private IDictionary<Type, Type> TypeDictionary { get; set; }

        public void Initialize(InjectionModule module)
        {
            // perform initialization
            foreach (var dependency in module.GetTypeDictionary())
            {
                if (!TypeDictionary.ContainsKey(dependency.Key))
                    TypeDictionary.Add(dependency);
            }

            // update is initialized
            _isInitialized = true;
        }

        public T Get<T>()
        {
            if (!_isInitialized)
                throw new InvalidOperationException("Container is not resolved");

            if (!TypeDictionary.ContainsKey(typeof(T)))
                throw new InvalidOperationException("No Dependency Speceified for T");

            Type concreteType;
            if (!TypeDictionary.TryGetValue(typeof(T), out concreteType))
                throw new InvalidOperationException("Failed to get Type for Dependency");

            return (T) Activator.CreateInstance(concreteType);
        }
    }
}
