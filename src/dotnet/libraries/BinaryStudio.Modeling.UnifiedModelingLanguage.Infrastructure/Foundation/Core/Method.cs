namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Method : BehavioralFeature
        {
        ProcedureExpression body { get; }
        Operation specification { get; }
        Procedure procedure { get; }
        }
    }
