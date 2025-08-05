using RationalRose;

namespace BinaryStudio.Modeling.Petal.External
    {
    public class REICategory : REICategory<IREICOMCategory>
        {
        internal REICategory(IREICOMCategory source)
            : base(source)
            {
            }
        }

    public abstract class REICategory<T> : REIPackage<T>
        where T: IREICOMCategory
        {
        protected REICategory(T source)
            : base(source)
            {
            }
        }
    }