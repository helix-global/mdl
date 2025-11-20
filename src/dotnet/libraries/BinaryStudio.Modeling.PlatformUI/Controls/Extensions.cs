using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
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
        #region M:Clone<T:Brush>({this}T,Double):T
        public static T Clone<T>(this T source,Double opacity)
            where T: Brush
            {
            var r = (T)source.Clone();
            r.Opacity = opacity;
            return r;
            }
        #endregion
        #region M:SetBinding({this}DependencyObject,DependencyProperty,DependencyObject,DependencyProperty,BindingMode,IValueConverter):BindingExpressionBase
        public static BindingExpressionBase SetBinding(this DependencyObject target,DependencyProperty targetProperty,DependencyObject source,DependencyProperty sourceProperty,BindingMode mode,IValueConverter converter) {
            if (target == null) { throw new ArgumentNullException(nameof(target)); }
            if (sourceProperty != null) {
                return BindingOperations.SetBinding(target, targetProperty, new Binding() {
                    Source = source,
                    Path = new PropertyPath(sourceProperty),
                    Mode = mode,
                    Converter = converter
                    });
                }
            return null;
            }
        #endregion
        #region M:SetBinding({this}DependencyObject,DependencyProperty,DependencyObject,DependencyProperty,BindingMode):BindingExpressionBase
        public static BindingExpressionBase SetBinding(this DependencyObject target,DependencyProperty targetProperty,DependencyObject source,DependencyProperty sourceProperty,BindingMode mode) {
            return SetBinding(target,targetProperty,source,sourceProperty,mode,null);
            }
        #endregion
        }
    }