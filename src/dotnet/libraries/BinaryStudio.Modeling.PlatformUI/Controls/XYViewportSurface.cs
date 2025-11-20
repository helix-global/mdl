using System;
using System.Windows;
using System.Windows.Media;

namespace BinaryStudio.Modeling.PlatformUI.Controls
    {
    public class XYViewportSurface : UIElement
        {
        #region P:Offset:Vector
        public static readonly DependencyProperty OffsetProperty = DependencyProperty.Register(nameof(Offset),typeof(Vector),typeof(XYViewportSurface),new PropertyMetadata(default(Vector)));
        public Vector Offset
            {
            get { return (Vector)GetValue(OffsetProperty); }
            set { SetValue(OffsetProperty, value); }
            }
        #endregion
        #region P:Scale:Double
        public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register(nameof(Scale),typeof(Double),typeof(XYViewportSurface),new PropertyMetadata(1.0,OnScaleChanged));
        private static void OnScaleChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            if (sender is XYViewportSurface surface) {
                surface.InvalidateVisual();
                }
            }

        public Double Scale
            {
            get { return (Double)GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
            }
        #endregion
        #region M:OnRender(DrawingContext)
        /// <summary>When overridden in a derived class, participates in rendering operations that are directed by the layout system. The rendering instructions for this element are not used directly when this method is invoked, and are instead preserved for later asynchronous use by layout and drawing.</summary>
        /// <param name="context">The drawing instructions for a specific element. This context is provided to the layout system.</param>
        protected override void OnRender(DrawingContext context) {
            base.OnRender(context);
            var offset = Offset*Scale;
            var GridSize = new Size(10*Scale,10*Scale);
            var GridPenXT = new Pen(Brushes.Gray.Clone(0.5),0.125);
            var GridPenYT = new Pen(Brushes.Gray.Clone(0.5),0.125);
            var GridPenXB = new Pen(Brushes.Gray.Clone(),0.25);
            var GridPenYB = new Pen(Brushes.Gray.Clone(),0.25);
            var Size = RenderSize;
            if ((GridSize.Width > 1) || (GridSize.Height > 0)) {
                context.PushGuidelineSet(new GuidelineSet(
                    new []{0.1, 0.1, 0.5},
                    new []{0.1, 0.1, 0.5}));
                var x = GridSize.Width  - (offset.X % GridSize.Width);
                var y = GridSize.Height - (offset.Y % GridSize.Height);
                do  {
                    if ((x > 0) && (x < Size.Width)) {
                        var GridPenX = (((Int32)x % 50)==0)
                            ? GridPenXB
                            : GridPenXT;
                        context.DrawLine(GridPenX,new Point(x,0),new Point(x, Size.Height));
                        }
                    if ((y > 0) && (y < Size.Height)) {
                        var GridPenY = (((Int32)y % 50)==0)
                            ? GridPenYB
                            : GridPenYT;
                        context.DrawLine(GridPenY,new Point(0,y),new Point(Size.Width,y));
                        }
                    x += GridSize.Width;
                    y += GridSize.Height;
                    }
                while ((x < Size.Width) || (y < Size.Height));
                context.Pop();
                }
            }
        #endregion
        }
    }