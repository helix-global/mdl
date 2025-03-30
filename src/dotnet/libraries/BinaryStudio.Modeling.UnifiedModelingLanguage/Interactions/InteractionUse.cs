using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="InteractionUse"/> refers to an <see cref="Interaction"/>. The <see cref="InteractionUse"/> is a shorthand for copying the contents of the referenced <see cref="Interaction"/> where the <see cref="InteractionUse"/> is. To be accurate the copying must take into account substituting parameters with arguments and connect the formal Gates with the actual ones.
    /// </summary>
    /// <rule language="OCL">
    ///   Actual Gates of the <see cref="InteractionUse"/> must match Formal Gates of the referred <see cref="Interaction"/>. Gates match when their names are equal and their messages correspond.
    ///   <![CDATA[
    ///     actualGate->notEmpty() implies 
    ///     refersTo.formalGate->forAll( fg : Gate | self.actualGate->select(matches(fg))->size()=1) and
    ///     self.actualGate->forAll(ag : Gate | refersTo.formalGate->select(matches(ag))->size()=1)
    ///   ]]>
    ///   xmi:id="InteractionUse-gates_match"
    /// </rule>
    /// <rule language="">
    ///   The arguments must only be constants, parameters of the enclosing <see cref="Interaction"/> or attributes of the classifier owning the enclosing <see cref="Interaction"/>.
    ///   xmi:id="InteractionUse-arguments_are_constants"
    /// </rule>
    /// <rule language="OCL">
    ///   The returnValueRecipient must be a <see cref="Property"/> of a <see cref="ConnectableElement"/> that is represented by a <see cref="Lifeline"/> covered by this <see cref="InteractionUse"/>.
    ///   <![CDATA[
    ///     returnValueRecipient->asSet()->notEmpty() implies
    ///     let covCE : Set(ConnectableElement) = covered.represents->asSet() in 
    ///     covCE->notEmpty() and let classes:Set(Classifier) = covCE.type.oclIsKindOf(Classifier).oclAsType(Classifier)->asSet() in 
    ///     let allProps : Set(Property) = classes.attribute->union(classes.allParents().attribute)->asSet() in 
    ///     allProps->includes(returnValueRecipient)
    ///   ]]>
    ///   xmi:id="InteractionUse-returnValueRecipient_coverage"
    /// </rule>
    /// <rule language="">
    ///   The arguments of the <see cref="InteractionUse"/> must correspond to parameters of the referred <see cref="Interaction"/>.
    ///   xmi:id="InteractionUse-arguments_correspond_to_parameters"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the returnValue must correspond to the type of the returnValueRecipient.
    ///   <![CDATA[
    ///     returnValue.type->asSequence()->notEmpty() implies returnValue.type->asSequence()->first() = returnValueRecipient.type->asSequence()->first()
    ///     
    ///   ]]>
    ///   xmi:id="InteractionUse-returnValue_type_recipient_correspondence"
    /// </rule>
    /// <rule language="OCL">
    ///   The <see cref="InteractionUse"/> must cover all Lifelines of the enclosing <see cref="Interaction"/> that are common with the lifelines covered by the referred <see cref="Interaction"/>. Lifelines are common if they have the same selector and represents associationEnd values.
    ///   <![CDATA[
    ///     let parentInteraction : Set(Interaction) = enclosingInteraction->asSet()->
    ///     union(enclosingOperand.combinedFragment->closure(enclosingOperand.combinedFragment)->
    ///     collect(enclosingInteraction).oclAsType(Interaction)->asSet()) in
    ///     parentInteraction->size()=1 and let refInteraction : Interaction = refersTo in
    ///     parentInteraction.covered-> forAll(intLifeline : Lifeline | refInteraction.covered->
    ///     forAll( refLifeline : Lifeline | refLifeline.represents = intLifeline.represents and 
    ///     (
    ///     ( refLifeline.selector.oclIsKindOf(LiteralString) implies
    ///       intLifeline.selector.oclIsKindOf(LiteralString) and 
    ///       refLifeline.selector.oclAsType(LiteralString).value = intLifeline.selector.oclAsType(LiteralString).value ) and
    ///     ( refLifeline.selector.oclIsKindOf(LiteralInteger) implies
    ///       intLifeline.selector.oclIsKindOf(LiteralInteger) and 
    ///       refLifeline.selector.oclAsType(LiteralInteger).value = intLifeline.selector.oclAsType(LiteralInteger).value )
    ///     )
    ///      implies self.covered->asSet()->includes(intLifeline)))
    ///   ]]>
    ///   xmi:id="InteractionUse-all_lifelines"
    /// </rule>
    /// xmi:id="InteractionUse"
    public interface InteractionUse : InteractionFragment
        {
        #region P:ActualGate:Gate[]
        /// <summary>
        /// The actual gates of the <see cref="InteractionUse"/>.
        /// </summary>
        /// xmi:id="InteractionUse-actualGate"
        /// xmi:aggregation="composite"
        Gate[] ActualGate { get; }
        #endregion
        #region P:Argument:ValueSpecification[]
        /// <summary>
        /// The actual arguments of the <see cref="Interaction"/>.
        /// </summary>
        /// xmi:id="InteractionUse-argument"
        /// xmi:aggregation="composite"
        ValueSpecification[] Argument { get; }
        #endregion
        #region P:RefersTo:Interaction
        /// <summary>
        /// Refers to the <see cref="Interaction"/> that defines its meaning.
        /// </summary>
        /// xmi:id="InteractionUse-refersTo"
        Interaction RefersTo { get; }
        #endregion
        #region P:ReturnValue:ValueSpecification
        /// <summary>
        /// The value of the executed <see cref="Interaction"/>.
        /// </summary>
        /// xmi:id="InteractionUse-returnValue"
        /// xmi:aggregation="composite"
        ValueSpecification ReturnValue { get; }
        #endregion
        #region P:ReturnValueRecipient:Property
        /// <summary>
        /// The recipient of the return value.
        /// </summary>
        /// xmi:id="InteractionUse-returnValueRecipient"
        Property ReturnValueRecipient { get; }
        #endregion
        }
    }
