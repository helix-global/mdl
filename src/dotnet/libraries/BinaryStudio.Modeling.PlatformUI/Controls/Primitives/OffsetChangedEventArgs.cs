using System;
using System.Windows;

namespace BinaryStudio.Modeling.PlatformUI.Controls.Primitives
    {
    public class OffsetChangedEventArgs : EventArgs
        {
        public Vector OldOffset { get; }
        public Vector NewOffset { get; }

        #region ctor{Vector,Vector}
        public OffsetChangedEventArgs(Vector OldOffset,Vector NewOffset)
            {
            this.OldOffset = OldOffset;
            this.NewOffset = NewOffset;
            }
        #endregion
        }
    }
