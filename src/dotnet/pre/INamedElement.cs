using System;

namespace pre
    {
    internal interface INamedElement : IModelElement
        {
        String Name { get; }
        }
    }