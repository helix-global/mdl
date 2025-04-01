using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="LinkAction"/> is an abstract class for all Actions that identify the links to be acted on using <see cref="LinkEndData"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The inputValue InputPins is the same as the union of all the InputPins referenced by the endData.
    ///   <![CDATA[
    ///     inputValue->asBag()=endData.allPins()
    ///   ]]>
    ///   xmi:id="LinkAction-same_pins"
    /// </rule>
    /// <rule language="OCL">
    ///   The ends of the endData must all be from the same <see cref="Association"/> and include all and only the memberEnds of that association.
    ///   <![CDATA[
    ///     endData.end = self.association().memberEnd->asBag()
    ///   ]]>
    ///   xmi:id="LinkAction-same_association"
    /// </rule>
    /// <rule language="OCL">
    ///   The ends of the endData must not be static.
    ///   <![CDATA[
    ///     endData->forAll(not end.isStatic)
    ///   ]]>
    ///   xmi:id="LinkAction-not_static"
    /// </rule>
    /// xmi:id="LinkAction"
    public interface LinkAction : Action
        {
        #region P:EndData:IList<LinkEndData>
        /// <summary>
        /// The <see cref="LinkEndData"/> identifying the values on the ends of the links acting on by this <see cref="LinkAction"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="LinkAction-endData"
        /// xmi:aggregation="composite"
        /// xmi:association="A_endData_linkAction"
        [Multiplicity("2..*")]
        IList<LinkEndData> EndData { get; }
        #endregion
        #region P:InputValue:IList<InputPin>
        /// <summary>
        /// InputPins used by the <see cref="LinkEndData"/> of the <see cref="LinkAction"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="LinkAction-inputValue"
        /// xmi:aggregation="composite"
        /// xmi:association="A_inputValue_linkAction"
        [Multiplicity("1..*")]
        IList<InputPin> InputValue { get; }
        #endregion

        #region M:association:Association
        /// <summary>
        /// Returns the <see cref="Association"/> acted on by this <see cref="LinkAction"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (endData->asSequence()->first().end.association)
        ///   ]]>
        ///   xmi:id="LinkAction-association-spec"
        /// </rule>
        /// xmi:id="LinkAction-association"
        /// xmi:is-query="true"
        Association association();
        #endregion
        }
    }
