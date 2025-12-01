using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace BinaryStudio.Modeling.PlatformUI.Controls.Primitives
    {
    internal class XYViewportShapeSizeAdorner : AdornerContainer<XYViewportShapeSizeDecorator>
        {
        public XYViewportShapeSizeAdorner(UIElement adornedElement)
            : base(adornedElement)
            {
            ServiceProvider = adornedElement as IServiceProvider;
            }

        #region P:Child:XYViewportShapeSizeDecorator
        public override XYViewportShapeSizeDecorator Child {
            get
                {
                var child = base.Child;
                if (child == null) {
                    base.Child = new XYViewportShapeSizeDecorator();
                    base.Child.DragDelta     += OnDragDelta;
                    base.Child.DragCompleted += OnDragCompleted;
                    base.Child.DragStarted   += OnDragStarted;
                    base.Child.DraggingScrollHitTest += OnDraggingScrollHitTest;
                    base.Child.ServiceProvider = ServiceProvider;
                    InvalidateMeasure();
                    }
                return base.Child;
                }
            set { throw new NotSupportedException(); }
            }
        #endregion
        #region P:Offset:Vector
        public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register(nameof(Offset),typeof(Vector),typeof(XYViewportShapeSizeAdorner),new PropertyMetadata(default(Vector),OnOffsetChanged));
        private static void OnOffsetChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            if (sender is XYViewportShapeSizeAdorner source) {
                source.OnOffsetChanged();
                }
            }

        private void OnOffsetChanged() {
            ChildOffset = Offset;
            }

        public Vector Offset
            {
            get { return (Vector) GetValue(OffsetProperty); }
            set { SetValue(OffsetProperty,value); }
            }
        #endregion
        #region P:Size:Size
        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register(nameof(Size),typeof(Size),typeof(XYViewportShapeSizeAdorner),new PropertyMetadata(default(Size),OnSizeChanged));
        private static void OnSizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            if (sender is XYViewportShapeSizeAdorner source) {
                source.OnSizeChanged();
                }
            }

        private void OnSizeChanged() {
            var child = Child;
            if (child != null) {
                child.Width  = Size.Width;
                child.Height = Size.Height;
                InvalidateMeasure();
                }
            }

        public Size Size
            {
            get { return (Size)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
            }
        #endregion

        #region M:OnDraggingScrollHitTest(Object,DraggingScrollHitTestEventArgs)
        private void OnDraggingScrollHitTest(Object sender, DraggingScrollHitTestEventArgs e)
            {
            DraggingScrollHitTest?.Invoke(sender,e);
            }
        #endregion
        #region M:OnDragCompleted(Object,DragCompletedEventArgs)
        private void OnDragCompleted(Object sender, DragCompletedEventArgs e)
            {
            DragCompleted?.Invoke(sender,e);
            }
        #endregion
        #region M:OnDragDelta(Object,DragDeltaEventArgs)
        private void OnDragDelta(Object sender, DragDeltaEventArgs e)
            {
            DragDelta?.Invoke(sender,e);
            }
        #endregion
        #region M:OnDragStarted(Object,DragStartedEventArgs)
        private void OnDragStarted(Object sender, DragStartedEventArgs e) {
            DragStarted?.Invoke(sender,e);
            }
        #endregion

        /// <summary>When overridden in a derived class, participates in rendering operations that are directed by the layout system. The rendering instructions for this element are not used directly when this method is invoked, and are instead preserved for later asynchronous use by layout and drawing. </summary>
        /// <param name="context">The drawing instructions for a specific element. This context is provided to the layout system.</param>
        protected override void OnRender(DrawingContext context)
            {
            base.OnRender(context);
            context.DrawText(new Point(10.0, 100.0), $"XYViewportNodeSizeAdorner::Offset:{{{Offset.X},{Offset.Y}}}");
            }

        public event DragDeltaEventHandler     DragDelta;
        public event DragCompletedEventHandler DragCompleted;
        public event DragStartedEventHandler   DragStarted;
        public event DraggingScrollHitTestEventHandler DraggingScrollHitTest;

        //private IXYViewportMoveableNode MoveableNode;
        //private IXYViewportSizeableNode SizeableNode;
        private TranslateTransform Transform;
        private readonly IServiceProvider ServiceProvider;
        }
    }
