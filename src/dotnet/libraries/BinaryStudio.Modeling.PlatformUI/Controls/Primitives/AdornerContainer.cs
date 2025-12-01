using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace BinaryStudio.Modeling.PlatformUI.Controls.Primitives
    {
    internal class AdornerContainer<T> : Adorner
        where T: UIElement
        {
        #region P:Child:T
        private T child;
        public virtual T Child {
            get
                {
                return child;
                }
            set
                {
                AddVisualChild(value);
                child = value;
                InvalidateMeasure();
                }
            }
        #endregion
        #region P:VisualChildrenCount:Int32
        /// <summary>Gets the number of visual child elements within this element.</summary>
        /// <returns>The number of visual child elements for this element.</returns>
        protected override Int32 VisualChildrenCount { get {
            return (child != null)
                ? 1
                : 0;
            }}
        #endregion
        #region P:ChildOffset:Vector
        public static readonly DependencyProperty ChildOffsetProperty = DependencyProperty.Register(nameof(ChildOffset), typeof(Vector), typeof(AdornerContainer<T>), new PropertyMetadata(default(Vector),OnChildOffsetChanged));
        public Vector ChildOffset
            {
            get { return(Vector)GetValue(ChildOffsetProperty); }
            set { SetValue(ChildOffsetProperty, value); }
            }
        private static void OnChildOffsetChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            if (sender is AdornerContainer<T> source) {
                source.OnChildOffsetChanged();
                }
            }

        private void OnChildOffsetChanged() {
            InvalidateMeasure();
            InvalidateArrange();
            InvalidateVisual();
            }
        #endregion

        public AdornerContainer(UIElement adornedElement)
            : base(adornedElement)
            {
            }

        #region M:ArrangeOverride(Size):Size
        /// <summary>When overridden in a derived class, positions child elements and determines a size for a <see cref="T:System.Windows.FrameworkElement"/> derived class.</summary>
        /// <param name="finalSize">The final area within the parent that this element should use to arrange itself and its children.</param>
        /// <returns>The actual size used.</returns>
        protected override Size ArrangeOverride(Size finalSize) {
            if (child != null) {
                var sz = child.DesiredSize;
                child.Arrange(new Rect((Point)ChildOffset,sz));
                }
            return finalSize;
            }
        #endregion

        ///// <summary>Implements any custom measuring behavior for the adorner.</summary>
        ///// <returns>A <see cref="T:System.Windows.Size"/> object representing the amount of layout space needed by the adorner.</returns>
        ///// <param name="constraint">A size to constrain the adorner to.</param>
        //protected override Size MeasureOverride(Size constraint) {
        //    var size = new Size(AdornedElement.RenderSize.Width, AdornedElement.RenderSize.Height);
        //    var r = new Rect(0,0,size.Width,size.Height);
        //    var count = VisualChildrenCount;
        //    var offset = ChildOffsetInternal;
        //    for (var i = 0; i < count; i++) {
        //        if (GetVisualChild(i) is UIElement e) {
			     //   e.Measure(size);
        //            var sz = e.DesiredSize;
        //            r.Union(new Rect());
		      //      }
        //        }
        //    return base.MeasureOverride(constraint);
        //    }

        #region M:GetVisualChild(Int32):Visual
        /// <summary>Overrides <see cref="M:System.Windows.Media.Visual.GetVisualChild(System.Int32)"/>, and returns a child at the specified index from a collection of child elements.</summary>
        /// <param name="index">The zero-based index of the requested child element in the collection.</param>
        /// <returns>The requested child element. This should not return <see langword="null"/>; if the provided index is out of range, an exception is thrown.</returns>
        protected override Visual GetVisualChild(Int32 index) {
            return ((index == 0) && (child != null))
                ? child
                : base.GetVisualChild(index);
            }
        #endregion

        /// <summary>When overridden in a derived class, participates in rendering operations that are directed by the layout system. The rendering instructions for this element are not used directly when this method is invoked, and are instead preserved for later asynchronous use by layout and drawing. </summary>
        /// <param name="context">The drawing instructions for a specific element. This context is provided to the layout system.</param>
        protected override void OnRender(DrawingContext context)
            {
            base.OnRender(context);
            //if (IsVisible)
                {
                var pen = new Pen(Brushes.BlueViolet.Clone(), 1.0);
                //var brush = Brushes.BlueViolet.Clone();
                context.DrawRectangle(null, pen, new Rect(0, 0, ActualWidth, ActualHeight));
                }
            }
        }

    internal class AdornerContainer : AdornerContainer<UIElement>
        {
        public AdornerContainer(UIElement adornedElement)
            : base(adornedElement)
            {
            }
        }
    }
