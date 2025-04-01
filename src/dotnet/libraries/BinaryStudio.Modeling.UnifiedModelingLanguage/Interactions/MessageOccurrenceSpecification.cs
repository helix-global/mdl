using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="MessageOccurrenceSpecification"/> specifies the occurrence of <see cref="Message"/> events, such as sending and receiving of Signals or invoking or receiving of <see cref="Operation"/> calls. A <see cref="MessageOccurrenceSpecification"/> is a kind of <see cref="MessageEnd"/>. Messages are generated either by synchronous <see cref="Operation"/> calls or asynchronous <see cref="Signal"/> sends. They are received by the execution of corresponding AcceptEventActions.
    /// </summary>
    /// xmi:id="MessageOccurrenceSpecification"
    public interface MessageOccurrenceSpecification : MessageEnd,OccurrenceSpecification
        {
        }
    }
