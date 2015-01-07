using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Common.Injection
{
    public class InjectionModule
    {
        private readonly IDictionary<Type, Type> _typeDictionary;
		private readonly IDictionary<Type, object> _registeredInstances;

        protected InjectionModule()
        {
            _typeDictionary = new Dictionary<Type, Type>();
			_registeredInstances = new Dictionary<Type, object>();
        }

        internal IDictionary<Type, Type> GetTypeDictionary()
        {
            return _typeDictionary;
        }

		internal IDictionary<Type, object> GetInstanceDictionary ()
		{
			return _registeredInstances;
		}

        public void AddDependency<T>(Type concreteType)
        {
            if (_typeDictionary.ContainsKey(typeof(T)))
                throw new ArgumentException("Dependency Exists for Type T");

            _typeDictionary.Add(typeof(T), concreteType);
        }

		public void AddDependency<T>(object instance)
		{
			if (_typeDictionary.ContainsKey (typeof(T)))
				throw new ArgumentException ("Dependency Exists for Type T");

			_registeredInstances.Add (typeof(T), instance);
		}
    }
}
