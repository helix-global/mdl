using System;
using System.Windows;
using System.Windows.Controls;
using BinaryStudio.Modeling.PlatformUI.Controls.Primitives;

namespace BinaryStudio.Modeling.PlatformUI.Controls
    {
    public class XYViewportShape : XYViewportObject,IXYViewportBoundObject
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
        #region P:Bound:Rect
        public Rect Bound { get {
            return XYViewport.GetBound(this);
            }}
        #endregion
        }
    }
