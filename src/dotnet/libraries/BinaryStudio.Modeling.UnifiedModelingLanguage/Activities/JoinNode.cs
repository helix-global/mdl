using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="JoinNode"/> is a <see cref="ControlNode"/> that synchronizes multiple flows.
    /// </summary>
    /// <rule language="OCL">
    ///   A <see cref="JoinNode"/> has one outgoing <see cref="ActivityEdge"/>.
    ///   <![CDATA[
    ///     outgoing->size() = 1
    ///   ]]>
    ///   xmi:id="JoinNode-one_outgoing_edge"
    /// </rule>
    /// <rule language="OCL">
    ///   If one of the incoming ActivityEdges of a <see cref="JoinNode"/> is an <see cref="ObjectFlow"/>, then its outgoing <see cref="ActivityEdge"/> must be an <see cref="ObjectFlow"/>. Otherwise its outgoing <see cref="ActivityEdge"/> must be a <see cref="ControlFlow"/>.
    ///   <![CDATA[
    ///     if incoming->exists(oclIsKindOf(ObjectFlow)) then outgoing->forAll(oclIsKindOf(ObjectFlow))
    ///     else outgoing->forAll(oclIsKindOf(ControlFlow))
    ///     endif
    ///   ]]>
    ///   xmi:id="JoinNode-incoming_object_flow"
    /// </rule>
    /// xmi:id="JoinNode"
    public interface JoinNode : ControlNode
        {
        #region P:IsCombineDuplicate:Boolean
        /// <summary>
        /// Indicates whether <see cref="Incoming"/> tokens having objects with the same identity are combined into one by the <see cref="JoinNode"/>.
        /// </summary>
        /// xmi:id="JoinNode-isCombineDuplicate"
        Boolean IsCombineDuplicate { get; }
        #endregion
        #region P:JoinSpec:ValueSpecification
        /// <summary>
        /// A <see cref="ValueSpecification"/> giving the condition under which the <see cref="JoinNode"/> will offer a token on its <see cref="Outgoing"/> <see cref="ActivityEdge"/>. If no <see cref="JoinSpec"/> is specified, then the <see cref="JoinNode"/> will offer an <see cref="Outgoing"/> token if tokens are offered on all of its <see cref="Incoming"/> ActivityEdges (an "and" condition).
        /// </summary>
        /// xmi:id="JoinNode-joinSpec"
        /// xmi:aggregation="composite"
        ValueSpecification JoinSpec { get; }
        #endregion
        }
    }
