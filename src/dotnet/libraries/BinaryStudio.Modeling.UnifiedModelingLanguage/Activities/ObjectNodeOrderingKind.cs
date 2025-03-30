using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="ObjectNodeOrderingKind"/> is an enumeration indicating queuing order for offering the tokens held by an <see cref="ObjectNode"/>.
    /// </summary>
    /// xmi:id="ObjectNodeOrderingKind"
    public enum ObjectNodeOrderingKind
        {
        /// <summary>
        /// Indicates that tokens are unordered.
        /// </summary>
        /// xmi:id="ObjectNodeOrderingKind-unordered"
        Unordered,
        /// <summary>
        /// Indicates that tokens are ordered.
        /// </summary>
        /// xmi:id="ObjectNodeOrderingKind-ordered"
        Ordered,
        /// <summary>
        /// Indicates that tokens are queued in a last in, first out manner.
        /// </summary>
        /// xmi:id="ObjectNodeOrderingKind-LIFO"
        LIFO,
        /// <summary>
        /// Indicates that tokens are queued in a first in, first out manner.
        /// </summary>
        /// xmi:id="ObjectNodeOrderingKind-FIFO"
        FIFO
        }
    }
