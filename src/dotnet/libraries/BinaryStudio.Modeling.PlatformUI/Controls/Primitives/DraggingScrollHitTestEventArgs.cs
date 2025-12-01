using System;
using System.Windows.Input;

namespace BinaryStudio.Modeling.PlatformUI.Controls.Primitives
    {
    public class DraggingScrollHitTestEventArgs : EventArgs
        {
        public DraggingScrollHitTestResultKind Kind { get;set; }
        public Cursor Cursor { get;set; }

        #region ctor
        internal DraggingScrollHitTestEventArgs()
            {
            }
        #endregion
        }
    }
