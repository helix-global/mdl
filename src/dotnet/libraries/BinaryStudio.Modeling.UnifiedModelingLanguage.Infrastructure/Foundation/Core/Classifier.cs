namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Classifier : GeneralizableElement,Namespace
        {
        AssociationEnd[] association { get; }
        ClassifierInState[] classifierInState { get; }
        ClassifierRole[] classifierRole { get; }
        Collaboration[] collaboration { get; }
        Feature[] feature { get; }
        Instance[] instance { get; }
        ObjectFlowState[] objectFlowState { get; }
        Generalization[] powertypeRange { get; }
        AssociationEnd[] specifiedEnd { get; }
        StructuralFeature[] typedFeature { get; }
        Parameter[] typedParameter { get; }
        }
    }
