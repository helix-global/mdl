using RationalRose;

namespace BinaryStudio.Modeling.Petal.External
    {
    public class REIItem
        {
        }

    public class REIItem<T> : REIElement<T>
        where T: IREICOMItem
        {
        public REIItem(T source)
            : base(source)
            {
            }
        }
    }