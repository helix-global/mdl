using RationalRose;

namespace BinaryStudio.Modeling.Petal.External
    {
    public class REISubsystem<T> : REIPackage<T>
        where T:IREICOMSubsystem
        {
        internal REISubsystem(T source)
            : base(source)
            {
            }
        }
    }