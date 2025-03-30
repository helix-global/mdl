using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A trigger for an <see cref="AnyReceiveEvent"/> is triggered by the receipt of any message that is not explicitly handled by any related trigger.
    /// </summary>
    /// xmi:id="AnyReceiveEvent"
    public interface AnyReceiveEvent : MessageEvent
        {
        }
    }
