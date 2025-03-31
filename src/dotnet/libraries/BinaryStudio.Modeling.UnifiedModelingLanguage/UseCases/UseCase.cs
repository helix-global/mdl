using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="UseCase"/> specifies a set of actions performed by its subjects, which yields an observable result that is of value for one or more Actors or other stakeholders of each <see cref="Subject"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   UseCases can only be involved in binary Associations.
    ///   <![CDATA[
    ///     Association.allInstances()->forAll(a | a.memberEnd.type->includes(self) implies a.memberEnd->size() = 2)
    ///   ]]>
    ///   xmi:id="UseCase-binary_associations"
    /// </rule>
    /// <rule language="OCL">
    ///   UseCases cannot have Associations to UseCases specifying the same subject.
    ///   <![CDATA[
    ///     Association.allInstances()->forAll(a | a.memberEnd.type->includes(self) implies 
    ///        (
    ///        let usecases: Set(UseCase) = a.memberEnd.type->select(oclIsKindOf(UseCase))->collect(oclAsType(UseCase))->asSet() in
    ///        usecases->size() > 1 implies usecases->collect(subject)->size() > 1
    ///        )
    ///     )
    ///   ]]>
    ///   xmi:id="UseCase-no_association_to_use_case"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="UseCase"/> cannot include UseCases that directly or indirectly include it.
    ///   <![CDATA[
    ///     not allIncludedUseCases()->includes(self)
    ///   ]]>
    ///   xmi:id="UseCase-cannot_include_self"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="UseCase"/> must have a name.
    ///   <![CDATA[
    ///     name -> notEmpty ()
    ///   ]]>
    ///   xmi:id="UseCase-must_have_name"
    /// </rule>
    /// xmi:id="UseCase"
    public interface UseCase : BehavioredClassifier
        {
        #region P:Extend:Extend[]
        /// <summary>
        /// The <see cref="Extend"/> relationships owned by this <see cref="UseCase"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="UseCase-extend"
        /// xmi:aggregation="composite"
        /// xmi:association="A_extend_extension"
        /// xmi:subsets="A_source_directedRelationship-directedRelationship"
        Extend[] Extend { get; }
        #endregion
        #region P:ExtensionPoint:ExtensionPoint[]
        /// <summary>
        /// The ExtensionPoints owned by this <see cref="UseCase"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="UseCase-extensionPoint"
        /// xmi:aggregation="composite"
        /// xmi:association="A_extensionPoint_useCase"
        ExtensionPoint[] ExtensionPoint { get; }
        #endregion
        #region P:Include:Include[]
        /// <summary>
        /// The <see cref="Include"/> relationships owned by this <see cref="UseCase"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="UseCase-include"
        /// xmi:aggregation="composite"
        /// xmi:association="A_include_includingCase"
        /// xmi:subsets="A_source_directedRelationship-directedRelationship"
        Include[] Include { get; }
        #endregion
        #region P:Subject:Classifier[]
        /// <summary>
        /// The subjects to which this <see cref="UseCase"/> applies. Each <see cref="Subject"/> or its parts realize all the UseCases that apply to it.
        /// </summary>
        /// xmi:id="UseCase-subject"
        /// xmi:association="A_subject_useCase"
        Classifier[] Subject { get; }
        #endregion

        #region M:allIncludedUseCases:UseCase[]
        /// <summary>
        /// The query <see cref="allIncludedUseCases"/> returns the transitive closure of all UseCases (directly or indirectly) included by this <see cref="UseCase"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.include.addition->union(self.include.addition->collect(uc | uc.allIncludedUseCases()))->asSet())
        ///   ]]>
        ///   xmi:id="UseCase-allIncludedUseCases-spec"
        /// </rule>
        /// xmi:id="UseCase-allIncludedUseCases"
        /// xmi:is-query="true"
        UseCase[] allIncludedUseCases();
        #endregion
        }
    }
