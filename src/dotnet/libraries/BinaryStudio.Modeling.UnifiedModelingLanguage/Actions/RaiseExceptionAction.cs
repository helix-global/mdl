﻿using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

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
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="RaiseExceptionAction-exception"
        /// xmi:aggregation="composite"
        /// xmi:association="A_exception_raiseExceptionAction"
        InputPin Exception { get;set; }
        #endregion
        }
    }
