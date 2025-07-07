using BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Enumeration : DataType
        {
        [Multiplicity("1..*")] EnumerationLiteral[] literal { get; }
        }
    }
