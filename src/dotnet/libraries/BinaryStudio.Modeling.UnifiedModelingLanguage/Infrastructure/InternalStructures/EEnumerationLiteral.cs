namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EEnumerationLiteral : EInstanceSpecification, EnumerationLiteral
        {
        public Enumeration Classifier { get; }
        public Enumeration Enumeration { get;set; }
        public Enumeration classifier()
            {
            throw new System.NotImplementedException();
            }
        }
    }