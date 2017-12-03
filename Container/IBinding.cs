using System;

namespace Container
{
    public interface IBinding
    {
        Type MyType { get; set; }
        LifeCycleType LifeCycle { get; set; }
    }
}