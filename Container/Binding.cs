using System;

namespace IoC
{
    public class Binding : IBinding
    {
        public Type MyType { get; set; }
        public LifeCycleType LifeCycle { get; set; }

    }
}