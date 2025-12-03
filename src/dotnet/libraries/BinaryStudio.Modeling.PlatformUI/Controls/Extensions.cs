using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Threading;

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
        #region M:DoAfterLoaded({this}FrameworkElement,Action)
        public static void DoAfterLoaded(this FrameworkElement source,Action predicate) {
            if (predicate == null) { throw new ArgumentNullException(nameof(predicate)); }
            if (source != null) {
                void Handler(Object sender, RoutedEventArgs e) {
                    predicate.Invoke();
                    source.Loaded -= Handler;
                    }
                source.Loaded += Handler;
                }
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
        #region M:AsReadOnly<T>({this}IEnumerable<T>):IList<T>
        public static IList<T> AsReadOnly<T>(this IEnumerable<T> source)
            {
            return new ReadOnlyCollection<T>(source.ToArray());
            }
        #endregion
        #region M:InvalidateMeasure({this}UIElement,CancellationToken):Task
        public static async Task InvalidateMeasure(this UIElement element,CancellationToken cancellationToken) {
            await element.Dispatcher.InvokeAsync(element.InvalidateMeasure,DispatcherPriority.Normal,cancellationToken);
            }
        #endregion
        #region M:InvalidateVisual({this}UIElement,CancellationToken):Task
        public static async Task InvalidateVisual(this UIElement element,CancellationToken cancellationToken) {
            await element.Dispatcher.InvokeAsync(element.InvalidateVisual,DispatcherPriority.Normal,cancellationToken);
            }
        #endregion
        }
    }