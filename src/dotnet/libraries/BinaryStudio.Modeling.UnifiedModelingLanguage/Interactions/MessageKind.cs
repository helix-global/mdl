using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// This is an enumerated type that identifies the type of <see cref="Message"/>.
    /// </summary>
    /// xmi:id="MessageKind"
    public enum MessageKind
        {
        /// <summary>
        /// sendEvent and receiveEvent are present
        /// </summary>
        /// xmi:id="MessageKind-complete"
        Complete,
        /// <summary>
        /// sendEvent present and receiveEvent absent
        /// </summary>
        /// xmi:id="MessageKind-lost"
        Lost,
        /// <summary>
        /// sendEvent absent and receiveEvent present
        /// </summary>
        /// xmi:id="MessageKind-found"
        Found,
        /// <summary>
        /// sendEvent and receiveEvent absent (should not appear)
        /// </summary>
        /// xmi:id="MessageKind-unknown"
        Unknown
        }
    }
