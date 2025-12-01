using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using BinaryStudio.Modeling.PlatformUI.Controls.Primitives;

namespace BinaryStudio.Modeling.PlatformUI.Controls
    {
    using UIThumb = System.Windows.Controls.Primitives.Thumb;
    internal class Thumb : Control
        {
        #region E:DragCompleted:DragCompletedEventHandler
        public event DragCompletedEventHandler DragCompleted
            {
            add { AddHandler(UIThumb.DragCompletedEvent, value); }
            remove { RemoveHandler(UIThumb.DragCompletedEvent, value); }
            }
        #endregion
        #region E:DragDelta:DragDeltaEventHandler
        public event DragDeltaEventHandler DragDelta
            {
            add { AddHandler(UIThumb.DragDeltaEvent, value); }
            remove { RemoveHandler(UIThumb.DragDeltaEvent, value); }
            }
        #endregion
        #region E:DragStarted:DragStartedEventHandler
        public event DragStartedEventHandler DragStarted
            {
            add { AddHandler(UIThumb.DragStartedEvent, value); }
            remove { RemoveHandler(UIThumb.DragStartedEvent, value); }
            }
        #endregion
        public event DraggingScrollHitTestEventHandler DraggingScrollHitTest;

        #region P:IsDragging:Boolean
        private static readonly DependencyPropertyKey IsDraggingPropertyKey = DependencyProperty.RegisterReadOnly("IsDragging", typeof(Boolean), typeof(Thumb), new PropertyMetadata(default(Boolean)));
        public static readonly DependencyProperty IsDraggingProperty = IsDraggingPropertyKey.DependencyProperty;
        public Boolean IsDragging
            {
            get { return (Boolean)GetValue(IsDraggingProperty); }
            protected set { SetValue(IsDraggingPropertyKey, value); }
            }
        #endregion
        #region M:OnMouseLeftButtonDown(MouseButtonEventArgs)
        /// <summary>Invoked when an unhandled <see cref="E:System.Windows.UIElement.MouseLeftButtonDown"/> routed event is raised on this element. Implement this method to add class handling for this event.</summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.MouseButtonEventArgs"/> that contains the event data. The event data reports that the left mouse button was pressed.</param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e) {
            if (!IsDragging) {
                e.Handled = true;
                CaptureMouse();
                SetValue(IsDraggingPropertyKey, value: true);
                OriginThumbPoint = e.GetPosition(this);
                PreviousScreenCoordPosition = (OriginScreenCoordPosition = PointToScreen(OriginThumbPoint));
                StoredCursor = Cursor;
                RaiseEvent(new DragStartedEventArgs(OriginThumbPoint.X, OriginThumbPoint.Y));
                #if THUMB_THREAD
                DraggingTaskCancellationTokenSource = new CancellationTokenSource();
                DraggingTaskCancellationToken = DraggingTaskCancellationTokenSource.Token;
                DraggingTask = Task.Factory.StartNew(DraggingThreadProcedure,DraggingTaskCancellationToken);
                #endif
                }
            base.OnMouseLeftButtonDown(e);
            }
        #endregion
        #region M:OnMouseLeftButtonUp(MouseButtonEventArgs)
        /// <summary>Invoked when an unhandled <see cref="E:System.Windows.UIElement.MouseLeftButtonUp"/> routed event reaches an element in its route that is derived from this class. Implement this method to add class handling for this event.</summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.MouseButtonEventArgs"/> that contains the event data. The event data reports that the left mouse button was released.</param>
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e) {
            if (IsMouseCaptured && IsDragging) {
                e.Handled = true;
                ClearValue(IsDraggingPropertyKey);
                ReleaseMouseCapture();
                var point = PointToScreen(e.MouseDevice.GetPosition(this));
                Cursor = StoredCursor;
                #if THUMB_THREAD
                DraggingTaskCancellationTokenSource.Cancel();
                DraggingTask.Wait();
                Dispose(ref DraggingTask);
                Dispose(ref DraggingTaskCancellationTokenSource);
                #endif
                RaiseEvent(new DragCompletedEventArgs(point.X - OriginScreenCoordPosition.X, point.Y - OriginScreenCoordPosition.Y, canceled: false));
                }
            base.OnMouseLeftButtonUp(e);
            }
        #endregion
        #region M:OnMouseMove(MouseEventArgs)
        /// <summary>Invoked when an unhandled <see cref="E:System.Windows.Input.Mouse.MouseMove"/> attached event reaches an element in its route that is derived from this class. Implement this method to add class handling for this event.</summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.MouseEventArgs"/> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);
            if (!IsDragging) { return; }
            if (e.MouseDevice.LeftButton == MouseButtonState.Pressed) {
                var α = e.GetPosition(this);
                var β = PointToScreen(α);
                if (β != PreviousScreenCoordPosition) {
                    Thread.Yield();
                    PreviousScreenCoordPosition = β;
                    e.Handled = true;
                    #if THUMB_THREAD
                    ValidateDraggingScrollHitTest(out var ε);
                    if (!ε.Kind.HasFlag(DraggingScrollHitTestResultKind.Outside)) {
                        var δ = new Vector(α.X - OriginThumbPoint.X, α.Y - OriginThumbPoint.Y);
                        if (ε.Kind != DraggingScrollHitTestResultKind.None) {
                            var K = ε.Kind;
                            PreviousScrollHitTestResult = ε.Kind;
                            lock (DraggingLockObject) {
                                DraggingDirection = default;
                                if (K.HasFlag(DraggingScrollHitTestResultKind.Left))  { DraggingDirection.X = -10; }
                                if (K.HasFlag(DraggingScrollHitTestResultKind.Top))   { DraggingDirection.Y = -10; }
                                if (K.HasFlag(DraggingScrollHitTestResultKind.Right)) { DraggingDirection.X = +10; }
                                if (K.HasFlag(DraggingScrollHitTestResultKind.Bottom)){ DraggingDirection.Y = +10; }
                                OriginDraggingDelta = δ;
                                DraggingThreadEnabled = true;
                                }
                            }
                        else
                            {
                            ClearRepeatableDragging();
                            RaiseEvent(new DragDeltaEventArgs(δ.X,δ.Y));
                            }
                        }
                    else
                        {
                        lock(DraggingLockObject)
                            {
                            DraggingThreadEnabled = false;
                            }
                        }
                    #else
                    var δ = new Vector(α.X - OriginThumbPoint.X, α.Y - OriginThumbPoint.Y);
                    RaiseEvent(new DragDeltaEventArgs(δ.X,δ.Y));
                    #endif
                    }
                }
            else
                {
                if (ReferenceEquals(e.MouseDevice.Captured, this))
                    {
                    ReleaseMouseCapture();
                    }
                ClearValue(IsDraggingPropertyKey);
                OriginThumbPoint = default;
                #if THUMB_THREAD
                ClearRepeatableDragging();
                #endif
                }
            }
        #endregion

        private Point OriginThumbPoint;
        private Point OriginScreenCoordPosition,PreviousScreenCoordPosition;
        private Cursor StoredCursor;
        }
    }
