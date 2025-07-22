using RationalRose;

namespace BinaryStudio.Modeling.Petal.External
    {
    public class REIPackage : REIControllableUnit
        {
        internal REIPackage(IREICOMPackage source)
            {
            this.source = source;
            }

        private readonly IREICOMPackage source;
        }
    }