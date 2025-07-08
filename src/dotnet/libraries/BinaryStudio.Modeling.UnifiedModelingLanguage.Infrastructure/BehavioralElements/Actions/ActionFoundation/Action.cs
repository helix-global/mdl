using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class Action : ModelElement
        {
        ControlFlow[] antecedent { get; }
        InputPin[] availableInput { get; }
        OutputPin[] availableOutput { get; }
        ControlFlow[] consequent { get; }
        GroupAction group { get; }
        InputPin[] inputPin { get; }
        Boolean isReadOnly { get; }
        JumpHandler[] jumpHandler { get; }
        OutputPin[] outputPin { get; }
        Procedure procedure { get; }
        }
    }

