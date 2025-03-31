using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="EncapsulatedClassifier"/> may own Ports to specify typed interaction points.
    /// </summary>
    /// xmi:id="EncapsulatedClassifier"
    public interface EncapsulatedClassifier : StructuredClassifier
        {
        #region P:OwnedPort:Port[]
        /// <summary>
        /// The Ports owned by the <see cref="EncapsulatedClassifier"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.StructuredClassifier.OwnedAttribute"/>"
        /// </summary>
        /// xmi:id="EncapsulatedClassifier-ownedPort"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedPort_encapsulatedClassifier"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        Port[] OwnedPort { get; }
        #endregion

        #region M:ownedPort:Port[]
        /// <summary>
        /// Derivation for <see cref="EncapsulatedClassifier"/>::/<see cref="OwnedPort"/> : <see cref="Port"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (ownedAttribute->select(oclIsKindOf(Port))->collect(oclAsType(Port))->asOrderedSet())
        ///   ]]>
        ///   xmi:id="EncapsulatedClassifier-ownedPort.1-spec"
        /// </rule>
        /// xmi:id="EncapsulatedClassifier-ownedPort.1"
        /// xmi:is-query="true"
        Port[] ownedPort();
        #endregion
        }
    }
