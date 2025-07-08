using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface CallProcedureAction : PrimitiveAction
        {
        Boolean isSynchronous { get; }
        OutputPin[] input { get; }
        InputPin[] output { get; }
        Procedure calledProcedure { get; }
        }
    }
