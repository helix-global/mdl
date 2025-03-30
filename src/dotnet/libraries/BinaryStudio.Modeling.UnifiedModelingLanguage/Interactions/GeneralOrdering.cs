using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="GeneralOrdering"/> represents a binary relation between two OccurrenceSpecifications, to describe that one <see cref="OccurrenceSpecification"/> must occur <see cref="Before"/> the other in a valid trace. This mechanism provides the ability to define partial orders of OccurrenceSpecifications that may otherwise not have a specified order.
    /// </summary>
    /// <rule language="OCL">
    ///   An occurrence specification must not be ordered relative to itself through a series of general orderings. (In other words, the transitive closure of the general orderings is irreflexive.)
    ///   <![CDATA[
    ///     after->closure(toAfter.after)->excludes(before)
    ///   ]]>
    ///   xmi:id="GeneralOrdering-irreflexive_transitive_closure"
    /// </rule>
    /// xmi:id="GeneralOrdering"
    public interface GeneralOrdering : NamedElement
        {
        #region P:After:OccurrenceSpecification
        /// <summary>
        /// The <see cref="OccurrenceSpecification"/> referenced comes <see cref="After"/> the <see cref="OccurrenceSpecification"/> referenced by <see cref="Before"/>.
        /// </summary>
        /// xmi:id="GeneralOrdering-after"
        OccurrenceSpecification After { get; }
        #endregion
        #region P:Before:OccurrenceSpecification
        /// <summary>
        /// The <see cref="OccurrenceSpecification"/> referenced comes <see cref="Before"/> the <see cref="OccurrenceSpecification"/> referenced by <see cref="After"/>.
        /// </summary>
        /// xmi:id="GeneralOrdering-before"
        OccurrenceSpecification Before { get; }
        #endregion
        }
    }
