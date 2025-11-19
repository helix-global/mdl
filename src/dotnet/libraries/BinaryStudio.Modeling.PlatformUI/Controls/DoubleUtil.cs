using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace BinaryStudio.Modeling.PlatformUI.Controls
    {
    internal static class DoubleUtil
        {
        #region M:Round(Vector):Vector
        public static Vector Round(Vector source) {
            return new Vector(
                Math.Round(source.X),
                Math.Round(source.Y));
            }
        #endregion
        #region M:Round(Rect):Rect
        public static Rect Round(Rect source) {
            if (source.IsEmpty) { return source; }
            return new Rect(
                Math.Round(source.Left),
                Math.Round(source.Top),
                Math.Round(source.Width),
                Math.Round(source.Height));
            }
        #endregion
        #region M:Ancestors<T>({this}DependencyObject):IEnumerable<T>
        public static IEnumerable<T> Ancestors<T>(this DependencyObject source)
            where T: class
            {
            return Ancestors<T>(source,GetVisualOrLogicalParent);
            }
        #endregion
        #region M:Ancestors<T>({this}DependencyObject,Func<DependencyObject,DependencyObject>):IEnumerable<T>
        public static IEnumerable<T> Ancestors<T>(this DependencyObject source, Func<DependencyObject,DependencyObject> selector)
            where T: class
            {
            if (selector == null) { throw new ArgumentNullException(nameof(selector)); }
            if (source == null) { yield break; }
            for (var i = selector(source); i != null; i = selector(i)) {
                if (i is T e) {
                    yield return e;
                    }
                }
            }
        #endregion
        #region M:GetVisualOrLogicalParent({this}DependencyObject):DependencyObject
        public static DependencyObject GetVisualOrLogicalParent(this DependencyObject source) {
            if (source == null) { return null; }
            return (source is Visual)
                ? VisualTreeHelper.GetParent(source) ?? LogicalTreeHelper.GetParent(source)
                : LogicalTreeHelper.GetParent(source);
            }
        #endregion
        }
    }