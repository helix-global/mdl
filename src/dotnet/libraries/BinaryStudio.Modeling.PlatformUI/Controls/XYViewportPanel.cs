using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace BinaryStudio.Modeling.PlatformUI.Controls
    {
    public class XYViewportPanel : Panel,IScrollInfo
        {
        #region P:{Horizontal,Vertical}Offset:Vector
        private static readonly DependencyPropertyKey OffsetPropertyKey = DependencyProperty.RegisterReadOnly(nameof(Offset), typeof(Vector), typeof(XYViewportPanel),new PropertyMetadata(default(Vector), OnOffsetChanged, OnOffsetCoerceValue));
        private static Object OnOffsetCoerceValue(DependencyObject sender, Object basevalue) {
            var r = DoubleUtil.Round((Vector)basevalue);
            //if (sender is XYViewportPanel source) {
            //    r.X = source.CanHorizontallyScrollComputed ? r.X : 0.0;
            //    r.Y = source.CanVerticallyScrollComputed   ? r.Y : 0.0;
            //    if (r.X < 0) { r.X = 0.0; }
            //    if (r.Y < 0) { r.Y = 0.0; }
            //    }
            return r;
            }

        /// <summary>Identifies the <see cref="Offset"/> dependency property.</summary>
        /// <returns>The identifier for the <see cref="Offset"/> dependency property.</returns>
        public static readonly DependencyProperty OffsetProperty = OffsetPropertyKey.DependencyProperty;
        private static void OnOffsetChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            if (sender is XYViewportPanel source) {
                //if (source.LinkedScrollInfo != null) {
                //    var value = (Vector)e.NewValue;
                //    source.LinkedScrollInfo.SetHorizontalOffset(value.X);
                //    source.LinkedScrollInfo.SetVerticalOffset(value.Y);
                //    }
                //Debug.Print("OnOffsetChanged:{{{0}}}->{{{1}}}",e.OldValue,e.NewValue);
                source.OnOffsetChanged();
                }
            }

        protected virtual void OnOffsetChanged() {
            InvalidateScrollInfo();
            InvalidateArrange();
            }

        /// <summary>
        /// Gets the vertical and horizontal offset of scrolled content.
        /// </summary>
        public Vector Offset {
            get { return (Vector)GetValue(OffsetProperty); }
            protected set { SetValue(OffsetPropertyKey, value); }
            }
        /// <summary>Gets the horizontal offset of the scrolled content.</summary>
        /// <returns>A <see cref="T:System.Double" /> that represents, in device independent pixels, the horizontal offset. This property has no default value.</returns>
        Double IScrollInfo.HorizontalOffset
            {
            get { return Offset.X; }
            }
        Double IScrollInfo.VerticalOffset
            {
            get { return Offset.Y; }
            }
        #endregion
        #region P:Can{Horizontally,Vertically}Scroll:Boolean
        #region P:IScrollInfo.CanHorizontallyScroll:Boolean
        public static readonly DependencyProperty CanHorizontallyScrollProperty = DependencyProperty.Register(nameof(CanHorizontallyScroll),typeof(Boolean),typeof(XYViewportPanel),new PropertyMetadata(default(Boolean), OnCanHorizontallyScrollChanged));
        private static void OnCanHorizontallyScrollChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            if (sender is XYViewportPanel source) {
                //if (source.LinkedScrollInfo != null) { source.LinkedScrollInfo.CanHorizontallyScroll = (Boolean)e.NewValue; }
                source.InvalidateScrollInfo();
                }
            }

        /// <summary>Gets or sets a value that indicates whether scrolling on the horizontal axis is possible.</summary>
        /// <returns>true if scrolling is possible; otherwise, false. This property has no default value.</returns>
        public Boolean CanHorizontallyScroll
            {
            get { return (Boolean)GetValue(CanHorizontallyScrollProperty); }
            set { SetValue(CanHorizontallyScrollProperty, value); }
            }
        #endregion
        #region P:IScrollInfo.CanVerticallyScroll:Boolean
        public static readonly DependencyProperty CanVerticallyScrollProperty = DependencyProperty.Register(nameof(CanVerticallyScroll),typeof(Boolean),typeof(XYViewportPanel),new PropertyMetadata(default(Boolean), OnCanVerticallyScrollChanged));
        private static void OnCanVerticallyScrollChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            if (sender is XYViewportPanel source) {
                //if (source.LinkedScrollInfo != null) { source.LinkedScrollInfo.CanVerticallyScroll = (Boolean)e.NewValue; }
                source.InvalidateScrollInfo();
                }
            }

        /// <summary>Gets or sets a value that indicates whether scrolling on the vertical axis is possible. </summary>
        /// <returns>true if scrolling is possible; otherwise, false. This property has no default value.</returns>
        public Boolean CanVerticallyScroll
            {
            get { return (Boolean)GetValue(CanVerticallyScrollProperty); }
            set { SetValue(CanVerticallyScrollProperty, value); }
            }
        #endregion
        #endregion
        #region P:Extent{Width,Height}:Vector
        private static readonly DependencyPropertyKey ExtentPropertyKey = DependencyProperty.RegisterReadOnly(nameof(Extent),typeof(Vector),typeof(XYViewportPanel),new PropertyMetadata(default(Vector), OnExtentChanged));
        /// <summary>Identifies the <see cref="Extent"/> dependency property.</summary>
        /// <returns>The identifier for the <see cref="Extent"/> dependency property.</returns>
        public static readonly DependencyProperty ExtentProperty = ExtentPropertyKey.DependencyProperty;
        private static void OnExtentChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            if (sender is XYViewportPanel source) {
                source.OnExtentChanged();
                }
            }

        protected virtual void OnExtentChanged() {
            InvalidateScrollInfo();
            }

        /// <summary>
        /// Gets the vertical and horizontal size of the extent for this content.
        /// </summary>
        public Vector Extent {
            get { return (Vector)GetValue(ExtentProperty); }
            protected set { SetValue(ExtentPropertyKey, value); }
            }
        #region P:IScrollInfo.ExtentWidth:Double
        /// <summary>Gets the horizontal size of the extent.</summary>
        /// <returns>A <see cref="T:System.Double"/> that represents, in device independent pixels, the horizontal size of the extent. This property has no default value.</returns>
        public Double ExtentWidth { get {
            return Extent.X;
            }}
        #endregion
        #region P:IScrollInfo.ExtentHeight:Double
        /// <summary>Gets the vertical size of the extent.</summary>
        /// <returns>A <see cref="T:System.Double"/> that represents, in device independent pixels, the vertical size of the extent.
        /// This property has no default value.</returns>
        public Double ExtentHeight { get {
            return Extent.Y;
            }}
        #endregion
        #endregion
        #region P:Viewport{Width,Height}:Vector
        private static readonly DependencyPropertyKey ViewportPropertyKey = DependencyProperty.RegisterReadOnly(nameof(Viewport),typeof(Vector),typeof(XYViewportPanel),new PropertyMetadata(default(Vector), OnViewportChanged));
        /// <summary>Identifies the <see cref="Viewport"/> dependency property.</summary>
        /// <returns>The identifier for the <see cref="Viewport"/> dependency property.</returns>
        public static readonly DependencyProperty ViewportProperty = ViewportPropertyKey.DependencyProperty;
        private static void OnViewportChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            if (sender is XYViewportPanel source) {
                source.OnViewportChanged(
                    (Vector)e.NewValue,
                    (Vector)e.OldValue);
                }
            }

        protected virtual void OnViewportChanged(Vector NewValue, Vector OldValue) {
            //Debug.Print("OnViewportChanged:{{{0}}}->{{{1}}}",OldValue,NewValue);
            if ((Offset.X > 0) || (Offset.Y > 0)) {
                var offsetP = NewValue-OldValue;
                var offsetO = Offset - offsetP;
                var offsetN = Offset;
                if (Offset.X > 0) { offsetN = new Vector(Math.Max(offsetO.X,0),offsetN.Y); }
                if (Offset.Y > 0) { offsetN = new Vector(offsetN.X,Math.Max(offsetO.Y,0)); }
                Offset = offsetN;
                }
            InvalidateScrollInfo();
            }

        /// <summary>
        /// Gets the vertical and horizontal size of the viewport for this content.
        /// </summary>
        public Vector Viewport {
            get { return (Vector)GetValue(ViewportProperty); }
            protected set { SetValue(ViewportPropertyKey, value); }
            }
        #region P:IScrollInfo.ViewportWidth:Double
        /// <summary>Gets the horizontal size of the viewport for this content.</summary>
        /// <returns>A <see cref="T:System.Double" /> that represents, in device independent pixels, the horizontal size of the viewport for this content. This property has no default value.</returns>
        public Double ViewportWidth { get {
            return Viewport.X;
            }}
        #endregion
        #region P:IScrollInfo.ViewportHeight:Double
        /// <summary>Gets the vertical size of the viewport for this content.</summary>
        /// <returns>A <see cref="T:System.Double" /> that represents, in device independent pixels, the vertical size of the viewport for this content. This property has no default value.</returns>
        public Double ViewportHeight { get {
            return Viewport.Y;
            }}
        #endregion
        #endregion
        #region P:IScrollInfo.ScrollOwner:ScrollViewer
        ScrollViewer IScrollInfo.ScrollOwner
            {
            get { return m_scrollowner; }
            set { m_scrollowner = value; }
            }
        #endregion

        #region M:IScrollInfo.Line{Up,Down,Left,Right}
        #region M:IScrollInfo.LineUp
        /// <summary>Scrolls up within content by one logical unit. </summary>
        void IScrollInfo.LineUp()
            {
            ((IScrollInfo)this).SetVerticalOffset(Offset.Y - 25);
            }
        #endregion
        #region M:IScrollInfo.LineDown
        /// <summary>Scrolls down within content by one logical unit. </summary>
        void IScrollInfo.LineDown()
            {
            ((IScrollInfo)this).SetVerticalOffset(Math.Round(Offset.Y + 25));
            }
        #endregion
        #region M:IScrollInfo.LineLeft
        /// <summary>Scrolls left within content by one logical unit.</summary>
        void IScrollInfo.LineLeft()
            {
            ((IScrollInfo)this).SetVerticalOffset(Math.Round(Offset.Y - 25));
            }
        #endregion
        #region M:IScrollInfo.LineRight
        /// <summary>Scrolls right within content by one logical unit.</summary>
        void IScrollInfo.LineRight()
            {
            ((IScrollInfo)this).SetVerticalOffset(Math.Round(Offset.X + 25));
            }
        #endregion
        #endregion
        #region M:IScrollInfo.Page{Up,Down,Left,Right}
        #region M:IScrollInfo.PageUp
        /// <summary>Scrolls up within content by one page.</summary>
        void IScrollInfo.PageUp()
            {
            ((IScrollInfo)this).SetVerticalOffset(Offset.Y - Viewport.Y);
            }
        #endregion
        #region M:IScrollInfo.PageDown
        /// <summary>Scrolls down within content by one page.</summary>
        void IScrollInfo.PageDown()
            {
            ((IScrollInfo)this).SetVerticalOffset(Offset.Y + Viewport.Y);
            }
        #endregion
        #region M:IScrollInfo.PageLeft
        /// <summary>Scrolls left within content by one page.</summary>
        void IScrollInfo.PageLeft()
            {
            ((IScrollInfo)this).SetHorizontalOffset(Offset.X - Viewport.X);
            }
        #endregion
        #region M:IScrollInfo.PageRight
        /// <summary>Scrolls right within content by one page.</summary>
        void IScrollInfo.PageRight()
            {
            ((IScrollInfo)this).SetHorizontalOffset(Offset.X + Viewport.X);
            }
        #endregion
        #endregion
        #region M:IScrollInfo.MouseWheel{Up,Down,Left,Right}
        #region M:IScrollInfo.MouseWheelUp
        /// <summary>Scrolls up within content after a user clicks the wheel button on a mouse.</summary>
        void IScrollInfo.MouseWheelUp()
            {
            ((IScrollInfo)this).LineUp();
            }
        #endregion
        #region M:IScrollInfo.MouseWheelDown
        /// <summary>Scrolls down within content after a user clicks the wheel button on a mouse.</summary>
        void IScrollInfo.MouseWheelDown()
            {
            ((IScrollInfo)this).LineDown();
            }
        #endregion
        #region M:IScrollInfo.MouseWheelLeft
        /// <summary>Scrolls left within content after a user clicks the wheel button on a mouse.</summary>
        void IScrollInfo.MouseWheelLeft()
            {
            ((IScrollInfo)this).LineLeft();
            }
        #endregion
        #region M:IScrollInfo.MouseWheelRight
        /// <summary>Scrolls right within content after a user clicks the wheel button on a mouse.</summary>
        void IScrollInfo.MouseWheelRight()
            {
            ((IScrollInfo)this).LineRight();
            }
        #endregion
        #endregion
        #region M:IScrollInfo.MakeVisible(Visual,Rect)
        Rect IScrollInfo.MakeVisible(Visual visual,Rect rectangle)
            {
            throw new NotImplementedException();
            }
        #endregion
        #region M:IScrollInfo.Set{Horizontal,Vertical}Offset(Double)
        #region M:IScrollInfo.SetHorizontalOffset(Double)
        /// <summary>Sets the amount of horizontal offset.</summary>
        /// <param name="offset">The degree to which content is horizontally offset from the containing viewport.</param>
        void IScrollInfo.SetHorizontalOffset(Double offset)
            {
            Offset = new Vector(offset,Offset.Y);
            }
        #endregion
        #region M:IScrollInfo.SetVerticalOffset(Double)
        /// <summary>Sets the amount of vertical offset.</summary>
        /// <param name="offset">The degree to which content is vertically offset from the containing viewport.</param>
        void IScrollInfo.SetVerticalOffset(Double offset)
            {
            Offset = new Vector(Offset.X,offset);
            }
        #endregion
        #endregion
        #region M:InvalidateScrollInfo
        protected virtual void InvalidateScrollInfo() {
            if (EnsureScrollOwner(out var scrollowner)) {
                scrollowner.InvalidateScrollInfo();
                }
            }
        #endregion
        #region M:GetBounds(Size,UIElement):Rect
        private static Rect GetBounds(Size availablesize, UIElement e)
            {
            var α = XYViewport.GetOffset(e);
            var β = e.DesiredSize;
            return new Rect((Point)α,β);
            }
        #endregion
        #region M:GetBounds(Size):Rect
        private Rect GetBounds(Size availablesize)
            {
            var rc = Rect.Empty;
            var i = 0;
            foreach (UIElement e in InternalChildren) {
                if (e != null) {
                    e.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
                    var α = GetBounds(availablesize,e);
                    if (i == 0)
                        {
                        rc = α;
                        }
                    else
                        {
                        rc.Union(α);
                        }
                    ++i;
                    }
                }
            rc.Union(new Point(0.0,0.0));
            return rc;
            }
        #endregion
        #region M:MeasureOverride(Size):Size
        /// <summary>When overridden in a derived class, measures the size in layout required for child elements and determines a size for the <see cref="T:System.Windows.FrameworkElement"/>-derived class.</summary>
        /// <param name="availableSize">The available size that this element can give to child elements. Infinity can be specified as a value to indicate that the element will size to whatever content is available.</param>
        /// <returns>The size that this element determines it needs during layout, based on its calculations of child element sizes.</returns>
        protected override Size MeasureOverride(Size availableSize) {
            var rc = GetBounds(availableSize);
            //rc.Union(DraggingBound);
            rc.Union((Point)VisualOffset);
            rc = new Rect(rc.TopLeft, new Size(rc.Width,rc.Height));
            rc = DoubleUtil.Round(rc);
            Extent   = new Vector(rc.Width, rc.Height);
            Viewport = new Vector(availableSize.Width,availableSize.Height);
            return rc.Size;
            }
        #endregion
        #region M:ArrangeOverride(Size):Size
        /// <summary>When overridden in a derived class, positions child elements and determines a size for a <see cref="T:System.Windows.FrameworkElement"/> derived class.</summary>
        /// <param name="finalSize">The final area within the parent that this element should use to arrange itself and its children.</param>
        /// <returns>The actual size used.</returns>
        protected override Size ArrangeOverride(Size finalSize) {
            var E = new List<UIElement>();
            var B = new List<Rect>();
            var r = Rect.Empty;
            var o = new Vector(0,0);
            foreach (UIElement e in InternalChildren) {
                if (e != null) {
                    var β = DoubleUtil.Round(GetBounds(finalSize, e));
                    E.Add(e);
                    B.Add(β);
                    r = Rect.Union(r,β);
                    }
                }
            //var ξ = DraggingBound;
            var ξ = Rect.Empty;
            if (!ξ.IsEmpty) {
                r = Rect.Union(r,ξ);
                }
            var δ = new Vector(0,0);
            if (r.X < 0) {
                δ.X = -r.X;
                o.X =  r.X;
                }
            if (r.Y < 0) {
                δ.Y = -r.Y;
                o.Y =  r.Y;
                }
            var count = E.Count;
            for (var i = 0; i < count; i++) {
                var e = E[i];
                var β = B[i];
                β.Offset(δ.X-Offset.X,δ.Y-Offset.Y);
                //β.Offset(20,0);
                e.Arrange(β);
                }
            //LogicalOrigin = o;

            //else
            //    {
            //    ξ = Rect.Union(r,ξ);
            //    var δ = ξ.TopLeft - r.TopLeft;
            //    /* dragging beyond the top-left point if δ.X or δ.Y less than 0 */
            //    if ((δ.X < 0) || (δ.Y < 0)) {
            //        //Debug.Print($"ArrangeOverride:{{{Offset}}}");
            //        //Offset -= δ;
            //        //Debug.Print($"ArrangeOverride:{{{Offset}}}");
            //        }
            //    δ -= VisualOffset;
            //    var count = E.Count;
            //    for (var i = 0; i < count;i++) {
            //        var e = E[i];
            //        var β = B[i];
            //        β.Offset(-Offset.X-δ.X,-Offset.Y-δ.Y);
            //        e.Arrange(β);
            //        }

            //    }
            //var origin = new Vector((r.X>=0) ? r.X :  0.0, (r.Y>=0) ? r.Y :  0.0);
            //var offset = new Vector((r.X>=0) ? 0.0 : -r.X, (r.Y>=0) ? 0.0 : -r.Y);
            return finalSize;
            }
        #endregion
        #region M:EnsureScrollOwner({out}ScrollViewer):Boolean
        private Boolean EnsureScrollOwner(out ScrollViewer ScrollViewer) {
            ScrollViewer = default;
            lock(this) {
                if (m_scrollowner == null) {
                    m_scrollowner = this.Ancestors<ScrollViewer>().FirstOrDefault();
                    }
                }
            ScrollViewer = m_scrollowner;
            return m_scrollowner != null;
            }
        #endregion

        private ScrollViewer m_scrollowner;
        }
    }