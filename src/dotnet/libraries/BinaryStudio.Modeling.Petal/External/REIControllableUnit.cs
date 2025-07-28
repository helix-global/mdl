using System;
using System.Collections.Generic;
using RationalRose;

namespace BinaryStudio.Modeling.Petal.External
    {
    public interface REIControllableUnit
        {

        }

    public class REIControllableUnit<T> : REIItem<T>,REIControllableUnit
        where T: IREICOMControllableUnit
        {
        public String FileName { get { return Source.GetFileName(); }}
        public Boolean IsControlled { get { return Source.IsControlled(); }}
        public Boolean IsLoaded     { get { return Source.IsLoaded();     }}
        public Boolean IsLocked     { get { return Source.IsLocked();     }}
        public Boolean IsModifiable { get { return Source.IsModifiable(); }}
        public Boolean IsModified   { get { return Source.IsModified();   }}
        public Boolean NeedsRefreshing { get { return Source.NeedsRefreshing(); }}

        internal REIControllableUnit(T source)
            :base(source)
            {
            }

        public virtual IList<REIControllableUnit> NestedUnits { get {
            var o = Source.GetSubUnitItems().ToArray();
            var r = new List<REIControllableUnit>();
            foreach (var i in o) {
                r.Add(new REIControllableUnit<IREICOMControllableUnit>(i));
                }
            return r;
            }}
        }
    }