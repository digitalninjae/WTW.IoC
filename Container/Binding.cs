using System;

namespace Container
{
    public class Binding : IBinding
    {
        public Type MyType { get; set; }
        public LifeCycleType LifeCycle { get; set; }

    }
}