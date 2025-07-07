namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Message : ModelElement
        {
        Message activator { get; }
        AssociationRole communicationConnection { get; }
        Stimulus[] conformingStimulus { get; }
        Interaction interaction { get; }
        Message[] message { get; }
        Message[] predecessor { get; }
        Procedure procedure { get; }
        ClassifierRole sender { get; }
        ClassifierRole receiver { get; }
        Message[] successor { get; }
        }
    }
