using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Lifeline"/> <see cref="Represents"/> an individual participant in the <see cref="Interaction"/>. While parts and structural features may have multiplicity greater than 1, Lifelines represent only one interacting entity.
    /// </summary>
    /// <rule language="OCL">
    ///   The selector for a <see cref="Lifeline"/> must only be specified if the referenced Part is multivalued.
    ///   <![CDATA[
    ///      self.selector->notEmpty() = (self.represents.oclIsKindOf(MultiplicityElement) and self.represents.oclAsType(MultiplicityElement).isMultivalued())
    ///   ]]>
    ///   xmi:id="Lifeline-selector_specified"
    /// </rule>
    /// <rule language="OCL">
    ///   If a lifeline is in an <see cref="Interaction"/> referred to by an <see cref="InteractionUse"/> in an enclosing <see cref="Interaction"/>,  and that lifeline is common with another lifeline in an <see cref="Interaction"/> referred to by another InteractonUse within that same enclosing <see cref="Interaction"/>, it must be common to a lifeline within that enclosing <see cref="Interaction"/>. By common Lifelines we mean Lifelines with the same selector and represents associations.
    ///   
    ///   <![CDATA[
    ///     let intUses : Set(InteractionUse) = interaction.interactionUse  in 
    ///     intUses->forAll
    ///     ( iuse : InteractionUse | 
    ///     let usingInteraction : Set(Interaction)  = iuse.enclosingInteraction->asSet()
    ///     ->union(
    ///     iuse.enclosingOperand.combinedFragment->asSet()->closure(enclosingOperand.combinedFragment).enclosingInteraction->asSet()
    ///                    ) 
    ///     in
    ///     let peerUses : Set(InteractionUse) = usingInteraction.fragment->select(oclIsKindOf(InteractionUse)).oclAsType(InteractionUse)->asSet()
    ///     ->union(
    ///     usingInteraction.fragment->select(oclIsKindOf(CombinedFragment)).oclAsType(CombinedFragment)->asSet()
    ///     ->closure(operand.fragment->select(oclIsKindOf(CombinedFragment)).oclAsType(CombinedFragment)).operand.fragment->
    ///     select(oclIsKindOf(InteractionUse)).oclAsType(InteractionUse)->asSet()
    ///                    )->excluding(iuse)
    ///      in
    ///     peerUses->forAll( peerUse : InteractionUse |
    ///      peerUse.refersTo.lifeline->forAll( l : Lifeline | (l.represents = self.represents and 
    ///      ( self.selector.oclIsKindOf(LiteralString) implies
    ///       l.selector.oclIsKindOf(LiteralString) and 
    ///       self.selector.oclAsType(LiteralString).value = l.selector.oclAsType(LiteralString).value )
    ///       and 
    ///     ( self.selector.oclIsKindOf(LiteralInteger) implies
    ///       l.selector.oclIsKindOf(LiteralInteger) and 
    ///       self.selector.oclAsType(LiteralInteger).value = l.selector.oclAsType(LiteralInteger).value )
    ///     )  
    ///     implies
    ///      usingInteraction.lifeline->select(represents = self.represents and
    ///      ( self.selector.oclIsKindOf(LiteralString) implies
    ///       l.selector.oclIsKindOf(LiteralString) and 
    ///       self.selector.oclAsType(LiteralString).value = l.selector.oclAsType(LiteralString).value )
    ///     and 
    ///     ( self.selector.oclIsKindOf(LiteralInteger) implies
    ///       l.selector.oclIsKindOf(LiteralInteger) and 
    ///       self.selector.oclAsType(LiteralInteger).value = l.selector.oclAsType(LiteralInteger).value )
    ///     )
    ///                                                     )
    ///                         )
    ///     )
    ///   ]]>
    ///   xmi:id="Lifeline-interaction_uses_share_lifeline"
    /// </rule>
    /// <rule language="OCL">
    ///   The classifier containing the referenced <see cref="ConnectableElement"/> must be the same classifier, or an ancestor, of the classifier that contains the interaction enclosing this lifeline.
    ///   <![CDATA[
    ///     represents.namespace->closure(namespace)->includes(interaction._'context')
    ///   ]]>
    ///   xmi:id="Lifeline-same_classifier"
    /// </rule>
    /// <rule language="OCL">
    ///   The selector value, if present, must be a <see cref="LiteralString"/> or a <see cref="LiteralInteger"/> 
    ///   <![CDATA[
    ///     self.selector->notEmpty() implies 
    ///     self.selector.oclIsKindOf(LiteralInteger) or 
    ///     self.selector.oclIsKindOf(LiteralString)
    ///   ]]>
    ///   xmi:id="Lifeline-selector_int_or_string"
    /// </rule>
    /// xmi:id="Lifeline"
    public interface Lifeline : NamedElement
        {
        #region P:CoveredBy:InteractionFragment[]
        /// <summary>
        /// References the InteractionFragments in which this <see cref="Lifeline"/> takes part.
        /// </summary>
        /// xmi:id="Lifeline-coveredBy"
        InteractionFragment[] CoveredBy { get; }
        #endregion
        #region P:DecomposedAs:PartDecomposition
        /// <summary>
        /// References the <see cref="Interaction"/> that <see cref="Represents"/> the decomposition.
        /// </summary>
        /// xmi:id="Lifeline-decomposedAs"
        PartDecomposition DecomposedAs { get; }
        #endregion
        #region P:Interaction:Interaction
        /// <summary>
        /// References the <see cref="Interaction"/> enclosing this <see cref="Lifeline"/>.
        /// </summary>
        /// xmi:id="Lifeline-interaction"
        Interaction Interaction { get; }
        #endregion
        #region P:Represents:ConnectableElement
        /// <summary>
        /// References the <see cref="ConnectableElement"/> within the classifier that contains the enclosing <see cref="Interaction"/>.
        /// </summary>
        /// xmi:id="Lifeline-represents"
        ConnectableElement Represents { get; }
        #endregion
        #region P:Selector:ValueSpecification
        /// <summary>
        /// If the referenced <see cref="ConnectableElement"/> is multivalued, then this specifies the specific individual part within that set.
        /// </summary>
        /// xmi:id="Lifeline-selector"
        /// xmi:aggregation="composite"
        ValueSpecification Selector { get; }
        #endregion
        }
    }
