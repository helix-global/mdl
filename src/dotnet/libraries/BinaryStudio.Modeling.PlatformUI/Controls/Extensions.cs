using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace BinaryStudio.Modeling.PlatformUI.Controls
    {
    internal static class Extensions
        {
        #region M:DrawText({this}DrawingContext,Point,String)
        public static void DrawText(this DrawingContext context,Point origin,String text) {
            DrawText(context,origin,8.0,text);
            }
        #endregion
        #region M:DrawText({this}DrawingContext,Point,Double,String)
        public static void DrawText(this DrawingContext context, Point origin, Double fontsize, String text) {
            #if NET40 || NET45
            var r = new FormattedText(text, CultureInfo.CurrentUICulture,
                FlowDirection.LeftToRight,new Typeface("Segoe UI"),
                fontsize, Brushes.Gray);
            #else
            var r = new FormattedText(text, CultureInfo.CurrentUICulture,
                FlowDirection.LeftToRight,new Typeface("Segoe UI"),
                fontsize, Brushes.Gray, pixelsPerDip: 1.0);
            #endif
            context.DrawText(r, origin);
            }
        #endregion
        #region M:DrawText({this}DrawingContext,Point,FormattedText)
        public static void DrawText(this DrawingContext context,Point origin,FormattedText text) {
            context.DrawText(text, origin);
            }
        #endregion
        }
    }