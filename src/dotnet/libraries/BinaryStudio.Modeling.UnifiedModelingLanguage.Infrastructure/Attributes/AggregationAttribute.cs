namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.Attributes
    {
    public class AggregationAttribute : System.Attribute
        {
        public AggregationKind Aggregation { get; }
        public AggregationAttribute(AggregationKind Aggregation) {
            this.Aggregation = Aggregation;
            }
        }
    }