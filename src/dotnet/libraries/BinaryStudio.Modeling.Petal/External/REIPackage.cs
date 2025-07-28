using System;
using RationalRose;

namespace BinaryStudio.Modeling.Petal.External
    {
    public class REIPackage<T> : REIControllableUnit<T>
        where T: IREICOMPackage
        {
        public Boolean IsRootPackage { get { return Source.IsRootPackage(); }}
        internal REIPackage(T source)
            :base(source)
            {
            }
        }
    }