using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BinaryStudio.Modeling.PlatformUI.Controls
    {
    public class XYViewportShape : XYViewportItem
        {
        static XYViewportShape()
            {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(XYViewportShape), new FrameworkPropertyMetadata(typeof(XYViewportShape)));
            }

        #region P:Content:Object
        public static readonly DependencyProperty ContentProperty = ContentControl.ContentProperty.AddOwner(typeof(XYViewportShape),new FrameworkPropertyMetadata(default(Object)));
        public Object Content
            {
            get { return GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
            }
        #endregion
        #region P:Offset:Vector
        public static readonly DependencyProperty OffsetProperty = XYViewport.OffsetProperty.AddOwner(typeof(XYViewportShape), new PropertyMetadata(default(Vector)));
        public Vector Offset
            {
            get { return (Vector)GetValue(OffsetProperty); }
            set { SetValue(OffsetProperty, value); }
            }
        #endregion
        }
    }
