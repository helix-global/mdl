using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register(nameof(Scale),typeof(Double),typeof(XYViewport), new PropertyMetadata(1.0));
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
                    var i = e.Delta > 0 ? 1.1 : 0.9;
                    Scale = Scale*i;
                    e.Handled = true;
                    ItemsHost?.InvalidateVisual();
                    return;
                    }
                }
            base.OnPreviewMouseWheel(e);
            }
        #endregion
        }
    }
