namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface CreateLinkAction : WriteLinkAction
        {
        LinkEndCreationData[] endData { get; }
        }
    }
