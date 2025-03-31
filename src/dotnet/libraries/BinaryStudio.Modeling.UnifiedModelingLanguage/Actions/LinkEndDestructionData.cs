using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="LinkEndDestructionData"/> is <see cref="LinkEndData"/> used to provide values for one <see cref="End"/> of a link to be destroyed by a <see cref="DestroyLinkAction"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   <see cref="LinkEndDestructionData"/> for ordered, nonunique <see cref="Association"/> ends must have a single destroyAt <see cref="InputPin"/> if isDestroyDuplicates is false, which must be of type UnlimitedNatural and have a multiplicity of 1..1. Otherwise, the action has no destroyAt input pin.
    ///   <![CDATA[
    ///     if  not end.isOrdered or end.isUnique or isDestroyDuplicates
    ///     then destroyAt = null
    ///     else
    ///     	destroyAt <> null and 
    ///     	destroyAt->forAll(type=UnlimitedNatural and is(1,1))
    ///     endif
    ///     
    ///   ]]>
    ///   xmi:id="LinkEndDestructionData-destroyAt_pin"
    /// </rule>
    /// xmi:id="LinkEndDestructionData"
    public interface LinkEndDestructionData : LinkEndData
        {
        #region P:DestroyAt:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> that provides the position of an existing link to be destroyed in an ordered, nonunique <see cref="Association"/> <see cref="End"/>. The type of the <see cref="DestroyAt"/> <see cref="InputPin"/> is UnlimitedNatural, but the <see cref="Value"/> cannot be zero or unlimited.
        /// </summary>
        /// xmi:id="LinkEndDestructionData-destroyAt"
        /// xmi:association="A_destroyAt_linkEndDestructionData"
        [Multiplicity("0..1")]
        InputPin DestroyAt { get; }
        #endregion
        #region P:IsDestroyDuplicates:Boolean
        /// <summary>
        /// Specifies whether to destroy duplicates of the <see cref="Value"/> in nonunique <see cref="Association"/> ends.
        /// </summary>
        /// xmi:id="LinkEndDestructionData-isDestroyDuplicates"
        Boolean IsDestroyDuplicates { get; }
        #endregion

        #region M:allPins:InputPin[]
        /// <summary>
        /// Adds the <see cref="DestroyAt"/> <see cref="InputPin"/> (if any) to the set of all Pins.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.LinkEndData::allPins()->including(destroyAt))
        ///   ]]>
        ///   xmi:id="LinkEndDestructionData-allPins-spec"
        /// </rule>
        /// xmi:id="LinkEndDestructionData-allPins"
        /// xmi:is-query="true"
        /// xmi:redefines="LinkEndData-allPins{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.LinkEndData.allPins"/>}"
        InputPin[] allPins();
        #endregion
        }
    }
