namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface InteractionInstanceSet : ModelElement
        {
        CollaborationInstanceSet context { get; }
        Interaction interaction { get; }
        Stimulus[] participatingStimulus { get; }
        }
    }
