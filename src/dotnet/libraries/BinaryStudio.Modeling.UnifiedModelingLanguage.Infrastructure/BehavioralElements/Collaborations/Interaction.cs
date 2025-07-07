namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Interaction : ModelElement
        {
        Collaboration context { get; }
        InteractionInstanceSet[] interactionInstanceSet { get; }
        Message[] message { get; }
        }
    }
