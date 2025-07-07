namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface QualifierValue
        {
        Attribute qualifier { get; }
        InputPin value { get; }
        }
    }
