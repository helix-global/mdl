namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface CreateLinkObjectAction : CreateLinkAction
        {
        OutputPin result { get; }
        }
    }
