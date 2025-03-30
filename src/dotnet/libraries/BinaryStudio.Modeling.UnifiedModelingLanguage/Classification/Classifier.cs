using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Classifier"/> represents a classification of instances according to their Features.
    /// </summary>
    /// <rule language="OCL">
    ///   A <see cref="Classifier"/> may only specialize Classifiers of a valid type.
    ///   <![CDATA[
    ///     parents()->forAll(c | self.maySpecializeType(c))
    ///   ]]>
    ///   xmi:id="Classifier-specialize_type"
    /// </rule>
    /// <rule language="OCL">
    ///   The <see cref="Classifier"/> that maps to a <see cref="GeneralizationSet"/> may neither be a specific nor a general <see cref="Classifier"/> in any of the <see cref="Generalization"/> relationships defined for that <see cref="GeneralizationSet"/>. In other words, a power type may not be an instance of itself nor may its instances also be its subclasses.
    ///   <![CDATA[
    ///     powertypeExtent->forAll( gs | 
    ///       gs.generalization->forAll( gen | 
    ///         not (gen.general = self) and not gen.general.allParents()->includes(self) and not (gen.specific = self) and not self.allParents()->includes(gen.specific) 
    ///       ))
    ///   ]]>
    ///   xmi:id="Classifier-maps_to_generalization_set"
    /// </rule>
    /// <rule language="OCL">
    ///   The parents of a <see cref="Classifier"/> must be non-final.
    ///   <![CDATA[
    ///     parents()->forAll(not isFinalSpecialization)
    ///   ]]>
    ///   xmi:id="Classifier-non_final_parents"
    /// </rule>
    /// <rule language="OCL">
    ///   <see cref="Generalization"/> hierarchies must be directed and acyclical. A <see cref="Classifier"/> can not be both a transitively general and transitively specific <see cref="Classifier"/> of the same <see cref="Classifier"/>.
    ///   <![CDATA[
    ///     not allParents()->includes(self)
    ///   ]]>
    ///   xmi:id="Classifier-no_cycles_in_generalization"
    /// </rule>
    /// xmi:id="Classifier"
    public interface Classifier : Namespace,Type,TemplateableElement,RedefinableElement
        {
        #region P:Attribute:Property[]
        /// <summary>
        /// All of the Properties that are direct (i.e., not inherited or imported) attributes of the <see cref="Classifier"/>.
        /// </summary>
        /// xmi:id="Classifier-attribute"
        Property[] Attribute { get; }
        #endregion
        #region P:CollaborationUse:CollaborationUse[]
        /// <summary>
        /// The CollaborationUses owned by the <see cref="Classifier"/>.
        /// </summary>
        /// xmi:id="Classifier-collaborationUse"
        /// xmi:aggregation="composite"
        CollaborationUse[] CollaborationUse { get; }
        #endregion
        #region P:Feature:Feature[]
        /// <summary>
        /// Specifies each <see cref="Feature"/> directly defined in the classifier. Note that there may be members of the <see cref="Classifier"/> that are of the type <see cref="Feature"/> but are not included, e.g., inherited features.
        /// </summary>
        /// xmi:id="Classifier-feature"
        Feature[] Feature { get; }
        #endregion
        #region P:General:Classifier[]
        /// <summary>
        /// The generalizing Classifiers for this <see cref="Classifier"/>.
        /// </summary>
        /// xmi:id="Classifier-general"
        Classifier[] General { get; }
        #endregion
        #region P:Generalization:Generalization[]
        /// <summary>
        /// The <see cref="Generalization"/> relationships for this <see cref="Classifier"/>. These Generalizations navigate to more <see cref="General"/> Classifiers in the <see cref="Generalization"/> hierarchy.
        /// </summary>
        /// xmi:id="Classifier-generalization"
        /// xmi:aggregation="composite"
        Generalization[] Generalization { get; }
        #endregion
        #region P:InheritedMember:NamedElement[]
        /// <summary>
        /// All elements inherited by this <see cref="Classifier"/> from its <see cref="General"/> Classifiers.
        /// </summary>
        /// xmi:id="Classifier-inheritedMember"
        NamedElement[] InheritedMember { get; }
        #endregion
        #region P:IsAbstract:Boolean
        /// <summary>
        /// If true, the <see cref="Classifier"/> can only be instantiated by instantiating one of its specializations. An abstract <see cref="Classifier"/> is intended to be used by other Classifiers e.g., as the target of Associations or Generalizations.
        /// </summary>
        /// xmi:id="Classifier-isAbstract"
        Boolean IsAbstract { get; }
        #endregion
        #region P:IsFinalSpecialization:Boolean
        /// <summary>
        /// If true, the <see cref="Classifier"/> cannot be specialized.
        /// </summary>
        /// xmi:id="Classifier-isFinalSpecialization"
        Boolean IsFinalSpecialization { get; }
        #endregion
        #region P:OwnedTemplateSignature:RedefinableTemplateSignature
        /// <summary>
        /// The optional <see cref="RedefinableTemplateSignature"/> specifying the formal template parameters.
        /// </summary>
        /// xmi:id="Classifier-ownedTemplateSignature"
        /// xmi:aggregation="composite"
        /// xmi:redefines="TemplateableElement-ownedTemplateSignature{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.TemplateableElement.OwnedTemplateSignature"/>}"
        RedefinableTemplateSignature OwnedTemplateSignature { get; }
        #endregion
        #region P:OwnedUseCase:UseCase[]
        /// <summary>
        /// The UseCases owned by this classifier.
        /// </summary>
        /// xmi:id="Classifier-ownedUseCase"
        /// xmi:aggregation="composite"
        UseCase[] OwnedUseCase { get; }
        #endregion
        #region P:PowertypeExtent:GeneralizationSet[]
        /// <summary>
        /// The <see cref="GeneralizationSet"/> of which this <see cref="Classifier"/> is a power type.
        /// </summary>
        /// xmi:id="Classifier-powertypeExtent"
        GeneralizationSet[] PowertypeExtent { get; }
        #endregion
        #region P:RedefinedClassifier:Classifier[]
        /// <summary>
        /// The Classifiers redefined by this <see cref="Classifier"/>.
        /// </summary>
        /// xmi:id="Classifier-redefinedClassifier"
        Classifier[] RedefinedClassifier { get; }
        #endregion
        #region P:Representation:CollaborationUse
        /// <summary>
        /// A <see cref="CollaborationUse"/> which indicates the <see cref="Collaboration"/> that represents this <see cref="Classifier"/>.
        /// </summary>
        /// xmi:id="Classifier-representation"
        CollaborationUse Representation { get; }
        #endregion
        #region P:Substitution:Substitution[]
        /// <summary>
        /// The Substitutions owned by this <see cref="Classifier"/>.
        /// </summary>
        /// xmi:id="Classifier-substitution"
        /// xmi:aggregation="composite"
        Substitution[] Substitution { get; }
        #endregion
        #region P:TemplateParameter:ClassifierTemplateParameter
        /// <summary>
        /// TheClassifierTemplateParameter that exposes this element as a formal parameter.
        /// </summary>
        /// xmi:id="Classifier-templateParameter"
        /// xmi:redefines="ParameterableElement-templateParameter{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.ParameterableElement.TemplateParameter"/>}"
        ClassifierTemplateParameter TemplateParameter { get; }
        #endregion
        #region P:UseCase:UseCase[]
        /// <summary>
        /// The set of UseCases for which this <see cref="Classifier"/> is the subject.
        /// </summary>
        /// xmi:id="Classifier-useCase"
        UseCase[] UseCase { get; }
        #endregion

        #region M:allFeatures:Feature[]
        /// <summary>
        /// The query <see cref="allFeatures"/> gives all of the Features in the <see cref="Namespace"/> of the <see cref="Classifier"/>. In <see cref="General"/>, through mechanisms such as inheritance, this will be a larger set than <see cref="Feature"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (member->select(oclIsKindOf(Feature))->collect(oclAsType(Feature))->asSet())
        ///   ]]>
        ///   xmi:id="Classifier-allFeatures-spec"
        /// </rule>
        /// xmi:id="Classifier-allFeatures"
        /// xmi:is-query="true"
        Feature[] allFeatures();
        #endregion
        #region M:allParents:Classifier[]
        /// <summary>
        /// The query <see cref="allParents"/> gives all of the direct and indirect ancestors of a generalized <see cref="Classifier"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (parents()->union(parents()->collect(allParents())->asSet()))
        ///   ]]>
        ///   xmi:id="Classifier-allParents-spec"
        /// </rule>
        /// xmi:id="Classifier-allParents"
        /// xmi:is-query="true"
        Classifier[] allParents();
        #endregion
        #region M:conformsTo(Type):Boolean
        /// <summary>
        /// The query <see cref="conformsTo"/> gives true for a <see cref="Classifier"/> that defines a type that conforms to another. This is used, for example, in the specification of signature conformance for operations.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if other.oclIsKindOf(Classifier) then
        ///       let otherClassifier : Classifier = other.oclAsType(Classifier) in
        ///         self = otherClassifier or allParents()->includes(otherClassifier)
        ///     else
        ///       false
        ///     endif)
        ///   ]]>
        ///   xmi:id="Classifier-conformsTo-spec"
        /// </rule>
        /// xmi:id="Classifier-conformsTo"
        /// xmi:is-query="true"
        /// xmi:redefines="Type-conformsTo{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.Type.conformsTo"/>}"
        Boolean conformsTo(Type other);
        #endregion
        #region M:general:Classifier[]
        /// <summary>
        /// The <see cref="General"/> Classifiers are the ones referenced by the <see cref="Generalization"/> relationships.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (parents())
        ///   ]]>
        ///   xmi:id="Classifier-general.1-spec"
        /// </rule>
        /// xmi:id="Classifier-general.1"
        /// xmi:is-query="true"
        Classifier[] general();
        #endregion
        #region M:hasVisibilityOf(NamedElement):Boolean
        /// <summary>
        /// The query <see cref="hasVisibilityOf"/> determines whether a <see cref="NamedElement"/> is visible in the classifier. Non-private members are visible. It is only called when the argument is something owned by a parent.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     allParents()->including(self)->collect(member)->includes(n)
        ///   ]]>
        ///   xmi:id="Classifier-hasVisibilityOf-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (n.visibility <> VisibilityKind::private)
        ///   ]]>
        ///   xmi:id="Classifier-hasVisibilityOf-spec"
        /// </rule>
        /// xmi:id="Classifier-hasVisibilityOf"
        /// xmi:is-query="true"
        Boolean hasVisibilityOf(NamedElement n);
        #endregion
        #region M:inherit(NamedElement[]):NamedElement[]
        /// <summary>
        /// The query <see cref="inherit"/> defines how to inherit a set of elements passed as its argument.  It excludes redefined elements from the result.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (inhs->reject(inh |
        ///       inh.oclIsKindOf(RedefinableElement) and
        ///       ownedMember->select(oclIsKindOf(RedefinableElement))->
        ///         select(redefinedElement->includes(inh.oclAsType(RedefinableElement)))
        ///            ->notEmpty()))
        ///   ]]>
        ///   xmi:id="Classifier-inherit-spec"
        /// </rule>
        /// xmi:id="Classifier-inherit"
        /// xmi:is-query="true"
        NamedElement[] inherit(NamedElement[] inhs);
        #endregion
        #region M:inheritableMembers(Classifier):NamedElement[]
        /// <summary>
        /// The query <see cref="inheritableMembers"/> gives all of the members of a <see cref="Classifier"/> that may be inherited in one of its descendants, subject to whatever <see cref="Visibility"/> restrictions apply.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     c.allParents()->includes(self)
        ///   ]]>
        ///   xmi:id="Classifier-inheritableMembers-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (member->select(m | c.hasVisibilityOf(m)))
        ///   ]]>
        ///   xmi:id="Classifier-inheritableMembers-spec"
        /// </rule>
        /// xmi:id="Classifier-inheritableMembers"
        /// xmi:is-query="true"
        NamedElement[] inheritableMembers(Classifier c);
        #endregion
        #region M:inheritedMember:NamedElement[]
        /// <summary>
        /// The <see cref="InheritedMember"/> association is derived by inheriting the inheritable members of the parents.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (inherit(parents()->collect(inheritableMembers(self))->asSet()))
        ///   ]]>
        ///   xmi:id="Classifier-inheritedMember.1-spec"
        /// </rule>
        /// xmi:id="Classifier-inheritedMember.1"
        /// xmi:is-query="true"
        NamedElement[] inheritedMember();
        #endregion
        #region M:isTemplate:Boolean
        /// <summary>
        /// The query <see cref="isTemplate"/> returns whether this <see cref="Classifier"/> is actually a template.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (ownedTemplateSignature <> null or general->exists(g | g.isTemplate()))
        ///   ]]>
        ///   xmi:id="Classifier-isTemplate-spec"
        /// </rule>
        /// xmi:id="Classifier-isTemplate"
        /// xmi:is-query="true"
        /// xmi:redefines="TemplateableElement-isTemplate{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.TemplateableElement.isTemplate"/>}"
        Boolean isTemplate();
        #endregion
        #region M:maySpecializeType(Classifier):Boolean
        /// <summary>
        /// The query <see cref="maySpecializeType"/> determines whether this classifier may have a <see cref="Generalization"/> relationship to classifiers of the specified type. By default a classifier may specialize classifiers of the same or a more <see cref="General"/> type. It is intended to be redefined by classifiers that have different specialization constraints.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.oclIsKindOf(c.oclType()))
        ///   ]]>
        ///   xmi:id="Classifier-maySpecializeType-spec"
        /// </rule>
        /// xmi:id="Classifier-maySpecializeType"
        /// xmi:is-query="true"
        Boolean maySpecializeType(Classifier c);
        #endregion
        #region M:parents:Classifier[]
        /// <summary>
        /// The query <see cref="parents"/> gives all of the immediate ancestors of a generalized <see cref="Classifier"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (generalization.general->asSet())
        ///   ]]>
        ///   xmi:id="Classifier-parents-spec"
        /// </rule>
        /// xmi:id="Classifier-parents"
        /// xmi:is-query="true"
        Classifier[] parents();
        #endregion
        #region M:directlyRealizedInterfaces:Interface[]
        /// <summary>
        /// The Interfaces directly realized by this <see cref="Classifier"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = ((clientDependency->
        ///       select(oclIsKindOf(Realization) and supplier->forAll(oclIsKindOf(Interface))))->
        ///           collect(supplier.oclAsType(Interface))->asSet())
        ///   ]]>
        ///   xmi:id="Classifier-directlyRealizedInterfaces-spec"
        /// </rule>
        /// xmi:id="Classifier-directlyRealizedInterfaces"
        /// xmi:is-query="true"
        Interface[] directlyRealizedInterfaces();
        #endregion
        #region M:directlyUsedInterfaces:Interface[]
        /// <summary>
        /// The Interfaces directly used by this <see cref="Classifier"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = ((supplierDependency->
        ///       select(oclIsKindOf(Usage) and client->forAll(oclIsKindOf(Interface))))->
        ///         collect(client.oclAsType(Interface))->asSet())
        ///   ]]>
        ///   xmi:id="Classifier-directlyUsedInterfaces-spec"
        /// </rule>
        /// xmi:id="Classifier-directlyUsedInterfaces"
        /// xmi:is-query="true"
        Interface[] directlyUsedInterfaces();
        #endregion
        #region M:allRealizedInterfaces:Interface[]
        /// <summary>
        /// The Interfaces realized by this <see cref="Classifier"/> and all of its generalizations
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (directlyRealizedInterfaces()->union(self.allParents()->collect(directlyRealizedInterfaces()))->asSet())
        ///   ]]>
        ///   xmi:id="Classifier-allRealizedInterfaces-spec"
        /// </rule>
        /// xmi:id="Classifier-allRealizedInterfaces"
        /// xmi:is-query="true"
        Interface[] allRealizedInterfaces();
        #endregion
        #region M:allUsedInterfaces:Interface[]
        /// <summary>
        /// The Interfaces used by this <see cref="Classifier"/> and all of its generalizations
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (directlyUsedInterfaces()->union(self.allParents()->collect(directlyUsedInterfaces()))->asSet())
        ///   ]]>
        ///   xmi:id="Classifier-allUsedInterfaces-spec"
        /// </rule>
        /// xmi:id="Classifier-allUsedInterfaces"
        /// xmi:is-query="true"
        Interface[] allUsedInterfaces();
        #endregion
        #region M:isSubstitutableFor(Classifier):Boolean
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (substitution.contract->includes(contract))
        ///   ]]>
        ///   xmi:id="Classifier-isSubstitutableFor-spec"
        /// </rule>
        /// xmi:id="Classifier-isSubstitutableFor"
        /// xmi:is-query="true"
        Boolean isSubstitutableFor(Classifier contract);
        #endregion
        #region M:allAttributes:Property[]
        /// <summary>
        /// The query allAttributes gives an ordered set of all owned and inherited attributes of the <see cref="Classifier"/>. All owned attributes appear before any inherited attributes, and the attributes inherited from any more specific parent <see cref="Classifier"/> appear before those of any more <see cref="General"/> parent <see cref="Classifier"/>. However, if the <see cref="Classifier"/> has multiple immediate parents, then the relative ordering of the sets of attributes from those parents is not defined.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (attribute->asSequence()->union(parents()->asSequence().allAttributes())->select(p | member->includes(p))->asOrderedSet())
        ///   ]]>
        ///   xmi:id="Classifier-allAttributes-spec"
        /// </rule>
        /// xmi:id="Classifier-allAttributes"
        /// xmi:is-query="true"
        Property[] allAttributes();
        #endregion
        #region M:allSlottableFeatures:StructuralFeature[]
        /// <summary>
        /// All StructuralFeatures related to the <see cref="Classifier"/> that may have Slots, including direct attributes, inherited attributes, private attributes in generalizations, and memberEnds of Associations, but excluding redefined StructuralFeatures.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (member->select(oclIsKindOf(StructuralFeature))->
        ///       collect(oclAsType(StructuralFeature))->
        ///        union(self.inherit(self.allParents()->collect(p | p.attribute)->asSet())->
        ///          collect(oclAsType(StructuralFeature)))->asSet())
        ///   ]]>
        ///   xmi:id="Classifier-allSlottableFeatures-spec"
        /// </rule>
        /// xmi:id="Classifier-allSlottableFeatures"
        /// xmi:is-query="true"
        StructuralFeature[] allSlottableFeatures();
        #endregion
        }
    }
