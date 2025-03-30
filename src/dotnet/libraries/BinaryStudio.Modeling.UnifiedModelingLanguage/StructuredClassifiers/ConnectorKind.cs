using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="ConnectorKind"/> is an enumeration that defines whether a <see cref="Connector"/> is an assembly or a delegation.
    /// </summary>
    /// xmi:id="ConnectorKind"
    public enum ConnectorKind
        {
        /// <summary>
        /// Indicates that the <see cref="Connector"/> is an assembly <see cref="Connector"/>.
        /// </summary>
        /// xmi:id="ConnectorKind-assembly"
        Assembly,
        /// <summary>
        /// Indicates that the <see cref="Connector"/> is a delegation <see cref="Connector"/>.
        /// </summary>
        /// xmi:id="ConnectorKind-delegation"
        Delegation
        }
    }
