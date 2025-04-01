using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="Realization"/> is a specialized <see cref="Abstraction"/> relationship between two sets of model Elements, one representing a specification (the <see cref="Supplier"/>) and the other represents an implementation of the latter (the <see cref="Client"/>). <see cref="Realization"/> can be used to model stepwise refinement, optimizations, transformations, templates, model synthesis, framework composition, etc.
    /// </summary>
    /// xmi:id="Realization"
    public interface Realization : Abstraction
        {
        }
    }
