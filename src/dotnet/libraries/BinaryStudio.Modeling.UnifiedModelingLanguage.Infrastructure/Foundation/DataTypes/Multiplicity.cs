using BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Multiplicity
        {
        [Multiplicity("1..*")] MultiplicityRange[] range { get; }
        }
    }
