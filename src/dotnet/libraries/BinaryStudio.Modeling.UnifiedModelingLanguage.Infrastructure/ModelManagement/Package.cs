namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Package : GeneralizableElement,Namespace
        {
        ElementImport[] elementImport { get; }
        }
    }
