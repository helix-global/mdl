namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface AssociationEndRole : AssociationEnd
        {
        Attribute[] availableQualifier { get; }
        AssociationEnd @base { get; }
        Multiplicity collaborationMultiplicity { get; }
        }
    }
