using System;
using RationalRose;

namespace BinaryStudio.Modeling.Petal.External
    {
    public interface IREIPackage : IREIControllableUnit
        {
        }

    public class REIPackage<T> : REIControllableUnit<T>,IREIPackage
        where T: IREICOMPackage
        {
        public Boolean IsRootPackage { get { return Source.IsRootPackage(); }}
        internal REIPackage(T source)
            :base(source)
            {
            }
        }
    }