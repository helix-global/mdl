using System;
using RationalRose;

namespace BinaryStudio.Modeling.Petal.External
    {
    public class REIModel : REIPackage
        {
        private REIModel(IREICOMModel source)
            :base(source)
            {
            this.source = source;
            }

        #region M:ReadFrom(String,{out}REIModel):Boolean
        public static Boolean ReadFrom(String FileName,out REIModel o) {
            if (FileName == null) { throw new ArgumentNullException(nameof(FileName)); }
            o = ReadFrom(FileName);
            return o != null;
            }
        #endregion
        #region M:ReadFrom(String):Boolean
        public static REIModel ReadFrom(String FileName) {
            if (FileName == null) { throw new ArgumentNullException(nameof(FileName)); }
            var r = new REICoClassApplication();
            return new REIModel(r.OpenRoseModel(FileName,false));
            }
        #endregion

        private readonly IREICOMModel source;
        }
    }