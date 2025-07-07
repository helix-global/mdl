namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface CollaborationInstanceSet : ModelElement
        {
        Collaboration collaboration { get; }
        ModelElement[] constrainingElement { get; }
        InteractionInstanceSet[] interactionInstanceSet { get; }
        Instance[] participatingInstance { get; }
        Link[] participatingLink { get; }
        }
    }
