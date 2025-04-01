using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="Behavior"/> is a <see cref="Specification"/> of how its <see cref="Context"/> <see cref="BehavioredClassifier"/> changes state over time. This <see cref="Specification"/> may be either a definition of possible behavior execution or emergent behavior, or a selective illustration of an interesting subset of possible executions. The latter form is typically used for capturing examples, such as a trace of a particular execution.
    /// </summary>
    /// <rule language="OCL">
    ///   There may be at most one <see cref="Behavior"/> for a given pairing of <see cref="BehavioredClassifier"/> (as owner of the <see cref="Behavior"/>) and <see cref="BehavioralFeature"/> (as specification of the <see cref="Behavior"/>).
    ///   <![CDATA[
    ///     specification <> null implies _'context'.ownedBehavior->select(specification=self.specification)->size() = 1
    ///   ]]>
    ///   xmi:id="Behavior-most_one_behavior"
    /// </rule>
    /// <rule language="OCL">
    ///   If a <see cref="Behavior"/> has a specification <see cref="BehavioralFeature"/>, then it must have the same number of ownedParameters as its specification. The <see cref="Behavior"/> Parameters must also "match" the BehavioralParameter Parameters, but the exact requirements for this matching are not formalized.
    ///   <![CDATA[
    ///     specification <> null implies ownedParameter->size() = specification.ownedParameter->size()
    ///   ]]>
    ///   xmi:id="Behavior-parameters_match"
    /// </rule>
    /// <rule language="OCL">
    ///   The specification <see cref="BehavioralFeature"/> must be a feature (possibly inherited) of the context <see cref="BehavioredClassifier"/> of the <see cref="Behavior"/>.
    ///   <![CDATA[
    ///     _'context'.feature->includes(specification)
    ///   ]]>
    ///   xmi:id="Behavior-feature_of_context_classifier"
    /// </rule>
    /// xmi:id="Behavior"
    public interface Behavior : Class
        {
        #region P:Context:BehavioredClassifier
        /// <summary>
        /// The <see cref="BehavioredClassifier"/> that is the <see cref="Context"/> for the execution of the <see cref="Behavior"/>. A <see cref="Behavior"/> that is directly owned as a <see cref="NestedClassifier"/> does not have a <see cref="Context"/>. Otherwise, to determine the <see cref="Context"/> of a <see cref="Behavior"/>, find the first <see cref="BehavioredClassifier"/> reached by following the chain of <see cref="Owner"/> relationships from the <see cref="Behavior"/>, if any. If there is such a <see cref="BehavioredClassifier"/>, then it is the <see cref="Context"/>, unless it is itself a <see cref="Behavior"/> with a non-empty <see cref="Context"/>, in which case that is also the <see cref="Context"/> for the original <see cref="Behavior"/>. For example, following this algorithm, the <see cref="Context"/> of an entry <see cref="Behavior"/> in a <see cref="StateMachine"/> is the <see cref="BehavioredClassifier"/> that owns the <see cref="StateMachine"/>. The features of the <see cref="Context"/> <see cref="BehavioredClassifier"/> as well as the Elements visible to the <see cref="Context"/> <see cref="Classifier"/> are visible to the <see cref="Behavior"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.RedefinitionContext"/>"
        /// </summary>
        /// xmi:id="Behavior-context"
        /// xmi:association="A_context_behavior"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        [Multiplicity("0..1")]
        BehavioredClassifier Context { get; }
        #endregion
        #region P:IsReentrant:Boolean
        /// <summary>
        /// Tells whether the <see cref="Behavior"/> can be invoked while it is still executing from a previous invocation.
        /// </summary>
        /// xmi:id="Behavior-isReentrant"
        Boolean IsReentrant { get;set; }
        #endregion
        #region P:OwnedParameter:IList<Parameter>
        /// <summary>
        /// References a list of Parameters to the <see cref="Behavior"/> which describes the order and type of arguments that can be given when the <see cref="Behavior"/> is invoked and of the values which will be returned when the <see cref="Behavior"/> completes its execution.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Behavior-ownedParameter"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedParameter_behavior"
        [Ordered]
        IList<Parameter> OwnedParameter { get; }
        #endregion
        #region P:OwnedParameterSet:IList<ParameterSet>
        /// <summary>
        /// The ParameterSets owned by this <see cref="Behavior"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Behavior-ownedParameterSet"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedParameterSet_behavior"
        IList<ParameterSet> OwnedParameterSet { get; }
        #endregion
        #region P:Postcondition:IList<Constraint>
        /// <summary>
        /// An optional set of Constraints specifying what is fulfilled after the execution of the <see cref="Behavior"/> is completed, if its <see cref="Precondition"/> was fulfilled before its invocation.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedRule"/>"
        /// </summary>
        /// xmi:id="Behavior-postcondition"
        /// xmi:aggregation="composite"
        /// xmi:association="A_postcondition_behavior"
        IList<Constraint> Postcondition { get; }
        #endregion
        #region P:Precondition:IList<Constraint>
        /// <summary>
        /// An optional set of Constraints specifying what must be fulfilled before the <see cref="Behavior"/> is invoked.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedRule"/>"
        /// </summary>
        /// xmi:id="Behavior-precondition"
        /// xmi:aggregation="composite"
        /// xmi:association="A_precondition_behavior"
        IList<Constraint> Precondition { get; }
        #endregion
        #region P:RedefinedBehavior:IList<Behavior>
        /// <summary>
        /// References the <see cref="Behavior"/> that this <see cref="Behavior"/> redefines. A subtype of <see cref="Behavior"/> may redefine any other subtype of <see cref="Behavior"/>. If the <see cref="Behavior"/> implements a <see cref="BehavioralFeature"/>, it replaces the redefined <see cref="Behavior"/>. If the <see cref="Behavior"/> is a <see cref="ClassifierBehavior"/>, it extends the redefined <see cref="Behavior"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.RedefinedClassifier"/>"
        /// </summary>
        /// xmi:id="Behavior-redefinedBehavior"
        /// xmi:association="A_redefinedBehavior_behavior"
        IList<Behavior> RedefinedBehavior { get; }
        #endregion
        #region P:Specification:BehavioralFeature
        /// <summary>
        /// Designates a <see cref="BehavioralFeature"/> that the <see cref="Behavior"/> implements. The <see cref="BehavioralFeature"/> must be owned by the <see cref="BehavioredClassifier"/> that owns the <see cref="Behavior"/> or be inherited by it. The Parameters of the <see cref="BehavioralFeature"/> and the implementing <see cref="Behavior"/> must match. A <see cref="Behavior"/> does not need to have a <see cref="Specification"/>, in which case it either is the <see cref="ClassifierBehavior"/> of a <see cref="BehavioredClassifier"/> or it can only be invoked by another <see cref="Behavior"/> of the <see cref="Classifier"/>.
        /// </summary>
        /// xmi:id="Behavior-specification"
        /// xmi:association="A_method_specification"
        [Multiplicity("0..1")]
        BehavioralFeature Specification { get;set; }
        #endregion

        #region M:behavioredClassifier(Element):BehavioredClassifier
        /// <summary>
        /// The first <see cref="BehavioredClassifier"/> reached by following the chain of <see cref="Owner"/> relationships from the <see cref="Behavior"/>, if any.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     if from.oclIsKindOf(BehavioredClassifier) then
        ///         from.oclAsType(BehavioredClassifier)
        ///     else if from.owner = null then
        ///         null
        ///     else
        ///         self.behavioredClassifier(from.owner)
        ///     endif
        ///     endif
        ///         
        ///   ]]>
        ///   xmi:id="Behavior-behavioredClassifier-spec"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// xmi:id="Behavior-behavioredClassifier"
        /// xmi:is-query="true"
        [return: Multiplicity("0..1")]
        BehavioredClassifier behavioredClassifier(Element from);
        #endregion
        #region M:context:BehavioredClassifier
        /// <summary>
        /// A <see cref="Behavior"/> that is directly owned as a <see cref="NestedClassifier"/> does not have a <see cref="Context"/>. Otherwise, to determine the <see cref="Context"/> of a <see cref="Behavior"/>, find the first <see cref="BehavioredClassifier"/> reached by following the chain of <see cref="Owner"/> relationships from the <see cref="Behavior"/>, if any. If there is such a <see cref="BehavioredClassifier"/>, then it is the <see cref="Context"/>, unless it is itself a <see cref="Behavior"/> with a non-empty <see cref="Context"/>, in which case that is also the <see cref="Context"/> for the original <see cref="Behavior"/>. 
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if nestingClass <> null then
        ///         null
        ///     else
        ///         let b:BehavioredClassifier = self.behavioredClassifier(self.owner) in
        ///         if b.oclIsKindOf(Behavior) and b.oclAsType(Behavior)._'context' <> null then 
        ///             b.oclAsType(Behavior)._'context'
        ///         else 
        ///             b 
        ///         endif
        ///     endif
        ///             )
        ///   ]]>
        ///   xmi:id="Behavior-context.1-spec"
        /// </rule>
        /// xmi:id="Behavior-context.1"
        /// xmi:is-query="true"
        [return: Multiplicity("0..1")]
        BehavioredClassifier context();
        #endregion
        #region M:inputParameters:Parameter[]
        /// <summary>
        /// The in and inout ownedParameters of the <see cref="Behavior"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (ownedParameter->select(direction=ParameterDirectionKind::_'in' or direction=ParameterDirectionKind::inout))
        ///   ]]>
        ///   xmi:id="Behavior-inputParameters-spec"
        /// </rule>
        /// xmi:id="Behavior-inputParameters"
        /// xmi:is-query="true"
        Parameter[] inputParameters();
        #endregion
        #region M:outputParameters:Parameter[]
        /// <summary>
        /// The out, inout and return ownedParameters.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (ownedParameter->select(direction=ParameterDirectionKind::out or direction=ParameterDirectionKind::inout or direction=ParameterDirectionKind::return))
        ///   ]]>
        ///   xmi:id="Behavior-outputParameters-spec"
        /// </rule>
        /// xmi:id="Behavior-outputParameters"
        /// xmi:is-query="true"
        Parameter[] outputParameters();
        #endregion
        }
    }
