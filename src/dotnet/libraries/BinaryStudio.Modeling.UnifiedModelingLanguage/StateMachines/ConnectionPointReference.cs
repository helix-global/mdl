﻿using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ConnectionPointReference"/> represents a usage (as part of a submachine <see cref="State"/>) of an <see cref="Entry"/>/<see cref="Exit"/> point <see cref="Pseudostate"/> defined in the <see cref="StateMachine"/> referenced by the submachine <see cref="State"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The exit Pseudostates must be Pseudostates with kind exitPoint.
    ///   <![CDATA[
    ///     exit->forAll(kind = PseudostateKind::exitPoint)
    ///   ]]>
    ///   xmi:id="ConnectionPointReference-exit_pseudostates"
    /// </rule>
    /// <rule language="OCL">
    ///   The entry Pseudostates must be Pseudostates with kind entryPoint.
    ///   <![CDATA[
    ///     entry->forAll(kind = PseudostateKind::entryPoint)
    ///   ]]>
    ///   xmi:id="ConnectionPointReference-entry_pseudostates"
    /// </rule>
    /// xmi:id="ConnectionPointReference"
    public interface ConnectionPointReference : Vertex
        {
        #region P:Entry:IList<Pseudostate>
        /// <summary>
        /// The entryPoint Pseudostates corresponding to this connection point.
        /// </summary>
        /// xmi:id="ConnectionPointReference-entry"
        /// xmi:association="A_entry_connectionPointReference"
        IList<Pseudostate> Entry { get; }
        #endregion
        #region P:Exit:IList<Pseudostate>
        /// <summary>
        /// The exitPoints kind Pseudostates corresponding to this connection point.
        /// </summary>
        /// xmi:id="ConnectionPointReference-exit"
        /// xmi:association="A_exit_connectionPointReference"
        IList<Pseudostate> Exit { get; }
        #endregion
        #region P:State:State
        /// <summary>
        /// The <see cref="State"/> in which the <see cref="ConnectionPointReference"/> is defined.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        /// </summary>
        /// xmi:id="ConnectionPointReference-state"
        /// xmi:association="A_connection_state"
        [Multiplicity("0..1")]
        State State { get;set; }
        #endregion

        #region M:isConsistentWith(RedefinableElement):Boolean
        /// <summary>
        /// The query <see cref="isConsistentWith"/> specifies a <see cref="ConnectionPointReference"/> can only be redefined by a <see cref="ConnectionPointReference"/>.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.isConsistentWith"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     redefiningElement.isRedefinitionContextValid(self)
        ///   ]]>
        ///   xmi:id="ConnectionPointReference-isConsistentWith-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = redefiningElement.oclIsKindOf(ConnectionPointReference)
        ///   ]]>
        ///   xmi:id="ConnectionPointReference-isConsistentWith-spec"
        /// </rule>
        /// xmi:id="ConnectionPointReference-isConsistentWith"
        /// xmi:is-query=""
        Boolean isConsistentWith(RedefinableElement redefiningElement);
        #endregion
        }
    }
