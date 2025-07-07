namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Link : ModelElement
        {
        Association association { get; }
        CollaborationInstanceSet[] collaborationInstanceSet { get; }
        LinkEnd[] connection { get; }
        Instance owner { get; }
        AssociationRole[] playedRole { get; }
        Stimulus[] stimulus { get; }
        }
    }
