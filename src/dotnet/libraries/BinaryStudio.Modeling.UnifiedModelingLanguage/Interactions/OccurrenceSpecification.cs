using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="OccurrenceSpecification"/> is the basic semantic unit of Interactions. The sequences of occurrences specified by them are the meanings of Interactions.
    /// </summary>
    /// xmi:id="OccurrenceSpecification"
    public interface OccurrenceSpecification : InteractionFragment
        {
        #region P:Covered:Lifeline
        /// <summary>
        /// References the <see cref="Lifeline"/> on which the <see cref="OccurrenceSpecification"/> appears.
        /// </summary>
        /// xmi:id="OccurrenceSpecification-covered"
        /// xmi:redefines="InteractionFragment-covered{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.InteractionFragment.Covered"/>}"
        Lifeline Covered { get; }
        #endregion
        #region P:ToAfter:GeneralOrdering[]
        /// <summary>
        /// References the GeneralOrderings that specify EventOcurrences that must occur after this <see cref="OccurrenceSpecification"/>.
        /// </summary>
        /// xmi:id="OccurrenceSpecification-toAfter"
        GeneralOrdering[] ToAfter { get; }
        #endregion
        #region P:ToBefore:GeneralOrdering[]
        /// <summary>
        /// References the GeneralOrderings that specify EventOcurrences that must occur before this <see cref="OccurrenceSpecification"/>.
        /// </summary>
        /// xmi:id="OccurrenceSpecification-toBefore"
        GeneralOrdering[] ToBefore { get; }
        #endregion
        }
    }
