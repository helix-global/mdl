using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class CallProcedureAction : PrimitiveAction
        {
        Boolean isSynchronous { get; }
        OutputPin[] input { get; }
        InputPin[] output { get; }
        Procedure calledProcedure { get; }
        }
    }
