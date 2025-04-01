using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Constraint"/> is a condition or restriction expressed in natural language text or in a machine readable language for the purpose of declaring some of the semantics of an <see cref="Element"/> or set of Elements.
    /// </summary>
    /// <rule language="">
    ///   The <see cref="ValueSpecification"/> for a <see cref="Constraint"/> must evaluate to a Boolean value.
    ///   xmi:id="Constraint-boolean_value"
    /// </rule>
    /// <rule language="">
    ///   Evaluating the <see cref="ValueSpecification"/> for a <see cref="Constraint"/> must not have side effects.
    ///   xmi:id="Constraint-no_side_effects"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="Constraint"/> cannot be applied to itself.
    ///   <![CDATA[
    ///     not constrainedElement->includes(self)
    ///   ]]>
    ///   xmi:id="Constraint-not_apply_to_self"
    /// </rule>
    /// xmi:id="Constraint"
    public interface Constraint : PackageableElement
        {
        #region P:ConstrainedElement:IList<Element>
        /// <summary>
        /// The ordered set of Elements referenced by this <see cref="Constraint"/>.
        /// </summary>
        /// xmi:id="Constraint-constrainedElement"
        /// xmi:association="A_constrainedElement_constraint"
        [Ordered]
        IList<Element> ConstrainedElement { get; }
        #endregion
        #region P:Context:Namespace
        /// <summary>
        /// Specifies the <see cref="Namespace"/> that owns the <see cref="Constraint"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        /// </summary>
        /// xmi:id="Constraint-context"
        /// xmi:association="A_ownedRule_context"
        [Multiplicity("0..1")]
        Namespace Context { get;set; }
        #endregion
        #region P:Specification:ValueSpecification
        /// <summary>
        /// A condition that must be true when evaluated in order for the <see cref="Constraint"/> to be satisfied.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Constraint-specification"
        /// xmi:aggregation="composite"
        /// xmi:association="A_specification_owningConstraint"
        ValueSpecification Specification { get;set; }
        #endregion
        }
    }
