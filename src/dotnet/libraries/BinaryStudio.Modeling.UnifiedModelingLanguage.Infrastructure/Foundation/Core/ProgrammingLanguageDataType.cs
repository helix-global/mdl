namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ProgrammingLanguageDataType : DataType
        {
        TypeExpression expression { get; }
        }
    }
