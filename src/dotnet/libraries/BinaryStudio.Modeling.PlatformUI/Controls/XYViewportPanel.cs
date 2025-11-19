using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace BinaryStudio.Modeling.PlatformUI.Controls
    {
    public class XYViewportPanel : Panel,IScrollInfo
        {
        private Boolean _canVerticallyScroll;
        private Boolean _canHorizontallyScroll;
        private Double _extentWidth;
        private Double _extentHeight;
        private Double _viewportWidth;
        private Double _viewportHeight;
        private Double _horizontalOffset;
        private Double _verticalOffset;
        private ScrollViewer _scrollOwner;

        #region P:IScrollInfo.CanVerticallyScroll:Boolean
        Boolean IScrollInfo.CanVerticallyScroll
            {
            get { return _canVerticallyScroll; }
            set { _canVerticallyScroll = value; }
            }
        #endregion
        #region P:IScrollInfo.CanHorizontallyScroll:Boolean
        Boolean IScrollInfo.CanHorizontallyScroll
            {
            get { return _canHorizontallyScroll; }
            set { _canHorizontallyScroll = value; }
            }
        #endregion
        #region P:IScrollInfo.ExtentWidth:Double
        Double IScrollInfo.ExtentWidth
            {
            get { return _extentWidth; }
            }
        #endregion
        #region P:IScrollInfo.ExtentHeight:Double
        Double IScrollInfo.ExtentHeight
            {
            get { return _extentHeight; }
            }
        #endregion
        #region P:IScrollInfo.ViewportWidth:Double
        Double IScrollInfo.ViewportWidth
            {
            get { return _viewportWidth; }
            }
        #endregion
        #region P:IScrollInfo.ViewportHeight:Double
        Double IScrollInfo.ViewportHeight
            {
            get { return _viewportHeight; }
            }
        #endregion
        #region P:IScrollInfo.HorizontalOffset:Double
        Double IScrollInfo.HorizontalOffset
            {
            get { return _horizontalOffset; }
            }
        #endregion
        #region P:IScrollInfo.VerticalOffset:Double
        Double IScrollInfo.VerticalOffset
            {
            get { return _verticalOffset; }
            }
        #endregion
        #region P:IScrollInfo.ScrollOwner:ScrollViewer
        ScrollViewer IScrollInfo.ScrollOwner
            {
            get { return _scrollOwner; }
            set { _scrollOwner = value; }
            }
        #endregion

        #region M:IScrollInfo.LineUp
        void IScrollInfo.LineUp()
            {
            throw new NotImplementedException();
            }
        #endregion
        #region M:IScrollInfo.LineDown
        void IScrollInfo.LineDown()
            {
            throw new NotImplementedException();
            }
        #endregion
        #region M:IScrollInfo.LineLeft
        void IScrollInfo.LineLeft()
            {
            throw new NotImplementedException();
            }
        #endregion
        #region M:IScrollInfo.LineRight
        void IScrollInfo.LineRight()
            {
            throw new NotImplementedException();
            }
        #endregion
        #region M:IScrollInfo.PageUp
        void IScrollInfo.PageUp()
            {
            throw new NotImplementedException();
            }
        #endregion
        #region M:IScrollInfo.PageDown
        void IScrollInfo.PageDown()
            {
            throw new NotImplementedException();
            }
        #endregion
        #region M:IScrollInfo.PageLeft
        void IScrollInfo.PageLeft()
            {
            throw new NotImplementedException();
            }
        #endregion
        #region M:IScrollInfo.PageRight
        void IScrollInfo.PageRight()
            {
            throw new NotImplementedException();
            }
        #endregion
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
        #region M:IScrollInfo.SetHorizontalOffset(Double)
        void IScrollInfo.SetHorizontalOffset(Double offset)
            {
            throw new NotImplementedException();
            }
        #endregion
        #region M:IScrollInfo.SetVerticalOffset(Double)
        void IScrollInfo.SetVerticalOffset(Double offset)
            {
            throw new NotImplementedException();
            }
        #endregion
        #region M:IScrollInfo.MakeVisible(Visual,Rect)
        Rect IScrollInfo.MakeVisible(Visual visual,Rect rectangle)
            {
            throw new NotImplementedException();
            }
        #endregion
        }
    }