namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Generalization : Relationship
        {
        Name discriminator { get; }
        GeneralizableElement child { get; }
        GeneralizableElement parent { get; }
        Classifier powertype { get; }
        }
    }
