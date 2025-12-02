using System;
using System.Windows;

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
        #region M:Scale({this}Rect,Double):Vector
        public static Rect Scale(this Rect source,Double factor) {
            if (source.IsEmpty) { return source; }
            source.Scale(factor,factor);
            return source;
            }
        #endregion
        }
    }