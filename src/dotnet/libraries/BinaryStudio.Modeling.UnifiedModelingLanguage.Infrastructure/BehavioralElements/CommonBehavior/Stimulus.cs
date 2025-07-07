namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Stimulus : ModelElement
        {
        Instance[] argument { get; }
        Link communicationLink { get; }
        Procedure dispatchAction { get; }
        InteractionInstanceSet[] interactionInstanceSet { get; }
        Message[] playedRole { get; }
        Instance receiver { get; }
        Instance sender { get; }
        }
    }
