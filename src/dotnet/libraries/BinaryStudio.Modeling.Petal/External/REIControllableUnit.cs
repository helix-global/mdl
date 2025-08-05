using System;
using System.Collections.Generic;
using RationalRose;

namespace BinaryStudio.Modeling.Petal.External
    {
    public interface IREIControllableUnit : IREIItem
        {
        IList<IREIControllableUnit> NestedUnits { get; }
        }

    public class REIControllableUnit : REIControllableUnit<IREICOMControllableUnit>
        {
        internal REIControllableUnit(IREICOMControllableUnit source)
            : base(source)
            {
            }
        }

    public abstract class REIControllableUnit<T> : REIItem<T>,IREIControllableUnit
        where T: IREICOMControllableUnit
        {
        public String FileName { get { return Source.GetFileName(); }}
        public Boolean IsControlled { get { return Source.IsControlled(); }}
        public Boolean IsLoaded     { get { return Source.IsLoaded();     }}
        public Boolean IsLocked     { get { return Source.IsLocked();     }}
        public Boolean IsModifiable { get { return Source.IsModifiable(); }}
        public Boolean IsModified   { get { return Source.IsModified();   }}
        public Boolean NeedsRefreshing { get { return Source.NeedsRefreshing(); }}

        protected REIControllableUnit(T source)
            :base(source)
            {
            }

        public virtual IList<IREIControllableUnit> NestedUnits { get {
            var o = Source.GetSubUnitItems().ToArray();
            var r = new List<IREIControllableUnit>();
            foreach (var i in o) {
                r.Add(new REIControllableUnit(i));
                }
            return r;
            }}

        public virtual IList<IREIControllableUnit> PackagedElement { get {
            var r = new List<IREIControllableUnit>();
            r.AddRange(NestedUnits);
            return r;
            }}
        }
    }