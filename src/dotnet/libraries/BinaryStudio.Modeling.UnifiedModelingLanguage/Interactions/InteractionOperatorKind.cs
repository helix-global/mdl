using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="InteractionOperatorKind"/> is an enumeration designating the different kinds of operators of CombinedFragments. The <see cref="InteractionOperand"/> defines the type of operator of a <see cref="CombinedFragment"/>.
    /// </summary>
    /// xmi:id="InteractionOperatorKind"
    public enum InteractionOperatorKind
        {
        /// <summary>
        /// The <see cref="InteractionOperatorKind"/> seq designates that the <see cref="CombinedFragment"/> represents a weak sequencing between the behaviors of the operands.
        /// </summary>
        /// xmi:id="InteractionOperatorKind-seq"
        Seq,
        /// <summary>
        /// The <see cref="InteractionOperatorKind"/> alt designates that the <see cref="CombinedFragment"/> represents a choice of behavior. At most one of the operands will be chosen. The chosen operand must have an explicit or implicit guard expression that evaluates to true at this point in the interaction. An implicit true guard is implied if the operand has no guard.
        /// </summary>
        /// xmi:id="InteractionOperatorKind-alt"
        Alt,
        /// <summary>
        /// The <see cref="InteractionOperatorKind"/> opt designates that the <see cref="CombinedFragment"/> represents a choice of behavior where either the (sole) operand happens or nothing happens. An option is semantically equivalent to an alternative <see cref="CombinedFragment"/> where there is one operand with non-empty content and the second operand is empty.
        /// </summary>
        /// xmi:id="InteractionOperatorKind-opt"
        Opt,
        /// <summary>
        /// The <see cref="InteractionOperatorKind"/> break designates that the <see cref="CombinedFragment"/> represents a breaking scenario in the sense that the operand is a scenario that is performed instead of the remainder of the enclosing <see cref="InteractionFragment"/>. A break operator with a guard is chosen when the guard is true and the rest of the enclosing <see cref="Interaction"/> Fragment is ignored. When the guard of the break operand is false, the break operand is ignored and the rest of the enclosing <see cref="InteractionFragment"/> is chosen. The choice between a break operand without a guard and the rest of the enclosing <see cref="InteractionFragment"/> is done non-deterministically.
        /// </summary>
        /// xmi:id="InteractionOperatorKind-break"
        Break,
        /// <summary>
        /// The <see cref="InteractionOperatorKind"/> par designates that the <see cref="CombinedFragment"/> represents a parallel merge between the behaviors of the operands. The OccurrenceSpecifications of the different operands can be interleaved in any way as long as the ordering imposed by each operand as such is preserved.
        /// </summary>
        /// xmi:id="InteractionOperatorKind-par"
        Par,
        /// <summary>
        /// The <see cref="InteractionOperatorKind"/> strict designates that the <see cref="CombinedFragment"/> represents a strict sequencing between the behaviors of the operands. The semantics of strict sequencing defines a strict ordering of the operands on the first level within the <see cref="CombinedFragment"/> with interactionOperator strict. Therefore OccurrenceSpecifications within contained <see cref="CombinedFragment"/> will not directly be compared with other OccurrenceSpecifications of the enclosing <see cref="CombinedFragment"/>.
        /// </summary>
        /// xmi:id="InteractionOperatorKind-strict"
        Strict,
        /// <summary>
        /// The <see cref="InteractionOperatorKind"/> loop designates that the <see cref="CombinedFragment"/> represents a loop. The loop operand will be repeated a number of times.
        /// </summary>
        /// xmi:id="InteractionOperatorKind-loop"
        Loop,
        /// <summary>
        /// The <see cref="InteractionOperatorKind"/> critical designates that the <see cref="CombinedFragment"/> represents a critical region. A critical region means that the traces of the region cannot be interleaved by other OccurrenceSpecifications (on those Lifelines covered by the region). This means that the region is treated atomically by the enclosing fragment when determining the set of valid traces. Even though enclosing CombinedFragments may imply that some OccurrenceSpecifications may interleave into the region, such as with par-operator, this is prevented by defining a region.
        /// </summary>
        /// xmi:id="InteractionOperatorKind-critical"
        Critical,
        /// <summary>
        /// The <see cref="InteractionOperatorKind"/> neg designates that the <see cref="CombinedFragment"/> represents traces that are defined to be invalid.
        /// </summary>
        /// xmi:id="InteractionOperatorKind-neg"
        Neg,
        /// <summary>
        /// The <see cref="InteractionOperatorKind"/> assert designates that the <see cref="CombinedFragment"/> represents an assertion. The sequences of the operand of the assertion are the only valid continuations. All other continuations result in an invalid trace.
        /// </summary>
        /// xmi:id="InteractionOperatorKind-assert"
        Assert,
        /// <summary>
        /// The <see cref="InteractionOperatorKind"/> ignore designates that there are some message types that are not shown within this combined fragment. These message types can be considered insignificant and are implicitly ignored if they appear in a corresponding execution. Alternatively, one can understand ignore to mean that the message types that are ignored can appear anywhere in the traces.
        /// </summary>
        /// xmi:id="InteractionOperatorKind-ignore"
        Ignore,
        /// <summary>
        /// The <see cref="InteractionOperatorKind"/> consider designates which messages should be considered within this combined fragment. This is equivalent to defining every other message to be ignored.
        /// </summary>
        /// xmi:id="InteractionOperatorKind-consider"
        Consider
        }
    }
