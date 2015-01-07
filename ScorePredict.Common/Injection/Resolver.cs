using System;
using System.Collections.Generic;

namespace ScorePredict.Common.Injection
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
			InstanceDictionary = new Dictionary<Type, object>();

            _isInitialized = false;
        }

        private IDictionary<Type, Type> TypeDictionary { get; set; }
		private IDictionary<Type, object> InstanceDictionary { get; set; }

        public void Initialize(params InjectionModule[] modules)
        {
            // perform initialization
            foreach (var module in modules)
            {
                foreach (var dependency in module.GetTypeDictionary())
                {
                    if (!TypeDictionary.ContainsKey(dependency.Key))
                        TypeDictionary.Add(dependency);
                }

				foreach (var dependency in module.GetInstanceDictionary())
				{
					if (!InstanceDictionary.ContainsKey(dependency.Key))
						InstanceDictionary.Add(dependency);
				}
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

            return (T)Activator.CreateInstance(concreteType);
        }

		public T GetInstance<T>()
		{
			if (!_isInitialized)
				throw new InvalidOperationException("Container is not resolved");

			if (!InstanceDictionary.ContainsKey(typeof(T)))
				throw new InvalidOperationException("No Dependency Speceified for T");

			object instance;
			if (!InstanceDictionary.TryGetValue(typeof(T), out instance))
				throw new InvalidOperationException("Failed to get Type for Dependency");

			return (T)instance;
		}
    }
}
