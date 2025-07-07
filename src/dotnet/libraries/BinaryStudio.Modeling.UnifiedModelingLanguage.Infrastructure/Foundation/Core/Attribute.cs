namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Attribute : StructuralFeature
        {
        AssociationEnd associationEnd { get; }
        AssociationEndRole[] associationEndRole { get; }
        AttributeLink[] attributeLink { get; }
        Expression initialValue { get; }
        }
    }
