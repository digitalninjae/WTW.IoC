using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Container
{
    public class Container
    {
        private readonly Dictionary<Type, IBinding> _bindings = new Dictionary<Type, IBinding>();
        private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();

        public void Register<TInterface, TClass>(LifeCycleType lifeCycle = LifeCycleType.Transient)
        {
            if (!_bindings.ContainsKey(typeof(TInterface)))
                _bindings.Add(typeof(TInterface), new Binding {LifeCycle = lifeCycle, MyType = typeof(TClass)});
        }


        public T Resolve<T>()
        {
            if (!_bindings.ContainsKey(typeof(T)))
                throw new UnknownTypeException($"No binding registered for type {typeof(T).Name}.");

            var binding = _bindings[typeof(T)];
            var constructor = binding.MyType.GetConstructors().FirstOrDefault();
            IEnumerable<object> parameters = null;
            if (constructor != null)
                parameters = (from pi in constructor.GetParameters()
                    let resolver = typeof(Container).GetMethod("Resolve")
                    where resolver != null
                    select resolver.MakeGenericMethod(pi.ParameterType)
                    into tResolver
                    select tResolver.Invoke(this, null));
            switch (binding.LifeCycle)
            {
                case LifeCycleType.Singleton:
                    lock (_instances)
                    {
                        if (!_instances.ContainsKey(typeof(T)))
                        {
                            _instances.Add(typeof(T),
                                parameters == null
                                    ? Activator.CreateInstance(binding.MyType)
                                    : constructor.Invoke(parameters.ToArray()));
                        }
                        return (T) _instances[typeof(T)];
                    }
                default:
                    return parameters == null
                        ? (T) Activator.CreateInstance(binding.MyType)
                        : (T) constructor.Invoke(parameters.ToArray());
            }
        }
    }
}