using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="GeneralizationSet"/> is a <see cref="PackageableElement"/> whose instances represent sets of <see cref="Generalization"/> relationships.
    /// </summary>
    /// <rule language="OCL">
    ///   Every <see cref="Generalization"/> associated with a particular <see cref="GeneralizationSet"/> must have the same general <see cref="Classifier"/>.
    ///   <![CDATA[
    ///     generalization->collect(general)->asSet()->size() <= 1
    ///   ]]>
    ///   xmi:id="GeneralizationSet-generalization_same_classifier"
    /// </rule>
    /// <rule language="OCL">
    ///   The <see cref="Classifier"/> that maps to a <see cref="GeneralizationSet"/> may neither be a specific nor a general <see cref="Classifier"/> in any of the <see cref="Generalization"/> relationships defined for that <see cref="GeneralizationSet"/>. In other words, a power type may not be an instance of itself nor may its instances be its subclasses.
    ///   <![CDATA[
    ///     powertype <> null implies generalization->forAll( gen | 
    ///         not (gen.general = powertype) and not gen.general.allParents()->includes(powertype) and not (gen.specific = powertype) and not powertype.allParents()->includes(gen.specific)
    ///       )
    ///   ]]>
    ///   xmi:id="GeneralizationSet-maps_to_generalization_set"
    /// </rule>
    /// xmi:id="GeneralizationSet"
    public interface GeneralizationSet : PackageableElement
        {
        #region P:Generalization:Generalization[]
        /// <summary>
        /// Designates the instances of <see cref="Generalization"/> that are members of this <see cref="GeneralizationSet"/>.
        /// </summary>
        /// xmi:id="GeneralizationSet-generalization"
        Generalization[] Generalization { get; }
        #endregion
        #region P:IsCovering:Boolean
        /// <summary>
        /// Indicates (via the associated Generalizations) whether or not the set of specific Classifiers are covering for a particular general classifier. When <see cref="IsCovering"/> is true, every instance of a particular general <see cref="Classifier"/> is also an instance of at least one of its specific Classifiers for the <see cref="GeneralizationSet"/>. When <see cref="IsCovering"/> is false, there are one or more instances of the particular general <see cref="Classifier"/> that are not instances of at least one of its specific Classifiers defined for the <see cref="GeneralizationSet"/>.
        /// </summary>
        /// xmi:id="GeneralizationSet-isCovering"
        Boolean IsCovering { get; }
        #endregion
        #region P:IsDisjoint:Boolean
        /// <summary>
        /// Indicates whether or not the set of specific Classifiers in a <see cref="Generalization"/> relationship have instance in common. If <see cref="IsDisjoint"/> is true, the specific Classifiers for a particular <see cref="GeneralizationSet"/> have no members in common; that is, their intersection is empty. If <see cref="IsDisjoint"/> is false, the specific Classifiers in a particular <see cref="GeneralizationSet"/> have one or more members in common; that is, their intersection is not empty.
        /// </summary>
        /// xmi:id="GeneralizationSet-isDisjoint"
        Boolean IsDisjoint { get; }
        #endregion
        #region P:Powertype:Classifier
        /// <summary>
        /// Designates the <see cref="Classifier"/> that is defined as the power type for the associated <see cref="GeneralizationSet"/>, if there is one.
        /// </summary>
        /// xmi:id="GeneralizationSet-powertype"
        Classifier Powertype { get; }
        #endregion
        }
    }
