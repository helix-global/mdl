using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace BinaryStudio.Modeling.PlatformUI.Controls
    {
    public class XYViewport : MultiSelector
        {
        static XYViewport()
            {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(XYViewport), new FrameworkPropertyMetadata(typeof(XYViewport)));
            }

        #region P:XYViewport.Offset:Vector
        internal static readonly DependencyProperty OffsetProperty = DependencyProperty.RegisterAttached("Offset", typeof(Vector), typeof(XYViewport), new PropertyMetadata(default(Vector)));
        internal static void SetOffset(DependencyObject e,Vector value)
            {
            e.SetValue(OffsetProperty,value);
            }

        public static Vector GetOffset(DependencyObject e)
            {
            return (Vector)e.GetValue(OffsetProperty);
            }
        #endregion
        #region P:Scale:Double
        public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register(nameof(Scale),typeof(Double),typeof(XYViewport),new PropertyMetadata(1.0,OnScaleChanged,ScaleCoerceValue));
        private static Object ScaleCoerceValue(DependencyObject sender,Object basevalue) {
            if (basevalue is Double value) {
                if (value > 0) {
                    var o = ((Int32)(value*100))/10;
                    o = Math.Max(1,o);
                    o = Math.Min(o,50);
                    value = ((Double)o)*0.1;
                    }
                else
                    {
                    value = 0.1;
                    }
                return value;
                }
            return 1.0;
            }

        private static void OnScaleChanged(DependencyObject sender,DependencyPropertyChangedEventArgs e)
            {
            }

        public Double Scale
            {
            get { return (Double)GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
            }
        #endregion
        #region P:ItemsHost:Panel
        public Panel ItemsHost { get {
            var pi = typeof(ItemsControl).GetProperty("ItemsHost", BindingFlags.Instance | BindingFlags.NonPublic);
            #if NET40
            return (Panel)pi.GetValue(this, null);
            #else
            return (Panel)pi.GetValue(this);
            #endif
            }}
        #endregion

        #region M:OnPreviewMouseWheel(MouseWheelEventArgs)
        /// <summary>Invoked when an unhandled <see cref="E:System.Windows.Input.Mouse.PreviewMouseWheel"/> attached event reaches an element in its route that is derived from this class. Implement this method to add class handling for this event.</summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.MouseWheelEventArgs"/> that contains the event data.</param>
        protected override void OnPreviewMouseWheel(MouseWheelEventArgs e) {
            if (e.Delta != 0) {
                if (Keyboard.IsKeyDown(Key.LeftCtrl)) {
                    var i = e.Delta > 0 ? +1 : -1;
                    var o = ((Int32)(Scale*100))/10;
                    o = Math.Max(1,o);
                    o = Math.Min(o,50);
                    o += i;
                    Scale = o*0.1;
                    e.Handled = true;
                    ItemsHost?.InvalidateVisual();
                    return;
                    }
                }
            base.OnPreviewMouseWheel(e);
            }
        #endregion
        #region M:OnApplyTemplate
        /// <summary>When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.</summary>
        public override void OnApplyTemplate() {
            base.OnApplyTemplate();
            ViewportSurface = GetTemplateChild("ViewportSurface") as XYViewportSurface;
            ViewportSurface?.SetBinding(XYViewportSurface.ScaleProperty,this,ScaleProperty,BindingMode.OneWay);
            }
        #endregion

        private XYViewportSurface ViewportSurface;
        }
    }
