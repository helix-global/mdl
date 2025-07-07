namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface PresentationElement : Element
        {
        ModelElement[] subject { get; }
        }
    }
