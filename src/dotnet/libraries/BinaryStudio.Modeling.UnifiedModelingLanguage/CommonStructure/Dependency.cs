using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Dependency"/> is a <see cref="Relationship"/> that signifies that a single model <see cref="Element"/> or a set of model Elements requires other model Elements for their specification or implementation. This means that the complete semantics of the <see cref="Client"/> <see cref="Element"/>(s) are either semantically or structurally dependent on the definition of the <see cref="Supplier"/> <see cref="Element"/>(s).
    /// </summary>
    /// xmi:id="Dependency"
    public interface Dependency : DirectedRelationship,PackageableElement
        {
        #region P:Client:NamedElement[]
        /// <summary>
        /// The <see cref="Element"/>(s) dependent on the <see cref="Supplier"/> <see cref="Element"/>(s). In some cases (such as a trace <see cref="Abstraction"/>) the assignment of direction (that is, the designation of the <see cref="Client"/> <see cref="Element"/>) is at the discretion of the modeler and is a stipulation.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.DirectedRelationship.Source"/>"
        /// </summary>
        /// xmi:id="Dependency-client"
        /// xmi:association="A_clientDependency_client"
        [Multiplicity("1..*")]
        NamedElement[] Client { get; }
        #endregion
        #region P:Supplier:NamedElement[]
        /// <summary>
        /// The <see cref="Element"/>(s) on which the <see cref="Client"/> <see cref="Element"/>(s) depend in some respect. The modeler may stipulate a sense of <see cref="Dependency"/> direction suitable for their domain.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.DirectedRelationship.Target"/>"
        /// </summary>
        /// xmi:id="Dependency-supplier"
        /// xmi:association="A_supplier_supplierDependency"
        [Multiplicity("1..*")]
        NamedElement[] Supplier { get; }
        #endregion
        }
    }
