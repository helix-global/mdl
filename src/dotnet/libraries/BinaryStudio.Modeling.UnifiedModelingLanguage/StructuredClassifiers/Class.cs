using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Class"/> classifies a set of objects and specifies the features that characterize the structure and behavior of those objects.  A <see cref="Class"/> may have an internal structure and Ports.
    /// 
    /// </summary>
    /// <rule language="OCL">
    ///   Only an active <see cref="Class"/> may own Receptions and have a classifierBehavior.
    ///   <![CDATA[
    ///     not isActive implies (ownedReception->isEmpty() and classifierBehavior = null)
    ///   ]]>
    ///   xmi:id="Class-passive_class"
    /// </rule>
    /// xmi:id="Class"
    public interface Class : BehavioredClassifier,EncapsulatedClassifier
        {
        #region P:Extension:IList<Extension>
        /// <summary>
        /// This property is used when the <see cref="Class"/> is acting as a metaclass. It references the Extensions that specify additional properties of the metaclass. The property is derived from the Extensions whose memberEnds are typed by the <see cref="Class"/>.
        /// </summary>
        /// xmi:id="Class-extension"
        /// xmi:association="A_extension_metaclass"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        IList<Extension> Extension { get; }
        #endregion
        #region P:IsAbstract:Boolean
        /// <summary>
        /// If true, the <see cref="Class"/> does not provide a complete declaration and cannot be instantiated. An abstract <see cref="Class"/> is typically used as a target of Associations or Generalizations.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.IsAbstract"/>"
        /// </summary>
        /// xmi:id="Class-isAbstract"
        Boolean IsAbstract { get;set; }
        #endregion
        #region P:IsActive:Boolean
        /// <summary>
        /// Determines whether an object specified by this <see cref="Class"/> is active or not. If true, then the owning <see cref="Class"/> is referred to as an active <see cref="Class"/>. If false, then such a <see cref="Class"/> is referred to as a passive <see cref="Class"/>.
        /// </summary>
        /// xmi:id="Class-isActive"
        Boolean IsActive { get;set; }
        #endregion
        #region P:NestedClassifier:IList<Classifier>
        /// <summary>
        /// The Classifiers owned by the <see cref="Class"/> that are not ownedBehaviors.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Class-nestedClassifier"
        /// xmi:aggregation="composite"
        /// xmi:association="A_nestedClassifier_nestingClass"
        /// xmi:subsets="A_redefinitionContext_redefinableElement-redefinableElement"
        [Ordered]
        IList<Classifier> NestedClassifier { get; }
        #endregion
        #region P:OwnedAttribute:IList<Property>
        /// <summary>
        /// The attributes (i.e., the Properties) owned by the <see cref="Class"/>.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.StructuredClassifier.OwnedAttribute"/>"
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.Attribute"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Class-ownedAttribute"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedAttribute_class"
        [Ordered]
        IList<Property> OwnedAttribute { get; }
        #endregion
        #region P:OwnedOperation:IList<Operation>
        /// <summary>
        /// The Operations owned by the <see cref="Class"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.Feature"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Class-ownedOperation"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedOperation_class"
        /// xmi:subsets="A_redefinitionContext_redefinableElement-redefinableElement"
        [Ordered]
        IList<Operation> OwnedOperation { get; }
        #endregion
        #region P:OwnedReception:IList<Reception>
        /// <summary>
        /// The Receptions owned by the <see cref="Class"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.Feature"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Class-ownedReception"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedReception_class"
        IList<Reception> OwnedReception { get; }
        #endregion
        #region P:SuperClass:IList<Class>
        /// <summary>
        /// The superclasses of a <see cref="Class"/>, derived from its Generalizations.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.General"/>"
        /// </summary>
        /// xmi:id="Class-superClass"
        /// xmi:association="A_superClass_class"
        /// xmi:is-derived="true"
        IList<Class> SuperClass { get; }
        #endregion

        #region M:extension:Extension[]
        /// <summary>
        /// Derivation for <see cref="Class"/>::/<see cref="Extension"/> : <see cref="Extension"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (Extension.allInstances()->select(ext | 
        ///       let endTypes : Sequence(Classifier) = ext.memberEnd->collect(type.oclAsType(Classifier)) in
        ///       endTypes->includes(self) or endTypes.allParents()->includes(self) ))
        ///   ]]>
        ///   xmi:id="Class-extension.1-spec"
        /// </rule>
        /// xmi:id="Class-extension.1"
        /// xmi:is-query="true"
        Extension[] extension();
        #endregion
        #region M:superClass:Class[]
        /// <summary>
        /// Derivation for <see cref="Class"/>::/<see cref="SuperClass"/> : <see cref="Class"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.general()->select(oclIsKindOf(Class))->collect(oclAsType(Class))->asSet())
        ///   ]]>
        ///   xmi:id="Class-superClass.1-spec"
        /// </rule>
        /// xmi:id="Class-superClass.1"
        /// xmi:is-query="true"
        Class[] superClass();
        #endregion
        }
    }
