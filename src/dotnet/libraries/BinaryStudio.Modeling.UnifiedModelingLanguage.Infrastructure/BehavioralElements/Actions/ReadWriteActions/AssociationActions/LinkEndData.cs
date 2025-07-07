namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface LinkEndData
        {
        AssociationEnd end { get; }
        InputPin value { get; }
        QualifierValue[] qualifier { get; }
        }
    }
