using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A link is a tuple of values that refer to typed objects.  An <see cref="Association"/> classifies a set of links, each of which is an instance of the <see cref="Association"/>.  Each value in the link refers to an instance of the type of the corresponding end of the <see cref="Association"/>.
    /// 
    /// </summary>
    /// <rule language="OCL">
    ///   An <see cref="Association"/> specializing another <see cref="Association"/> has the same number of ends as the other <see cref="Association"/>.
    ///   <![CDATA[
    ///     parents()->select(oclIsKindOf(Association)).oclAsType(Association)->forAll(p | p.memberEnd->size() = self.memberEnd->size())
    ///   ]]>
    ///   xmi:id="Association-specialized_end_number"
    /// </rule>
    /// <rule language="OCL">
    ///   When an <see cref="Association"/> specializes another <see cref="Association"/>, every end of the specific <see cref="Association"/> corresponds to an end of the general <see cref="Association"/>, and the specific end reaches the same type or a subtype of the corresponding general end.
    ///   <![CDATA[
    ///     Sequence{1..memberEnd->size()}->
    ///     	forAll(i | general->select(oclIsKindOf(Association)).oclAsType(Association)->
    ///     		forAll(ga | self.memberEnd->at(i).type.conformsTo(ga.memberEnd->at(i).type)))
    ///   ]]>
    ///   xmi:id="Association-specialized_end_types"
    /// </rule>
    /// <rule language="OCL">
    ///   Only binary Associations can be aggregations.
    ///   <![CDATA[
    ///     memberEnd->exists(aggregation <> AggregationKind::none) implies (memberEnd->size() = 2 and memberEnd->exists(aggregation = AggregationKind::none))
    ///   ]]>
    ///   xmi:id="Association-binary_associations"
    /// </rule>
    /// <rule language="OCL">
    ///   Ends of Associations with more than two ends must be owned by the <see cref="Association"/> itself.
    ///   <![CDATA[
    ///     memberEnd->size() > 2 implies ownedEnd->includesAll(memberEnd)
    ///   ]]>
    ///   xmi:id="Association-association_ends"
    /// </rule>
    /// <rule language="OCL">
    ///   <![CDATA[
    ///     memberEnd->forAll(type->notEmpty())
    ///   ]]>
    ///   xmi:id="Association-ends_must_be_typed"
    /// </rule>
    /// xmi:id="Association"
    public interface Association : Relationship,Classifier
        {
        #region P:EndType:IList<Type>
        /// <summary>
        /// The Classifiers that are used as types of the ends of the <see cref="Association"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Relationship.RelatedElement"/>"
        /// </summary>
        /// xmi:id="Association-endType"
        /// xmi:association="A_endType_association"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        [Multiplicity("1..*")]
        IList<Type> EndType { get; }
        #endregion
        #region P:IsDerived:Boolean
        /// <summary>
        /// Specifies whether the <see cref="Association"/> is derived from other model elements such as other Associations.
        /// </summary>
        /// xmi:id="Association-isDerived"
        Boolean IsDerived { get;set; }
        #endregion
        #region P:MemberEnd:IList<Property>
        /// <summary>
        /// Each end represents participation of instances of the <see cref="Classifier"/> connected to the end in links of the <see cref="Association"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.Member"/>"
        /// </summary>
        /// xmi:id="Association-memberEnd"
        /// xmi:association="A_memberEnd_association"
        [Multiplicity("2..*")][Ordered]
        IList<Property> MemberEnd { get; }
        #endregion
        #region P:NavigableOwnedEnd:IList<Property>
        /// <summary>
        /// The navigable ends that are owned by the <see cref="Association"/> itself.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Association.OwnedEnd"/>"
        /// </summary>
        /// xmi:id="Association-navigableOwnedEnd"
        /// xmi:association="A_navigableOwnedEnd_association"
        IList<Property> NavigableOwnedEnd { get; }
        #endregion
        #region P:OwnedEnd:IList<Property>
        /// <summary>
        /// The ends that are owned by the <see cref="Association"/> itself.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Association.MemberEnd"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.Feature"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Association-ownedEnd"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedEnd_owningAssociation"
        /// xmi:subsets="A_redefinitionContext_redefinableElement-redefinableElement"
        [Ordered]
        IList<Property> OwnedEnd { get; }
        #endregion

        #region M:endType:Type[]
        /// <summary>
        /// <see cref="EndType"/> is derived from the types of the <see cref="Member"/> ends.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (memberEnd->collect(type)->asSet())
        ///   ]]>
        ///   xmi:id="Association-endType.1-spec"
        /// </rule>
        /// xmi:id="Association-endType.1"
        /// xmi:is-query="true"
        [return: Multiplicity("1..*")]
        Type[] endType();
        #endregion
        }
    }
