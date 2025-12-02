using BinaryStudio.Modeling.PlatformUI.Controls.Primitives;
using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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

        #region P:VerticalOffset:Double
        internal static readonly DependencyProperty VerticalOffsetProperty = DependencyProperty.Register(nameof(VerticalOffset),typeof(Double),typeof(XYViewport),new PropertyMetadata(default(Double),OnVerticalOffsetChanged));
        private static void OnVerticalOffsetChanged(DependencyObject sender,DependencyPropertyChangedEventArgs e) {
            if (sender is XYViewport source) {

                }
            }
        internal Double VerticalOffset
            {
            get { return (Double)GetValue(VerticalOffsetProperty); }
            set { SetValue(VerticalOffsetProperty,value); }
            }
        #endregion
        #region P:HorizontalOffset:Double
        internal static readonly DependencyProperty HorizontalOffsetProperty = DependencyProperty.Register(nameof(HorizontalOffset),typeof(Double),typeof(XYViewport),new PropertyMetadata(default(Double),OnHorizontalOffsetChanged));
        private static void OnHorizontalOffsetChanged(DependencyObject sender,DependencyPropertyChangedEventArgs e) {
            if (sender is XYViewport source) {

                }
            }
        internal Double HorizontalOffset
            {
            get { return (Double)GetValue(HorizontalOffsetProperty); }
            set { SetValue(HorizontalOffsetProperty,value); }
            }
        #endregion

        #region M:OnApplyTemplate
        /// <summary>When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.</summary>
        public override void OnApplyTemplate() {
            base.OnApplyTemplate();
            ViewportSurface = GetTemplateChild("ViewportSurface") as XYViewportSurface;
            ScrollViewer = GetTemplateChild("ScrollViewer") as ScrollViewer;
            ViewportSurface?.SetBinding(XYViewportSurface.ScaleProperty,this,ScaleProperty,BindingMode.OneWay);
            if (ScrollViewer != null) {
                ScrollViewer.ScrollChanged += OnScrollChanged;
                }
            }
        #endregion
        #region M:OnDraggingScrollHitTest(Object,DraggingScrollHitTestEventArgs)
        private void OnDraggingScrollHitTest(Object sender, DraggingScrollHitTestEventArgs e)
            {
            }
        #endregion
        #region M:OnDragCompleted(Object,DragCompletedEventArgs)
        private void OnDragCompleted(Object sender, DragCompletedEventArgs e) {
            }
        #endregion
        #region M:OnDragDelta(Object,DragDeltaEventArgs)
        private void OnDragDelta(Object sender, DragDeltaEventArgs e) {
            }
        #endregion
        #region M:OnDragStarted(Object,DragStartedEventArgs)
        private void OnDragStarted(Object sender, DragStartedEventArgs e) {
            }
        #endregion
        #region M:OnOffsetChanged(Object,OffsetChangedEventArgs)
        private void OnOffsetChanged(Object sender,OffsetChangedEventArgs e)
            {
            
            }
        #endregion
        #region M:OnMouseLeftButtonDown(MouseButtonEventArgs)
        /// <summary>Invoked when an unhandled <see cref="E:System.Windows.UIElement.MouseLeftButtonDown"/> routed event is raised on this element. Implement this method to add class handling for this event.</summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.MouseButtonEventArgs"/> that contains the event data. The event data reports that the left mouse button was pressed.</param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
            {
            base.OnMouseLeftButtonDown(e);
            }
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
        #region M:OnScrollChanged(Object,ScrollChangedEventArgs)
        private void OnScrollChanged(Object sender,ScrollChangedEventArgs e)
            {
            UpdateSizeAdornerPosition();
            }
        #endregion
        #region M:OnSelectionChanged(SelectionChangedEventArgs)
        /// <summary>Called when the selection changes.</summary>
        /// <param name="e">The event data.</param>
        protected override void OnSelectionChanged(SelectionChangedEventArgs e) {
            base.OnSelectionChanged(e);
            if (EnsureViewportPanel(out var panel)) {
                panel.OnSelectionChanged(e,SelectedItems);
                SelectionGroup = new LocalSelectionGroup(SelectedItems,this);
                UpdateSizeAdornerPosition();
                }
            //EnsureItemsPanel();
            //if (ItemsPanel != null) {
            //    ItemsPanel.OnSelectionChanged(e,SelectedItems);
            //    SelectionGroup = new LocalSelectionGroup(SelectedItems,this);
            //    UpdateSizeAdornerPosition();
            //    }
            }
        #endregion
        #region M:EnsureSizeAdorner
        private void EnsureSizeAdorner() {
            if ((SizeAdorner == null) && (SelectionGroup != null)) {
                var layer = AdornerLayer.GetAdornerLayer(this);
                if (layer != null) {
                    layer.Add(SizeAdorner = new XYViewportShapeSizeAdorner(this));
                    SizeAdorner.DragDelta     += OnDragDelta;
                    SizeAdorner.DragCompleted += OnDragCompleted;
                    SizeAdorner.DragStarted   += OnDragStarted;
                    SizeAdorner.DraggingScrollHitTest += OnDraggingScrollHitTest;
                    }
                }
            }
        #endregion
        #region M:EnsureViewportPanel({out}XYViewportPanel):Boolean
        private Boolean EnsureViewportPanel(out XYViewportPanel o) {
            o = default;
            if (ViewportPanel == null) { ViewportPanel = ItemsHost as XYViewportPanel; }
            if (ViewportPanel != null) {
                ViewportPanel.OffsetChanged += OnOffsetChanged;
                }
            o = ViewportPanel;
            return o != null;
            }
        #endregion
        #region M:UpdateSizeAdornerPosition
        private void UpdateSizeAdornerPosition() {
            if (SelectionGroup != null) {
                EnsureSizeAdorner();
                if (EnsureViewportPanel(out var panel)) {
                    SizeAdorner.Visibility = SelectionGroup.Visibility;
                    if (SizeAdorner.Visibility == Visibility.Visible) {
                        var α = panel.FromLogical(SelectionGroup.Bound).Scale(Scale);
                        var β = (Vector)α.Location-(new Vector(HorizontalOffset,VerticalOffset));
                        var update = new Action(()=>
                            {
                            SizeAdorner.Offset = β;
                            SizeAdorner.Size = α.Size;
                            SizeAdorner.InvalidateArrange();
                            SizeAdorner.InvalidateVisual();
                            });
                        if (!SizeAdorner.IsLoaded) {
                            SizeAdorner.DoAfterLoaded(update);
                            }
                        else
                            {
                            update();
                            }
                        }
                    }
                }
            }
        #endregion
        #region M:{Get,Set}Size
        internal static Size GetSize(DependencyObject e) {
            var W = (Double)e.GetValue(WidthProperty);
            var H = (Double)e.GetValue(HeightProperty);
            W = Double.IsNaN(W) ? (Double)e.GetValue(ActualWidthProperty) : W;
            H = Double.IsNaN(H) ? (Double)e.GetValue(ActualHeightProperty): H;
            return new Size(W,H);
            }

        internal static void SetSize(DependencyObject e, Size value) {
            if (value.IsEmpty) {
                e.SetValue(WidthProperty,Double.NaN);
                e.SetValue(HeightProperty,Double.NaN);
                }
            else
                {
                e.SetValue(WidthProperty,value.Height);
                e.SetValue(HeightProperty,value.Height);
                }
            }
        #endregion
        #region M:{Get,Set}Bound
        internal static Rect GetBound(DependencyObject e) {
            var α = GetOffset(e);
            var β = GetSize(e);
            return (!β.IsEmpty)
                ? new Rect((Point)α,β)
                : Rect.Empty;
            }

        internal static void SetBound(DependencyObject e, Rect value) {
            if (value.IsEmpty) {
                SetOffset(e,new Vector(0,0));
                SetSize(e,Size.Empty);
                }
            else
                {
                SetOffset(e,(Vector)value.TopLeft);
                SetSize(e,value.Size);
                }
            }
        #endregion
        #region M:PrepareContainerForItemOverride(DependencyObject,Object)
        /// <summary>Prepares the specified element to display the specified item.</summary>
        /// <param name="element">The element that is used to display the specified item.</param>
        /// <param name="item">The specified item to display.</param>
        protected override void PrepareContainerForItemOverride(DependencyObject element, Object item) {
            base.PrepareContainerForItemOverride(element, item);
            if (element is XYViewportItem container) {
                container.Owner = this;
                }
            }
        #endregion
        #region M:SelectItem(DependencyObject)
        internal void SelectItem(DependencyObject item) {
            if (!IsUpdatingSelectedItems) {
                BeginUpdateSelectedItems();
                SelectedItems.Add(item);
                EndUpdateSelectedItems();
                if (EnsureViewportPanel(out var panel))
                    {
                    panel.BringTop(item as UIElement);
                    }
                }
            }
        #endregion
        #region M:UnselectItem(DependencyObject)
        internal void UnselectItem(DependencyObject item) {
            if (!IsUpdatingSelectedItems) {
                BeginUpdateSelectedItems();
                SelectedItems.Remove(item);
                EndUpdateSelectedItems();
                }
            }
        #endregion

        private class LocalSelectionGroup
            {
            private readonly IList items;
            private readonly XYViewport host;

            public LocalSelectionGroup(IList items,XYViewport host)
                {
                this.items = items;
                this.host = host;
                }

            public Visibility Visibility { get {
                return (items.Count == 1)
                        ? Visibility.Visible
                        : Visibility.Hidden;
                }}

            #region P:Bound:Rect
            public Rect Bound
                {
                get
                    {
                    var r = Rect.Empty;
                    foreach (var item in items.OfType<DependencyObject>()) {
                        r.Union(XYViewport.GetBound(item));
                        }
                    return r;
                    }
                set
                    {
                    var r = Bound;
                    if (value != r) {
                        var α = r;
                        var β = value.Location - α.Location;
                        foreach (var item in items.OfType<UIElement>()) {
                            SetOffset(item, GetOffset(item) + β);
                            item.InvalidateVisual();
                            }
                        host.UpdateSizeAdornerPosition();
                        }
                    }
                }
            #endregion

            }

        private XYViewportSurface ViewportSurface;
        private XYViewportShapeSizeAdorner SizeAdorner;
        private XYViewportPanel ViewportPanel;
        private LocalSelectionGroup SelectionGroup;
        private ScrollViewer ScrollViewer;
        }
    }
