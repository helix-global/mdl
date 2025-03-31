using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="PartDecomposition"/> is a description of the internal Interactions of one <see cref="Lifeline"/> relative to an <see cref="Interaction"/>.
    /// </summary>
    /// <rule language="">
    ///   Assume that within <see cref="Interaction"/> X, <see cref="Lifeline"/> L is of class C and decomposed to D. Assume also that there is within X an <see cref="InteractionUse"/> (say) U that covers L. According to the constraint above U will have a counterpart CU within D. Within the <see cref="Interaction"/> referenced by U, L should also be decomposed, and the decomposition should reference CU. (This rule is called commutativity of decomposition.)
    ///   xmi:id="PartDecomposition-commutativity_of_decomposition"
    /// </rule>
    /// <rule language="">
    ///   Assume that within <see cref="Interaction"/> X, <see cref="Lifeline"/> L is of class C and decomposed to D. Within X there is a sequence of constructs along L (such constructs are CombinedFragments, <see cref="InteractionUse"/> and (plain) OccurrenceSpecifications). Then a corresponding sequence of constructs must appear within D, matched one-to-one in the same order. i) <see cref="CombinedFragment"/> covering L are matched with an extra-global <see cref="CombinedFragment"/> in D. ii) An <see cref="InteractionUse"/> covering L is matched with a global (i.e., covering all Lifelines) <see cref="InteractionUse"/> in D. iii) A plain <see cref="OccurrenceSpecification"/> on L is considered an actualGate that must be matched by a formalGate of D.
    ///   xmi:id="PartDecomposition-assume"
    /// </rule>
    /// <rule language="">
    ///   PartDecompositions apply only to Parts that are Parts of Internal Structures not to Parts of Collaborations.
    ///   xmi:id="PartDecomposition-parts_of_internal_structures"
    /// </rule>
    /// xmi:id="PartDecomposition"
    public interface PartDecomposition : InteractionUse
        {
        }
    }
