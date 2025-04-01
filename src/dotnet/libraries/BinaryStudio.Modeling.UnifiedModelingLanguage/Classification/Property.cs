using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Property"/> is a <see cref="StructuralFeature"/>. A <see cref="Property"/> related by ownedAttribute to a <see cref="Classifier"/> (other than an <see cref="Association"/>) represents an attribute and might also represent an <see cref="Association"/> <see cref="End"/>. It relates an instance of the <see cref="Classifier"/> to a value or set of values of the <see cref="Type"/> of the attribute. A <see cref="Property"/> related by memberEnd to an <see cref="Association"/> represents an <see cref="End"/> of the <see cref="Association"/>. The <see cref="Type"/> of the <see cref="Property"/> is the <see cref="Type"/> of the <see cref="End"/> of the <see cref="Association"/>. A <see cref="Property"/> has the capability of being a <see cref="DeploymentTarget"/> in a <see cref="Deployment"/> relationship. This enables modeling the <see cref="Deployment"/> to hierarchical nodes that have Properties functioning as internal parts.  <see cref="Property"/> specializes <see cref="ParameterableElement"/> to specify that a <see cref="Property"/> can be exposed as a formal template parameter, and provided as an actual parameter in a binding of a template.
    /// </summary>
    /// <rule language="OCL">
    ///   Subsetting may only occur when the context of the subsetting property conforms to the context of the subsetted property.
    ///   <![CDATA[
    ///     subsettedProperty->notEmpty() implies
    ///       (subsettingContext()->notEmpty() and subsettingContext()->forAll (sc |
    ///         subsettedProperty->forAll(sp |
    ///           sp.subsettingContext()->exists(c | sc.conformsTo(c)))))
    ///   ]]>
    ///   xmi:id="Property-subsetting_context_conforms"
    /// </rule>
    /// <rule language="OCL">
    ///   A derived union is read only.
    ///   <![CDATA[
    ///     isDerivedUnion implies isReadOnly
    ///   ]]>
    ///   xmi:id="Property-derived_union_is_read_only"
    /// </rule>
    /// <rule language="OCL">
    ///   A multiplicity on the composing end of a composite aggregation must not have an upper bound greater than 1.
    ///   <![CDATA[
    ///     isComposite and association <> null implies opposite.upperBound() <= 1
    ///     
    ///     
    ///   ]]>
    ///   xmi:id="Property-multiplicity_of_composite"
    /// </rule>
    /// <rule language="OCL">
    ///   A redefined <see cref="Property"/> must be inherited from a more general <see cref="Classifier"/>.
    ///   <![CDATA[
    ///     (redefinedProperty->notEmpty()) implies
    ///       (redefinitionContext->notEmpty() and
    ///           redefinedProperty->forAll(rp|
    ///             ((redefinitionContext->collect(fc|
    ///               fc.allParents()))->asSet())->collect(c| c.allFeatures())->asSet()->includes(rp)))
    ///   ]]>
    ///   xmi:id="Property-redefined_property_inherited"
    /// </rule>
    /// <rule language="OCL">
    ///   A subsetting <see cref="Property"/> may strengthen the type of the subsetted <see cref="Property"/>, and its upper bound may be less.
    ///   <![CDATA[
    ///     subsettedProperty->forAll(sp |
    ///       self.type.conformsTo(sp.type) and
    ///         ((self.upperBound()->notEmpty() and sp.upperBound()->notEmpty()) implies
    ///           self.upperBound() <= sp.upperBound() ))
    ///   ]]>
    ///   xmi:id="Property-subsetting_rules"
    /// </rule>
    /// <rule language="OCL">
    ///   A binding of a PropertyTemplateParameter representing an attribute must be to an attribute.
    ///   <![CDATA[
    ///     (self.isAttribute()
    ///     and (templateParameterSubstitution->notEmpty())
    ///     implies (templateParameterSubstitution->forAll(ts |
    ///         ts.formal.oclIsKindOf(Property)
    ///         and ts.formal.oclAsType(Property).isAttribute())))
    ///   ]]>
    ///   xmi:id="Property-binding_to_attribute"
    /// </rule>
    /// <rule language="OCL">
    ///   A derived union is derived.
    ///   <![CDATA[
    ///     isDerivedUnion implies isDerived
    ///   ]]>
    ///   xmi:id="Property-derived_union_is_derived"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="Property"/> can be a <see cref="DeploymentTarget"/> if it is a kind of <see cref="Node"/> and functions as a part in the internal structure of an encompassing <see cref="Node"/>.
    ///   <![CDATA[
    ///     deployment->notEmpty() implies owner.oclIsKindOf(Node) and Node.allInstances()->exists(n | n.part->exists(p | p = self))
    ///   ]]>
    ///   xmi:id="Property-deployment_target"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="Property"/> may not subset a <see cref="Property"/> with the same name.
    ///   <![CDATA[
    ///     subsettedProperty->forAll(sp | sp.name <> name)
    ///   ]]>
    ///   xmi:id="Property-subsetted_property_names"
    /// </rule>
    /// <rule language="OCL">
    ///   If a <see cref="Property"/> is a classifier-owned end of a binary <see cref="Association"/>, its owner must be the type of the opposite end.
    ///   <![CDATA[
    ///     (opposite->notEmpty() and owningAssociation->isEmpty()) implies classifier = opposite.type
    ///   ]]>
    ///   xmi:id="Property-type_of_opposite_end"
    /// </rule>
    /// <rule language="OCL">
    ///   All qualified Properties must be <see cref="Association"/> ends
    ///   <![CDATA[
    ///     qualifier->notEmpty() implies association->notEmpty()
    ///   ]]>
    ///   xmi:id="Property-qualified_is_association_end"
    /// </rule>
    /// xmi:id="Property"
    public interface Property : ConnectableElement,StructuralFeature,DeploymentTarget
        {
        #region P:Aggregation:AggregationKind
        /// <summary>
        /// Specifies the kind of <see cref="Aggregation"/> that applies to the <see cref="Property"/>.
        /// </summary>
        /// xmi:id="Property-aggregation"
        AggregationKind Aggregation { get;set; }
        #endregion
        #region P:Association:Association
        /// <summary>
        /// The <see cref="Association"/> of which this <see cref="Property"/> is a member, if any.
        /// Subsets:
        /// </summary>
        /// xmi:id="Property-association"
        /// xmi:association="A_memberEnd_association"
        /// xmi:subsets="A_member_memberNamespace-memberNamespace"
        [Multiplicity("0..1")]
        Association Association { get;set; }
        #endregion
        #region P:AssociationEnd:Property
        /// <summary>
        /// Designates the optional <see cref="Association"/> <see cref="End"/> that owns a <see cref="Qualifier"/> attribute.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.Owner"/>"
        /// </summary>
        /// xmi:id="Property-associationEnd"
        /// xmi:association="A_qualifier_associationEnd"
        [Multiplicity("0..1")]
        Property AssociationEnd { get;set; }
        #endregion
        #region P:Class:Class
        /// <summary>
        /// The <see cref="Class"/> that owns this <see cref="Property"/>, if any.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        /// </summary>
        /// xmi:id="Property-class"
        /// xmi:association="A_ownedAttribute_class"
        /// xmi:subsets="A_attribute_classifier-classifier"
        /// xmi:subsets="A_ownedAttribute_structuredClassifier-structuredClassifier"
        [Multiplicity("0..1")]
        Class Class { get;set; }
        #endregion
        #region P:Datatype:DataType
        /// <summary>
        /// The <see cref="DataType"/> that owns this <see cref="Property"/>, if any.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        /// </summary>
        /// xmi:id="Property-datatype"
        /// xmi:association="A_ownedAttribute_datatype"
        /// xmi:subsets="A_attribute_classifier-classifier"
        [Multiplicity("0..1")]
        DataType Datatype { get;set; }
        #endregion
        #region P:DefaultValue:ValueSpecification
        /// <summary>
        /// A <see cref="ValueSpecification"/> that is evaluated to give a default value for the <see cref="Property"/> when an instance of the owning <see cref="Classifier"/> is instantiated.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Property-defaultValue"
        /// xmi:aggregation="composite"
        /// xmi:association="A_defaultValue_owningProperty"
        [Multiplicity("0..1")]
        ValueSpecification DefaultValue { get;set; }
        #endregion
        #region P:Interface:Interface
        /// <summary>
        /// The <see cref="Interface"/> that owns this <see cref="Property"/>, if any.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        /// </summary>
        /// xmi:id="Property-interface"
        /// xmi:association="A_ownedAttribute_interface"
        /// xmi:subsets="A_attribute_classifier-classifier"
        [Multiplicity("0..1")]
        Interface Interface { get;set; }
        #endregion
        #region P:IsComposite:Boolean
        /// <summary>
        /// If <see cref="IsComposite"/> is true, the object containing the attribute is a container for the object or value contained in the attribute. This is a derived value, indicating whether the <see cref="Aggregation"/> of the <see cref="Property"/> is composite or not.
        /// </summary>
        /// xmi:id="Property-isComposite"
        /// xmi:is-derived="true"
        Boolean IsComposite { get;set; }
        #endregion
        #region P:IsDerived:Boolean
        /// <summary>
        /// Specifies whether the <see cref="Property"/> is derived, i.e., whether its value or values can be computed from other information.
        /// </summary>
        /// xmi:id="Property-isDerived"
        Boolean IsDerived { get;set; }
        #endregion
        #region P:IsDerivedUnion:Boolean
        /// <summary>
        /// Specifies whether the property is derived as the union of all of the Properties that are constrained to subset it.
        /// </summary>
        /// xmi:id="Property-isDerivedUnion"
        Boolean IsDerivedUnion { get;set; }
        #endregion
        #region P:IsID:Boolean
        /// <summary>
        /// True indicates this property can be used to uniquely identify an instance of the containing <see cref="Class"/>.
        /// </summary>
        /// xmi:id="Property-isID"
        Boolean IsID { get;set; }
        #endregion
        #region P:Opposite:Property
        /// <summary>
        /// In the case where the <see cref="Property"/> is one <see cref="End"/> of a binary <see cref="Association"/> this gives the other <see cref="End"/>.
        /// </summary>
        /// xmi:id="Property-opposite"
        /// xmi:association="A_opposite_property"
        /// xmi:is-derived="true"
        [Multiplicity("0..1")]
        Property Opposite { get;set; }
        #endregion
        #region P:OwningAssociation:Association
        /// <summary>
        /// The owning <see cref="Association"/> of this property, if any.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Feature.FeaturingClassifier"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Property.Association"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.RedefinitionContext"/>"
        /// </summary>
        /// xmi:id="Property-owningAssociation"
        /// xmi:association="A_ownedEnd_owningAssociation"
        [Multiplicity("0..1")]
        Association OwningAssociation { get;set; }
        #endregion
        #region P:Qualifier:IList<Property>
        /// <summary>
        /// An optional list of ordered <see cref="Qualifier"/> attributes for the <see cref="End"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Property-qualifier"
        /// xmi:aggregation="composite"
        /// xmi:association="A_qualifier_associationEnd"
        [Ordered]
        IList<Property> Qualifier { get; }
        #endregion
        #region P:RedefinedProperty:IList<Property>
        /// <summary>
        /// The properties that are redefined by this property, if any.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.RedefinedElement"/>"
        /// </summary>
        /// xmi:id="Property-redefinedProperty"
        /// xmi:association="A_redefinedProperty_property"
        IList<Property> RedefinedProperty { get; }
        #endregion
        #region P:SubsettedProperty:IList<Property>
        /// <summary>
        /// The properties of which this <see cref="Property"/> is constrained to be a subset, if any.
        /// </summary>
        /// xmi:id="Property-subsettedProperty"
        /// xmi:association="A_subsettedProperty_property"
        IList<Property> SubsettedProperty { get; }
        #endregion

        #region M:isAttribute:Boolean
        /// <summary>
        /// The query <see cref="isAttribute"/> is true if the <see cref="Property"/> is defined as an attribute of some <see cref="Classifier"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (not classifier->isEmpty())
        ///   ]]>
        ///   xmi:id="Property-isAttribute-spec"
        /// </rule>
        /// xmi:id="Property-isAttribute"
        /// xmi:is-query="true"
        Boolean isAttribute();
        #endregion
        #region M:isCompatibleWith(ParameterableElement):Boolean
        /// <summary>
        /// The query <see cref="isCompatibleWith"/> determines if this <see cref="Property"/> is compatible with the specified <see cref="ParameterableElement"/>. This <see cref="Property"/> is compatible with <see cref="ParameterableElement"/> p if the kind of this <see cref="Property"/> is thesame as or a subtype of the kind of p. Further, if p is a <see cref="TypedElement"/>, then the <see cref="Type"/> of this <see cref="Property"/> must be conformant with the <see cref="Type"/> of p.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.ParameterableElement.isCompatibleWith"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.oclIsKindOf(p.oclType()) and (p.oclIsKindOf(TypeElement) implies
        ///     self.type.conformsTo(p.oclAsType(TypedElement).type)))
        ///   ]]>
        ///   xmi:id="Property-isCompatibleWith-spec"
        /// </rule>
        /// xmi:id="Property-isCompatibleWith"
        /// xmi:is-query="true"
        Boolean isCompatibleWith(ParameterableElement p);
        #endregion
        #region M:isComposite:Boolean
        /// <summary>
        /// The value of <see cref="IsComposite"/> is true only if <see cref="Aggregation"/> is composite.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (aggregation = AggregationKind::composite)
        ///   ]]>
        ///   xmi:id="Property-isComposite.1-spec"
        /// </rule>
        /// xmi:id="Property-isComposite.1"
        /// xmi:is-query="true"
        Boolean isComposite();
        #endregion
        #region M:isConsistentWith(RedefinableElement):Boolean
        /// <summary>
        /// The query <see cref="isConsistentWith"/> specifies, for any two Properties in a context in which redefinition is possible, whether redefinition would be logically consistent. A redefining <see cref="Property"/> is consistent with a redefined <see cref="Property"/> if the <see cref="Type"/> of the redefining <see cref="Property"/> conforms to the <see cref="Type"/> of the redefined <see cref="Property"/>, and the multiplicity of the redefining <see cref="Property"/> (if specified) is contained in the multiplicity of the redefined <see cref="Property"/>.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.isConsistentWith"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     redefiningElement.isRedefinitionContextValid(self)
        ///   ]]>
        ///   xmi:id="Property-isConsistentWith-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (redefiningElement.oclIsKindOf(Property) and 
        ///       let prop : Property = redefiningElement.oclAsType(Property) in 
        ///       (prop.type.conformsTo(self.type) and 
        ///       ((prop.lowerBound()->notEmpty() and self.lowerBound()->notEmpty()) implies prop.lowerBound() >= self.lowerBound()) and 
        ///       ((prop.upperBound()->notEmpty() and self.upperBound()->notEmpty()) implies prop.lowerBound() <= self.lowerBound()) and 
        ///       (self.isComposite implies prop.isComposite)))
        ///   ]]>
        ///   xmi:id="Property-isConsistentWith-spec"
        /// </rule>
        /// xmi:id="Property-isConsistentWith"
        /// xmi:is-query="true"
        Boolean isConsistentWith(RedefinableElement redefiningElement);
        #endregion
        #region M:isNavigable:Boolean
        /// <summary>
        /// The query <see cref="isNavigable"/> indicates whether it is possible to navigate across the property.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (not classifier->isEmpty() or association.navigableOwnedEnd->includes(self))
        ///   ]]>
        ///   xmi:id="Property-isNavigable-spec"
        /// </rule>
        /// xmi:id="Property-isNavigable"
        /// xmi:is-query="true"
        Boolean isNavigable();
        #endregion
        #region M:opposite:Property
        /// <summary>
        /// If this property is a memberEnd of a binary <see cref="Association"/>, then <see cref="Opposite"/> gives the other <see cref="End"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if association <> null and association.memberEnd->size() = 2
        ///     then
        ///         association.memberEnd->any(e | e <> self)
        ///     else
        ///         null
        ///     endif)
        ///   ]]>
        ///   xmi:id="Property-opposite.1-spec"
        /// </rule>
        /// xmi:id="Property-opposite.1"
        /// xmi:is-query="true"
        Property opposite();
        #endregion
        #region M:subsettingContext:Type[]
        /// <summary>
        /// The query <see cref="subsettingContext"/> gives the context for subsetting a <see cref="Property"/>. It consists, in the case of an attribute, of the corresponding <see cref="Classifier"/>, and in the case of an <see cref="Association"/> <see cref="End"/>, all of the Classifiers at the other ends.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if association <> null
        ///     then association.memberEnd->excluding(self)->collect(type)->asSet()
        ///     else 
        ///       if classifier<>null
        ///       then classifier->asSet()
        ///       else Set{} 
        ///       endif
        ///     endif)
        ///   ]]>
        ///   xmi:id="Property-subsettingContext-spec"
        /// </rule>
        /// xmi:id="Property-subsettingContext"
        /// xmi:is-query="true"
        Type[] subsettingContext();
        #endregion
        }
    }
