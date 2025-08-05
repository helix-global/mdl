using RationalRose;

namespace BinaryStudio.Modeling.Petal.External
    {
    public interface IREIItem : IREIElement
        {
        }

    public class REIItem<T> : REIElement<T>,IREIItem
        where T: IREICOMItem
        {
        public REIItem(T source)
            : base(source)
            {
            }
        }
    }