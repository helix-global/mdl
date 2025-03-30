using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="SignalEvent"/> represents the receipt of an asynchronous <see cref="Signal"/> instance.
    /// </summary>
    /// xmi:id="SignalEvent"
    public interface SignalEvent : MessageEvent
        {
        #region P:Signal:Signal
        /// <summary>
        /// The specific <see cref="Signal"/> that is associated with this <see cref="SignalEvent"/>.
        /// </summary>
        /// xmi:id="SignalEvent-signal"
        Signal Signal { get; }
        #endregion
        }
    }
