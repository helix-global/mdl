using System;
using System.Collections.Generic;

namespace pre
    {
    internal interface IPackage
        {
        IDictionary<String,IPackageableElement> PackagedElement { get; }
        }
    }