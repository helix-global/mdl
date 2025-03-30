using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="RaiseExceptionAction"/> is an <see cref="Action"/> that causes an <see cref="Exception"/> to occur. The <see cref="Input"/> value becomes the <see cref="Exception"/> object.
    /// </summary>
    /// xmi:id="RaiseExceptionAction"
    public interface RaiseExceptionAction : Action
        {
        #region P:Exception:InputPin
        /// <summary>
        /// An <see cref="InputPin"/> whose value becomes the <see cref="Exception"/> object.
        /// </summary>
        /// xmi:id="RaiseExceptionAction-exception"
        /// xmi:aggregation="composite"
        InputPin Exception { get; }
        #endregion
        }
    }
