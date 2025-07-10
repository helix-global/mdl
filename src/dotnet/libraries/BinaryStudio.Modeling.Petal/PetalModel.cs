using System;

namespace BinaryStudio.Modeling.Petal
    {
    public class PetalModel : PetalPackage
        {
        public static Boolean ReadFrom(PetalDocument source,out PetalModel o) {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }
            o = default;
            return false;
            }
        }
    }