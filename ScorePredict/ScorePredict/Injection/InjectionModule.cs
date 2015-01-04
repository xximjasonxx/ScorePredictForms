using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Injection
{
    public class InjectionModule
    {
        private readonly IDictionary<Type, Type> _typeDictionary;

        protected InjectionModule()
        {
            _typeDictionary = new Dictionary<Type, Type>();
        }

        internal IDictionary<Type, Type> GetTypeDictionary()
        {
            return _typeDictionary;
        }

        public void AddDependency<T>(Type concreteType)
        {
            if (_typeDictionary.ContainsKey(typeof(T)))
                throw new ArgumentException("Dependency Exists for Type T");

            _typeDictionary.Add(typeof(T), concreteType);
        }
    }
}
