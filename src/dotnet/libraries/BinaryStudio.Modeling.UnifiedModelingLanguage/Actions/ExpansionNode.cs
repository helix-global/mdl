using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="ExpansionNode"/> is an <see cref="ObjectNode"/> used to indicate a collection input or output for an <see cref="ExpansionRegion"/>. A collection input of an <see cref="ExpansionRegion"/> contains a collection that is broken into its individual elements inside the region, whose content is executed once per element. A collection output of an <see cref="ExpansionRegion"/> combines individual elements produced by the execution of the region into a collection for use outside the region.
    /// </summary>
    /// <rule language="OCL">
    ///   One of regionAsInput or regionAsOutput must be non-empty, but not both.
    ///   <![CDATA[
    ///     regionAsInput->notEmpty() xor regionAsOutput->notEmpty()
    ///   ]]>
    ///   xmi:id="ExpansionNode-region_as_input_or_output"
    /// </rule>
    /// xmi:id="ExpansionNode"
    public interface ExpansionNode : ObjectNode
        {
        #region P:RegionAsInput:ExpansionRegion
        /// <summary>
        /// The <see cref="ExpansionRegion"/> for which the <see cref="ExpansionNode"/> is an input.
        /// </summary>
        /// xmi:id="ExpansionNode-regionAsInput"
        /// xmi:association="A_inputElement_regionAsInput"
        [Multiplicity("0..1")]
        ExpansionRegion RegionAsInput { get; }
        #endregion
        #region P:RegionAsOutput:ExpansionRegion
        /// <summary>
        /// The <see cref="ExpansionRegion"/> for which the <see cref="ExpansionNode"/> is an output.
        /// </summary>
        /// xmi:id="ExpansionNode-regionAsOutput"
        /// xmi:association="A_outputElement_regionAsOutput"
        [Multiplicity("0..1")]
        ExpansionRegion RegionAsOutput { get; }
        #endregion
        }
    }
