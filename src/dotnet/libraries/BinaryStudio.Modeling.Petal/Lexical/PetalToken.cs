namespace BinaryStudio.Modeling.Petal
    {
    public class PetalToken
        {
        public PetalTokenType Type { get; }
        public PetalToken(PetalTokenType type)
            {
            Type = type;
            }
        }
    }