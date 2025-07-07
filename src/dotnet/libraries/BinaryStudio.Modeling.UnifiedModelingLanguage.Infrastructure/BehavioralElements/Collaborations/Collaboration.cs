namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Collaboration : GeneralizableElement,Namespace
        {
        Collaboration[] collaboration { get; }
        CollaborationInstanceSet[] collaborationInstanceSet { get; }
        ModelElement[] constrainingElement { get; }
        Interaction[] interaction { get; }
        Classifier representedClassifier { get; }
        Operation representedOperation { get; }
        Collaboration[] usedCollaboration { get; }
        }
    }