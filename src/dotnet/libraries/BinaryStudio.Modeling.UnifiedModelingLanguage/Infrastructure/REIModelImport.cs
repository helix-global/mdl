using System;
using BinaryStudio.Modeling.Petal.External;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures;
using RationalRose;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public class REIModelImport
        {
        #region M:ReadFrom(String,{out}Model):Boolean
        public Boolean ReadFrom(String FileName,out Model o) {
            if (FileName == null) { throw new ArgumentNullException(nameof(FileName)); }
            o = ReadFrom(FileName);
            return o != null;
            }
        #endregion
        #region M:ReadFrom(String):Model
        public Model ReadFrom(String FileName) {
            if (FileName == null) { throw new ArgumentNullException(nameof(FileName)); }
            var r = new REICoClassApplication();
            var o = r.OpenRoseModel(FileName,false);
            return BuildFrom(o);
            }
        #endregion
        
        #region M:BuildFrom(IREICOMModel):Model
        private Model BuildFrom(IREICOMModel source) {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }
            var r = new EModel{
                Name = source.Name
                };
            r.PackagedElement.Add(BuildFrom(source.RootUseCaseCategory));
            r.PackagedElement.Add(BuildFrom(source.RootCategory));
            r.PackagedElement.Add(BuildFrom(source.RootSubsystem));
            return r;
            }
        #endregion
        #region M:BuildFrom(IREICOMCategory):Package
        private Package BuildFrom(IREICOMCategory source) {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }
            var r = BuildFrom((IREICOMPackage)source);
            return r;
            }
        #endregion
        #region M:BuildFrom(IREICOMSubsystem):Package
        private Package BuildFrom(IREICOMSubsystem source) {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }
            var r = BuildFrom((IREICOMPackage)source);
            return r;
            }
        #endregion
        #region M:BuildFrom(IREICOMPackage):Package
        private Package BuildFrom(IREICOMPackage source) {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }
            var r = BuildFrom((IREICOMControllableUnit)source);
            return r;
            }
        #endregion
        #region M:BuildFrom(IREICOMControllableUnit):Package
        private Package BuildFrom(IREICOMControllableUnit source) {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }
            var r = new EPackage {
                Name = source.Name
                };
            foreach (var i in source.GetSubUnitItems().AsEnumerable()) {
                r.PackagedElement.Add(BuildFrom(i));
                }
            return r;
            }
        #endregion
        }
    }