namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Instance : ModelElement
        {
        AttributeLink[] attributeLink { get; }
        Classifier[] classifier { get; }
        CollaborationInstanceSet[] collaborationInstanceSet { get; }
        ComponentInstance componentInstance { get; }
        LinkEnd[] linkEnd { get; }
        Instance[] ownedInstance { get; }
        Link[] ownedLink { get; }
        Instance owner { get; }
        ClassifierRole[] playedRole { get; }
        AttributeLink[] slot { get; }
        Stimulus[] stimulus { get; }
        }
    }