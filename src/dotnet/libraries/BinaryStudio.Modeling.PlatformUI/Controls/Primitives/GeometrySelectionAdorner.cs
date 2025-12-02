using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace BinaryStudio.Modeling.PlatformUI.Controls.Primitives
    {
    internal class GeometrySelectionAdorner : Adorner
        {
        private TranslateTransform Transform;

        static GeometrySelectionAdorner()
            {
            WidthProperty.AddOwner(typeof(GeometrySelectionAdorner), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure, OnMeasureChanged));
            HeightProperty.AddOwner(typeof(GeometrySelectionAdorner), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure, OnMeasureChanged));
            }

        public GeometrySelectionAdorner(UIElement adornedElement)
            : base(adornedElement)
            {
            IsHitTestVisible = false;
            SnapsToDevicePixels = true;
            UseLayoutRounding = true;
            Transform = new TranslateTransform();
            }

        #region P:SelectionFillBrush:Brush
        /// <summary>Identifies the <see cref="SelectionFillBrush" /> dependency property. </summary>
        /// <returns>The identifier for the <see cref="SelectionFillBrush" /> dependency property.</returns>
        public static readonly DependencyProperty SelectionFillBrushProperty = DependencyProperty.Register(nameof(SelectionFillBrush), typeof(Brush), typeof(GeometrySelectionAdorner), new PropertyMetadata(SystemColors.HotTrackBrush));
        public Brush SelectionFillBrush {
            get { return (Brush)GetValue(SelectionFillBrushProperty); }
            set { SetValue(SelectionFillBrushProperty, value); }
            }
        #endregion
        #region P:SelectionFillBrushOpacity:Double
        /// <summary>Identifies the <see cref="SelectionFillBrushOpacity" /> dependency property. </summary>
        /// <returns>The identifier for the <see cref="SelectionFillBrushOpacity" /> dependency property.</returns>
        public static readonly DependencyProperty SelectionFillBrushOpacityProperty = DependencyProperty.Register(nameof(SelectionFillBrushOpacity), typeof(Double), typeof(GeometrySelectionAdorner), new PropertyMetadata(0.2));
        public Double SelectionFillBrushOpacity {
            get { return (Double)GetValue(SelectionFillBrushOpacityProperty); }
            set { SetValue(SelectionFillBrushOpacityProperty, value); }
            }
        #endregion
        #region P:SelectionStrokeBrush:Brush
        /// <summary>Identifies the <see cref="SelectionStrokeBrush" /> dependency property. </summary>
        /// <returns>The identifier for the <see cref="SelectionStrokeBrush" /> dependency property.</returns>
        public static readonly DependencyProperty SelectionStrokeBrushProperty = DependencyProperty.Register(nameof(SelectionStrokeBrush), typeof(Brush), typeof(GeometrySelectionAdorner), new PropertyMetadata(SystemColors.HotTrackBrush));
        public Brush SelectionStrokeBrush {
            get { return (Brush)GetValue(SelectionStrokeBrushProperty); }
            set { SetValue(SelectionStrokeBrushProperty, value); }
            }
        #endregion
        #region P:SelectionStrokeThickness:Double
        /// <summary>Identifies the <see cref="SelectionStrokeThickness" /> dependency property. </summary>
        /// <returns>The identifier for the <see cref="SelectionStrokeThickness" /> dependency property.</returns>
        public static readonly DependencyProperty SelectionStrokeThicknessProperty = DependencyProperty.Register(nameof(SelectionStrokeThickness), typeof(Double), typeof(GeometrySelectionAdorner), new PropertyMetadata(1.0));
        public Double SelectionStrokeThickness {
            get { return (Double)GetValue(SelectionStrokeThicknessProperty); }
            set { SetValue(SelectionStrokeThicknessProperty, value); }
            }
        #endregion
        #region P:Geometry:Geometry
        /// <summary>Identifies the <see cref="Geometry" /> dependency property. </summary>
        /// <returns>The identifier for the <see cref="Geometry" /> dependency property.</returns>
        public static readonly DependencyProperty GeometryProperty = DependencyProperty.Register(nameof(Geometry), typeof(Geometry), typeof(GeometrySelectionAdorner), new PropertyMetadata(default(Geometry), OnGeometryChanged));
        private static void OnGeometryChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            ((GeometrySelectionAdorner)sender).InvalidateVisual();
            }

        public Geometry Geometry {
            get { return (Geometry)GetValue(GeometryProperty); }
            set { SetValue(GeometryProperty, value); }
            }
        #endregion
        #region P:Offset:Vector
        public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register(nameof(Offset), typeof(Vector), typeof(GeometrySelectionAdorner), new PropertyMetadata(default(Vector),OnOffsetChanged));
        public Vector Offset
            {
            get { return (Vector)GetValue(OffsetProperty); }
            set { SetValue(OffsetProperty, value); }
            }
        private static void OnOffsetChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            if (sender is GeometrySelectionAdorner source) {
                source.OnOffsetChanged(
                    (Vector)e.NewValue,
                    (Vector)e.OldValue);
                }
            }

        private void OnOffsetChanged(Vector NewValue, Vector OldValue)
            {
            //Debug.Print($"GeometrySelectionAdorner.OnOffsetChanged:{{{OldValue}}}->{{{NewValue}}}");
            if ((Math.Abs(OldValue.X-NewValue.X) > 20) && (OldValue != default))
                {
                //Debug.Print($"GeometrySelectionAdorner.OnOffsetChanged:{{{OldValue}}}->{{{NewValue}}}");
                }
            var offset = Offset;
            Transform = new TranslateTransform(offset.X, offset.Y);
            InvalidateVisual();
            }
        #endregion

        /// <summary>When overridden in a derived class, participates in rendering operations that are directed by the layout system. The rendering instructions for this element are not used directly when this method is invoked, and are instead preserved for later asynchronous use by layout and drawing. </summary>
        /// <param name="context">The drawing instructions for a specific element. This context is provided to the layout system.</param>
        protected override void OnRender(DrawingContext context) {
            base.OnRender(context);
            if (IsVisible) {
                context.PushTransform(Transform);
                context.PushGuidelineSet(new GuidelineSet(
                    new []{0.5},
                    new []{0.5}));
                Brush brush = null;
                Pen pen = null;
                if (SelectionFillBrush != null) {
                    brush = SelectionFillBrush.Clone(SelectionFillBrushOpacity);
                    }
                if (SelectionStrokeBrush != null) {
                    pen = new Pen(SelectionStrokeBrush.Clone(), SelectionStrokeThickness);
                    }
                if (Geometry != null)
                    {
                    context.DrawGeometry(brush, pen, Geometry);
                    }
                else
                    {
                    context.DrawRectangle(brush, pen, new Rect(0, 0, Width, Height));
                    }
                context.Pop();
                context.Pop();
                }
            }

        private static void OnMeasureChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            if (sender is GeometrySelectionAdorner source) {
                source.InvalidateVisual();
                }
            }
        }
    }
