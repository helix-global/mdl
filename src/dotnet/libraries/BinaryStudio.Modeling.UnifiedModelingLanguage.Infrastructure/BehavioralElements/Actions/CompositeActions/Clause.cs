namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Clause : Element
        {
        Action body { get; }
        Action test { get; }
        OutputPin[] bodyOutput { get; }
        OutputPin testOutput { get; }
        Clause[] successorClause { get; }
        Clause[] predecessorClause { get; }
        }
    }
