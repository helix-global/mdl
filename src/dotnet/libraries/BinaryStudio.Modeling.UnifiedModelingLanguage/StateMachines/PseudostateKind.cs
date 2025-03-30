using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="PseudostateKind"/> is an <see cref="Enumeration"/> type that is used to differentiate various kinds of Pseudostates.
    /// </summary>
    /// xmi:id="PseudostateKind"
    public enum PseudostateKind
        {
        /// xmi:id="PseudostateKind-initial"
        Initial,
        /// xmi:id="PseudostateKind-deepHistory"
        DeepHistory,
        /// xmi:id="PseudostateKind-shallowHistory"
        ShallowHistory,
        /// xmi:id="PseudostateKind-join"
        Join,
        /// xmi:id="PseudostateKind-fork"
        Fork,
        /// xmi:id="PseudostateKind-junction"
        Junction,
        /// xmi:id="PseudostateKind-choice"
        Choice,
        /// xmi:id="PseudostateKind-entryPoint"
        EntryPoint,
        /// xmi:id="PseudostateKind-exitPoint"
        ExitPoint,
        /// xmi:id="PseudostateKind-terminate"
        Terminate
        }
    }
