namespace BinaryStudio.Modeling.Petal
    {
    internal class PetalToken
        {
        public PetalTokenType Type { get; }
        public PetalToken(PetalTokenType type)
            {
            Type = type;
            }
        }
    }