using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="CallEvent"/> models the receipt by an object of a message invoking a call of an <see cref="Operation"/>.
    /// </summary>
    /// xmi:id="CallEvent"
    public interface CallEvent : MessageEvent
        {
        #region P:Operation:Operation
        /// <summary>
        /// Designates the <see cref="Operation"/> whose invocation raised the CalEvent.
        /// </summary>
        /// xmi:id="CallEvent-operation"
        Operation Operation { get; }
        #endregion
        }
    }
