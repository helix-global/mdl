using System;
using System.Collections.Generic;
using RationalRose;

namespace BinaryStudio.Modeling.Petal.External
    {
    public interface IREIModel : IREIPackage
        {
        }

    public class REIModel : REIPackage<IREICOMModel>,IREIModel
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

        public override IList<IREIControllableUnit> NestedUnits { get {
            if (m_units != null) { return m_units; }
            var r = new List<IREIControllableUnit>();
            r.Add(new REICategory(Source.RootUseCaseCategory));
            r.Add(new REICategory(Source.RootCategory));
            r.Add(new REISubsystem<IREICOMSubsystem>(Source.RootSubsystem));
            m_units = r;
            return r;
            }}

        public override String ToString()
            {
            return "Model";
            }

        private IList<IREIControllableUnit> m_units;
        }
    }