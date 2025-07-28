using System;
using System.Collections.Generic;

namespace RationalRose
    {
    public static class Extensions
        {
        internal class EmptyArray<T>
            {
            public static readonly T[] Value = new T[0];
            }

        #region M:AsEnumerable({this}IREICOMCategoryCollection):IEnumerable<IREICOMCategory>
        public static IEnumerable<IREICOMCategory> AsEnumerable(this IREICOMCategoryCollection source) {
            if (source != null) {
                var c = source.Count;
                for (Int16 i = 1; i <= c; i++) {
                    yield return source.GetAt(i);
                    }
                }
            }
        #endregion
        #region M:AsEnumerable({this}IREICOMControllableUnitCollection):IEnumerable<IREICOMControllableUnit>
        public static IEnumerable<IREICOMControllableUnit> AsEnumerable(this IREICOMControllableUnitCollection source) {
            if (source != null) {
                var c = source.Count;
                for (Int16 i = 1; i <= c; i++) {
                    yield return source.GetAt(i);
                    }
                }
            }
        #endregion

        #region M:ToArray(IREICOMCategoryCollection):IREICOMCategory[]
        public static IREICOMCategory[] ToArray(this IREICOMCategoryCollection source) {
            if (source != null) {
                var c = source.Count;
                var r = new IREICOMCategory[c];
                for (Int16 i = 1; i <= c; i++) {
                    r[i - 1] = source.GetAt(i);
                    }
                return r;
                }
            return EmptyArray<IREICOMCategory>.Value;
            }
        #endregion
        #region M:ToArray(IREICOMClassCollection):IREICOMClass[]
        public static IREICOMClass[] ToArray(this IREICOMClassCollection source) {
            if (source != null) {
                var c = source.Count;
                var r = new IREICOMClass[c];
                for (Int16 i = 1; i <= c; i++) {
                    r[i - 1] = source.GetAt(i);
                    }
                return r;
                }
            return EmptyArray<IREICOMClass>.Value;
            }
        #endregion
        #region M:ToArray(IREICOMAttributeCollection):IREICOMAttribute[]
        public static IREICOMAttribute[] ToArray(this IREICOMAttributeCollection source) {
            if (source != null) {
                var c = source.Count;
                var r = new IREICOMAttribute[c];
                for (Int16 i = 1; i <= c; i++) {
                    r[i - 1] = source.GetAt(i);
                    }
                return r;
                }
            return EmptyArray<IREICOMAttribute>.Value;
            }
        #endregion
        #region M:ToArray(IREICOMAssociationCollection):IREICOMAssociation[]
        public static IREICOMAssociation[] ToArray(this IREICOMAssociationCollection source) {
            if (source != null) {
                var c = source.Count;
                var r = new IREICOMAssociation[c];
                for (Int16 i = 1; i <= c; i++) {
                    r[i - 1] = source.GetAt(i);
                    }
                return r;
                }
            return EmptyArray<IREICOMAssociation>.Value;
            }
        #endregion
        #region M:ToArray(IREICOMControllableUnitCollection):IREICOMControllableUnit[]
        public static IREICOMControllableUnit[] ToArray(this IREICOMControllableUnitCollection source) {
            if (source != null) {
                var c = source.Count;
                var r = new IREICOMControllableUnit[c];
                for (Int16 i = 1; i <= c; i++) {
                    r[i - 1] = source.GetAt(i);
                    }
                return r;
                }
            return EmptyArray<IREICOMControllableUnit>.Value;
            }
        #endregion
        }
    }