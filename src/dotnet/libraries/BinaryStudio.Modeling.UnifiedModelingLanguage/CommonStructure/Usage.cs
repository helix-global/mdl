using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Usage"/> is a <see cref="Dependency"/> in which the <see cref="Client"/> <see cref="Element"/> requires the <see cref="Supplier"/> <see cref="Element"/> (or set of Elements) for its full implementation or operation.
    /// </summary>
    /// xmi:id="Usage"
    public interface Usage : Dependency
        {
        }
    }
