using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Component"/> represents a modular <see cref="Part"/> of a system that encapsulates its contents and whose manifestation is replaceable within its environment.  
    /// </summary>
    /// <rule language="OCL">
    ///   A <see cref="Component"/> cannot nest Classifiers.
    ///   <![CDATA[
    ///     nestedClassifier->isEmpty()
    ///   ]]>
    ///   xmi:id="Component-no_nested_classifiers"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="Component"/> nested in a <see cref="Class"/> cannot have any packaged elements.
    ///   <![CDATA[
    ///     nestingClass <> null implies packagedElement->isEmpty()
    ///   ]]>
    ///   xmi:id="Component-no_packaged_elements"
    /// </rule>
    /// xmi:id="Component"
    public interface Component : Class
        {
        #region P:IsIndirectlyInstantiated:Boolean
        /// <summary>
        /// If true, the <see cref="Component"/> is defined at design-time, but at run-time (or execution-time) an object specified by the <see cref="Component"/> does not exist, that is, the <see cref="Component"/> is instantiated indirectly, through the instantiation of its realizing Classifiers or parts.
        /// </summary>
        /// xmi:id="Component-isIndirectlyInstantiated"
        Boolean IsIndirectlyInstantiated { get;set; }
        #endregion
        #region P:PackagedElement:IList<PackageableElement>
        /// <summary>
        /// The set of PackageableElements that a <see cref="Component"/> owns. In the <see cref="Namespace"/> of a <see cref="Component"/>, all model elements that are involved in or related to its definition may be owned or imported explicitly. These may include e.g., Classes, Interfaces, Components, Packages, UseCases, Dependencies (e.g., mappings), and Artifacts.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Component-packagedElement"
        /// xmi:aggregation="composite"
        /// xmi:association="A_packagedElement_component"
        IList<PackageableElement> PackagedElement { get; }
        #endregion
        #region P:Provided:IList<Interface>
        /// <summary>
        /// The Interfaces that the <see cref="Component"/> exposes to its environment. These Interfaces may be Realized by the <see cref="Component"/> or any of its realizingClassifiers, or they may be the Interfaces that are <see cref="Provided"/> by its public Ports.
        /// </summary>
        /// xmi:id="Component-provided"
        /// xmi:association="A_provided_component"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        IList<Interface> Provided { get; }
        #endregion
        #region P:Realization:IList<ComponentRealization>
        /// <summary>
        /// The set of Realizations owned by the <see cref="Component"/>. Realizations reference the Classifiers of which the <see cref="Component"/> is an abstraction; i.e., that realize its behavior.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Component-realization"
        /// xmi:aggregation="composite"
        /// xmi:association="A_realization_abstraction_component"
        /// xmi:subsets="A_supplier_supplierDependency-supplierDependency"
        IList<ComponentRealization> Realization { get; }
        #endregion
        #region P:Required:IList<Interface>
        /// <summary>
        /// The Interfaces that the <see cref="Component"/> requires from other Components in its environment in order to be able to offer its full set of <see cref="Provided"/> functionality. These Interfaces may be used by the <see cref="Component"/> or any of its realizingClassifiers, or they may be the Interfaces that are <see cref="Required"/> by its public Ports.
        /// </summary>
        /// xmi:id="Component-required"
        /// xmi:association="A_required_component"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        IList<Interface> Required { get; }
        #endregion

        #region M:provided:Interface[]
        /// <summary>
        /// Derivation for <see cref="Component"/>::/<see cref="Provided"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (let 	ris : Set(Interface) = allRealizedInterfaces(),
        ///             realizingClassifiers : Set(Classifier) =  self.realization.realizingClassifier->union(self.allParents()->collect(realization.realizingClassifier))->asSet(),
        ///             allRealizingClassifiers : Set(Classifier) = realizingClassifiers->union(realizingClassifiers.allParents())->asSet(),
        ///             realizingClassifierInterfaces : Set(Interface) = allRealizingClassifiers->iterate(c; rci : Set(Interface) = Set{} | rci->union(c.allRealizedInterfaces())),
        ///             ports : Set(Port) = self.ownedPort->union(allParents()->collect(ownedPort))->asSet(),
        ///             providedByPorts : Set(Interface) = ports.provided->asSet()
        ///     in     ris->union(realizingClassifierInterfaces) ->union(providedByPorts)->asSet())
        ///   ]]>
        ///   xmi:id="Component-provided.1-spec"
        /// </rule>
        /// xmi:id="Component-provided.1"
        /// xmi:is-query="true"
        Interface[] provided();
        #endregion
        #region M:required:Interface[]
        /// <summary>
        /// Derivation for <see cref="Component"/>::/<see cref="Required"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (let 	uis : Set(Interface) = allUsedInterfaces(),
        ///             realizingClassifiers : Set(Classifier) = self.realization.realizingClassifier->union(self.allParents()->collect(realization.realizingClassifier))->asSet(),
        ///             allRealizingClassifiers : Set(Classifier) = realizingClassifiers->union(realizingClassifiers.allParents())->asSet(),
        ///             realizingClassifierInterfaces : Set(Interface) = allRealizingClassifiers->iterate(c; rci : Set(Interface) = Set{} | rci->union(c.allUsedInterfaces())),
        ///             ports : Set(Port) = self.ownedPort->union(allParents()->collect(ownedPort))->asSet(),
        ///             usedByPorts : Set(Interface) = ports.required->asSet()
        ///     in	    uis->union(realizingClassifierInterfaces)->union(usedByPorts)->asSet()
        ///     )
        ///   ]]>
        ///   xmi:id="Component-required.1-spec"
        /// </rule>
        /// xmi:id="Component-required.1"
        /// xmi:is-query="true"
        Interface[] required();
        #endregion
        }
    }
