using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Procedure : ModelElement
        {
        State state { get; }
        Action action { get; }
        OutputPin[] argument { get; }
        String body { get; }
        Expression expression { get; }
        Boolean isList { get; }
        String language { get; }
        Message[] message { get; }
        Method method { get; }
        InputPin[] result { get; }
        Stimulus[] stimulus { get; }
        Transition transition { get; }
        }
    }