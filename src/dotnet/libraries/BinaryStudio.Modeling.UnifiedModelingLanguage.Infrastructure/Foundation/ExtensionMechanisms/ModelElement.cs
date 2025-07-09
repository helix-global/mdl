using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    /// <summary>
    /// Any model element may have arbitrary tagged values and constraints (subject to these making sense). A model element may also have one or more stereotypes. In the latter case, the base class of the stereotype must match the metaclass of that model element (such as Class, Association, Dependency) or one of its subclasses. The presence of a stereotype may impose implicit constraints on the modeling element and may require the presence of specific tagged values.
    /// </summary>
    public partial interface ModelElement
        {
        /// <summary>
        /// A set of Constraints affecting the element.
        /// A constraint that must be satisfied by the model element. A model element may have a set of constraints. The constraint is to be evaluated when the system is stable; that is, not in the middle of an atomic operation.
        /// </summary>
        IList<Constraint> constraint { get; }
        /// <summary>
        /// Designates the stereotypes that further qualify the UML metaclass (the base class or one of its subclasses) of the modeling element. The stereotype does not conflict with or contradict the standard semantics of the metaclass to which it applies, but may specify additional constraints and tag definitions. All constraints and tag definitions on a stereotype apply to the model elements that are branded by the stereotype. The stereotype acts as a virtual metaclass describing the model element.
        /// </summary>
        IList<Stereotype> stereotype { get; }
        /// <summary>
        /// An arbitrary property attached to the model element based on an associated tag 
        /// </summary>
        IList<TaggedValue> taggedValue { get; }
        }
    }