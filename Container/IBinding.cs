using System;

namespace IoC
{
    public interface IBinding
    {
        Type MyType { get; set; }
        LifeCycleType LifeCycle { get; set; }
    }
}