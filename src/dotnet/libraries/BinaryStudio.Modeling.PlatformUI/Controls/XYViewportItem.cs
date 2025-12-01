using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace BinaryStudio.Modeling.PlatformUI.Controls
    {
    public abstract class XYViewportItem : Control
        {
        #region P:IsSelected:Boolean
        public static readonly DependencyProperty IsSelectedProperty = Selector.IsSelectedProperty.AddOwner(typeof(XYViewportItem),new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal, new PropertyChangedCallback(OnIsSelectedChanged)));
        private static void OnIsSelectedChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            if (sender is XYViewportItem source) {

                }
            }

        public Boolean IsSelected
            {
            get { return (Boolean)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
            }
        #endregion

        #region M:OnMouseLeftButtonDown(MouseButtonEventArgs)
        /// <summary>Invoked when an unhandled <see cref="E:System.Windows.UIElement.MouseLeftButtonDown"/> routed event is raised on this element. Implement this method to add class handling for this event.</summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.MouseButtonEventArgs"/> that contains the event data. The event data reports that the left mouse button was pressed.</param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e) {
            //Diagnostics.Print((new StackTrace()).GetFrame(0).GetMethod());
            if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control)) {
                var Selected = !IsSelected;
                if (Selected)
                    {
                    Owner.SelectItem(this);
                    }
                else
                    {
                    Owner.UnselectItem(this);
                    }
                }
            else
                {
                if (!IsSelected) {
                    Owner.UnselectAll();
                    Owner.SelectItem(this);
                    e.Handled = true;
                    }
                }
            e.Handled = true;
            }
        #endregion

        internal XYViewport Owner;
        }
    }