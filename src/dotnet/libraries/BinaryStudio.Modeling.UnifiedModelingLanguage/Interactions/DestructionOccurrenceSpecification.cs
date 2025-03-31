using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A DestructionOccurenceSpecification models the destruction of an object.
    /// </summary>
    /// <rule language="OCL">
    ///   No other OccurrenceSpecifications on a given <see cref="Lifeline"/> in an <see cref="InteractionOperand"/> may appear below a <see cref="DestructionOccurrenceSpecification"/>.
    ///   <![CDATA[
    ///     let o : InteractionOperand = enclosingOperand in o->notEmpty() and 
    ///     let peerEvents : OrderedSet(OccurrenceSpecification) = covered.events->select(enclosingOperand = o)
    ///     in peerEvents->last() = self
    ///   ]]>
    ///   xmi:id="DestructionOccurrenceSpecification-no_occurrence_specifications_below"
    /// </rule>
    /// xmi:id="DestructionOccurrenceSpecification"
    public interface DestructionOccurrenceSpecification : MessageOccurrenceSpecification
        {
        }
    }
