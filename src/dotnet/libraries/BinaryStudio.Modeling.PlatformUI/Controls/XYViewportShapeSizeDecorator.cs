using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using BinaryStudio.Modeling.PlatformUI.Controls.Primitives;

namespace BinaryStudio.Modeling.PlatformUI.Controls
    {
    public class XYViewportShapeSizeDecorator : Control
        {
        static XYViewportShapeSizeDecorator()
            {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(XYViewportShapeSizeDecorator), new FrameworkPropertyMetadata(typeof(XYViewportShapeSizeDecorator)));
            LocalCursors[ThumbLeft]        = LoadCursor("Left");
            LocalCursors[ThumbRight]       = LoadCursor("Right");
            LocalCursors[ThumbTop]         = LoadCursor("Top");
            LocalCursors[ThumbBottom]      = LoadCursor("Bottom");
            LocalCursors[ThumbLeftTop]     = LoadCursor("LeftTop");
            LocalCursors[ThumbLeftBottom]  = LoadCursor("LeftBottom");
            LocalCursors[ThumbRightTop]    = LoadCursor("RightTop");
            LocalCursors[ThumbRightBottom] = LoadCursor("RightBottom");
            LocalCursors[ThumbOutside]     = Cursors.No;
            LocalCursors[ThumbAll]         = Cursors.ScrollAll;
            }

        public event DragDeltaEventHandler             DragDelta;
        public event DragCompletedEventHandler         DragCompleted;
        public event DragStartedEventHandler           DragStarted;
        public event DraggingScrollHitTestEventHandler DraggingScrollHitTest;

        #region P:ServiceProvider:IServiceProvider
        public static readonly DependencyProperty ServiceProviderProperty = DependencyProperty.Register(nameof(ServiceProvider),typeof(IServiceProvider),typeof(XYViewportShapeSizeDecorator),new PropertyMetadata(default(IServiceProvider)));
        public IServiceProvider ServiceProvider
            {
            get { return (IServiceProvider)GetValue(ServiceProviderProperty); }
            set { SetValue(ServiceProviderProperty, value); }
            }
        #endregion
        #region M:LoadCursor(String):Cursor
        private static Cursor LoadCursor(String source)
            {
            var i = Application.GetResourceStream(new Uri($@"pack://application:,,,/BinaryStudio.Modeling.PlatformUI;component/resources/{source}.cur"));
            return new Cursor(i.Stream);
            }
        #endregion
        #region M:OnApplyTemplate
        public override void OnApplyTemplate()
            {
            base.OnApplyTemplate();
            InstallThumbHandlers(Thumbs[ThumbBottom     ] = GetTemplateChild("ThumbBottom")      as Thumb);
            InstallThumbHandlers(Thumbs[ThumbRight      ] = GetTemplateChild("ThumbRight")       as Thumb);
            InstallThumbHandlers(Thumbs[ThumbRightBottom] = GetTemplateChild("ThumbRightBottom") as Thumb);
            InstallThumbHandlers(Thumbs[ThumbTop        ] = GetTemplateChild("ThumbTop")         as Thumb);
            InstallThumbHandlers(Thumbs[ThumbLeft       ] = GetTemplateChild("ThumbLeft")        as Thumb);
            InstallThumbHandlers(Thumbs[ThumbRightTop   ] = GetTemplateChild("ThumbRightTop")    as Thumb);
            InstallThumbHandlers(Thumbs[ThumbLeftBottom ] = GetTemplateChild("ThumbLeftBottom")  as Thumb);
            InstallThumbHandlers(Thumbs[ThumbLeftTop    ] = GetTemplateChild("ThumbLeftTop")     as Thumb);
            InstallThumbHandlers(Thumbs[ThumbAll        ] = GetTemplateChild("ThumbAll")         as Thumb);
            return;
            }
        #endregion
        #region M:InstallThumbHandlers(Thumb)
        private void InstallThumbHandlers(Thumb source) {
            if (source != null) {
                source.DragStarted   += OnDragStarted;
                source.DragCompleted += OnDragCompleted;
                source.DragDelta     += OnDragDelta;
                source.DraggingScrollHitTest += OnDraggingScrollHitTest;
                }
            }
        #endregion
        #region M:OnDraggingScrollHitTest(Object,DraggingScrollHitTestEventArgs)
        private void OnDraggingScrollHitTest(Object sender, DraggingScrollHitTestEventArgs e) {
            DraggingScrollHitTest?.Invoke(sender,e);
            if (e != null) {
                if (e.Kind != DraggingScrollHitTestResultKind.None) {
                    e.Cursor = LocalCursors[GetCursorIndex(e.Kind)];
                    }
                }
            }
        #endregion
        #region M:OnDragStarted(Object,DragStartedEventArgs)
        private void OnDragStarted(Object sender, DragStartedEventArgs e) {
            IsDragging = true;
            DragStarted?.Invoke(sender,e);
            }
        #endregion
        #region M:OnDragCompleted(Object,DragCompletedEventArgs)
        private void OnDragCompleted(Object sender, DragCompletedEventArgs e) {
            IsDragging = false;
            DragCompleted?.Invoke(sender,e);
            }
        #endregion
        #region M:OnDragDelta(Object,DragDeltaEventArgs)
        private void OnDragDelta(Object sender, DragDeltaEventArgs e) {
            if (IsDragging) {
                DragDelta?.Invoke(sender,new DragDeltaDirectedEventArgs(e,(DraggingDeltaDirection)GetThumbIndex(sender)));
                }
            }
        #endregion
        #region M:GetThumbIndex(Object):Int32
        private Int32 GetThumbIndex(Object source) {
            for (var i = 0; i < Thumbs.Length; i++) {
                if (ReferenceEquals(Thumbs[i],source))
                    {
                    return i;
                    }
                }
            return -1;
            }
        #endregion
        #region M:GetCursorIndex(DraggingScrollHitTestResultKind):Int32
        private static Int32 GetCursorIndex(DraggingScrollHitTestResultKind source) {
            if (source.HasFlag(DraggingScrollHitTestResultKind.Outside)) { return ThumbOutside; }
            switch (source) {
                case DraggingScrollHitTestResultKind.None:        return -1;
                case DraggingScrollHitTestResultKind.Left:        return ThumbLeft;
                case DraggingScrollHitTestResultKind.Top:         return ThumbTop;
                case DraggingScrollHitTestResultKind.Right:       return ThumbRight;
                case DraggingScrollHitTestResultKind.Bottom:      return ThumbBottom;
                case DraggingScrollHitTestResultKind.LeftTop:     return ThumbLeftTop;
                case DraggingScrollHitTestResultKind.LeftBottom:  return ThumbLeftBottom;
                case DraggingScrollHitTestResultKind.RightTop:    return ThumbRightTop;
                case DraggingScrollHitTestResultKind.RightBottom: return ThumbRightBottom;
                case DraggingScrollHitTestResultKind.Outside:     return ThumbOutside;
                default: return -1;
                }
            }
        #endregion

        private const Int32 ThumbLeftTop     = 0;
        private const Int32 ThumbTop         = 1;
        private const Int32 ThumbRightTop    = 2;
        private const Int32 ThumbLeft        = 3;
        private const Int32 ThumbRight       = 4;
        private const Int32 ThumbLeftBottom  = 5;
        private const Int32 ThumbBottom      = 6;
        private const Int32 ThumbRightBottom = 7;
        private const Int32 ThumbAll         = 8;
        private const Int32 ThumbOutside     = 9;
        private static readonly Cursor[] LocalCursors = new Cursor[10];
        private readonly Thumb[] Thumbs = new Thumb[9];
        private Boolean IsDragging;
        }
    }
