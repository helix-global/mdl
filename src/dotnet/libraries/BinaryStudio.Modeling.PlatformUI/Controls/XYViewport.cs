using System.Windows;
using System.Windows.Controls.Primitives;

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
        }
    }
