using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="ObjectNode"/> is an abstract <see cref="ActivityNode"/> that may hold tokens within the object flow in an <see cref="Activity"/>. ObjectNodes also support token <see cref="Selection"/>, limitation on the number of tokens held, specification of the state required for tokens being held, and carrying control values.
    /// 
    /// </summary>
    /// <rule language="OCL">
    ///   A selection <see cref="Behavior"/> has one input <see cref="Parameter"/> and one output <see cref="Parameter"/>. The input <see cref="Parameter"/> must have the same type as  or a supertype of the type of <see cref="ObjectNode"/>, be non-unique, and have multiplicity 0..*. The output <see cref="Parameter"/> must be the same or a subtype of the type of <see cref="ObjectNode"/>. The <see cref="Behavior"/> cannot have side effects.
    ///   <![CDATA[
    ///     selection<>null implies
    ///     	selection.inputParameters()->size()=1 and
    ///     	selection.inputParameters()->forAll(p | not p.isUnique and p.is(0,*) and self.type.conformsTo(p.type)) and
    ///     	selection.outputParameters()->size()=1 and
    ///     		selection.inputParameters()->forAll(p | self.type.conformsTo(p.type))
    ///     	
    ///   ]]>
    ///   xmi:id="ObjectNode-input_output_parameter"
    /// </rule>
    /// <rule language="OCL">
    ///   If an <see cref="ObjectNode"/> has a selection <see cref="Behavior"/>, then the ordering of the object node is ordered, and vice versa.
    ///   <![CDATA[
    ///     (selection<>null) = (ordering=ObjectNodeOrderingKind::ordered)
    ///   ]]>
    ///   xmi:id="ObjectNode-selection_behavior"
    /// </rule>
    /// <rule language="OCL">
    ///   If isControlType=false, the ActivityEdges incoming to or outgoing from an <see cref="ObjectNode"/> must all be ObjectFlows.
    ///   <![CDATA[
    ///     (not isControlType) implies incoming->union(outgoing)->forAll(oclIsKindOf(ObjectFlow))
    ///   ]]>
    ///   xmi:id="ObjectNode-object_flow_edges"
    /// </rule>
    /// xmi:id="ObjectNode"
    public interface ObjectNode : TypedElement,ActivityNode
        {
        #region P:InState:State[]
        /// <summary>
        /// The States required to be associated with the values held by tokens on this <see cref="ObjectNode"/>.
        /// </summary>
        /// xmi:id="ObjectNode-inState"
        State[] InState { get; }
        #endregion
        #region P:IsControlType:Boolean
        /// <summary>
        /// Indicates whether the <see cref="Type"/> of the <see cref="ObjectNode"/> is to be treated as representing control values that may traverse ControlFlows.
        /// </summary>
        /// xmi:id="ObjectNode-isControlType"
        Boolean IsControlType { get; }
        #endregion
        #region P:Ordering:ObjectNodeOrderingKind
        /// <summary>
        /// Indicates how the tokens held by the <see cref="ObjectNode"/> are ordered for <see cref="Selection"/> to traverse ActivityEdges <see cref="Outgoing"/> from the <see cref="ObjectNode"/>.
        /// </summary>
        /// xmi:id="ObjectNode-ordering"
        ObjectNodeOrderingKind Ordering { get; }
        #endregion
        #region P:Selection:Behavior
        /// <summary>
        /// A <see cref="Behavior"/> used to select tokens to be offered on <see cref="Outgoing"/> ActivityEdges.
        /// </summary>
        /// xmi:id="ObjectNode-selection"
        Behavior Selection { get; }
        #endregion
        #region P:UpperBound:ValueSpecification
        /// <summary>
        /// The maximum number of tokens that may be held by this <see cref="ObjectNode"/>. Tokens cannot flow into the <see cref="ObjectNode"/> if the <see cref="UpperBound"/> is reached. If no <see cref="UpperBound"/> is specified, then there is no limit on how many tokens the <see cref="ObjectNode"/> can hold.
        /// </summary>
        /// xmi:id="ObjectNode-upperBound"
        /// xmi:aggregation="composite"
        ValueSpecification UpperBound { get; }
        #endregion
        }
    }
