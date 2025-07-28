using System;
using System.Collections.Generic;
using RationalRose;

namespace BinaryStudio.Modeling.Petal.External
    {
    public class REIModel : REIPackage<IREICOMModel>
        {
        public REINotationTypes Notation { get { return Source.Notation; }}
        private REIModel(IREICOMModel source)
            :base(source)
            {
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

        public override IList<REIControllableUnit> NestedUnits { get {
            if (m_units != null) { return m_units; }
            var r = new List<REIControllableUnit>();
            r.Add(new REICategory<IREICOMCategory>(Source.RootUseCaseCategory));
            r.Add(new REICategory<IREICOMCategory>(Source.RootCategory));
            r.Add(new REISubsystem<IREICOMSubsystem>(Source.RootSubsystem));
            m_units = r;
            return r;
            }}

        public override String ToString()
            {
            return "Model";
            }

        private IList<REIControllableUnit> m_units;
        }
    }