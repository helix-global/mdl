namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public abstract class Package : Namespace,GeneralizableElement
        {
        ElementImport[] elementImport { get; }
        }
    }
