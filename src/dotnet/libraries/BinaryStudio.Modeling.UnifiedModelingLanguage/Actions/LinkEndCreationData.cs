using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="LinkEndCreationData"/> is <see cref="LinkEndData"/> used to provide values for one <see cref="End"/> of a link to be created by a <see cref="CreateLinkAction"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   <see cref="LinkEndCreationData"/> for ordered <see cref="Association"/> ends must have a single insertAt <see cref="InputPin"/> for the insertion point with type UnlimitedNatural and multiplicity of 1..1, if isReplaceAll=false, and must have no <see cref="InputPin"/> for the insertion point when the association ends are unordered.
    ///   <![CDATA[
    ///     if  not end.isOrdered
    ///     then insertAt = null
    ///     else
    ///     	not isReplaceAll=false implies
    ///     	insertAt <> null and insertAt->forAll(type=UnlimitedNatural and is(1,1))
    ///     endif
    ///     
    ///   ]]>
    ///   xmi:id="LinkEndCreationData-insertAt_pin"
    /// </rule>
    /// xmi:id="LinkEndCreationData"
    public interface LinkEndCreationData : LinkEndData
        {
        #region P:InsertAt:InputPin
        /// <summary>
        /// For ordered <see cref="Association"/> ends, the <see cref="InputPin"/> that provides the position where the new link should be inserted or where an existing link should be moved to. The type of the <see cref="InsertAt"/> <see cref="InputPin"/> is UnlimitedNatural, but the input cannot be zero. It is omitted for <see cref="Association"/> ends that are not ordered.
        /// </summary>
        /// xmi:id="LinkEndCreationData-insertAt"
        /// xmi:association="A_insertAt_linkEndCreationData"
        [Multiplicity("0..1")]
        InputPin InsertAt { get;set; }
        #endregion
        #region P:IsReplaceAll:Boolean
        /// <summary>
        /// Specifies whether the existing links emanating from the object on this <see cref="End"/> should be destroyed before creating a new link.
        /// </summary>
        /// xmi:id="LinkEndCreationData-isReplaceAll"
        Boolean IsReplaceAll { get;set; }
        #endregion

        #region M:allPins:InputPin[]
        /// <summary>
        /// Adds the <see cref="InsertAt"/> <see cref="InputPin"/> (if any) to the set of all Pins.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.LinkEndData.allPins"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.LinkEndData::allPins()->including(insertAt))
        ///   ]]>
        ///   xmi:id="LinkEndCreationData-allPins-spec"
        /// </rule>
        /// xmi:id="LinkEndCreationData-allPins"
        /// xmi:is-query="true"
        InputPin[] allPins();
        #endregion
        }
    }
