using System.Windows.Controls.Primitives;

namespace BinaryStudio.Modeling.PlatformUI.Controls.Primitives
    {
    public class DragDeltaDirectedEventArgs : DragDeltaEventArgs
        {
        public DraggingDeltaDirection Direction { get; }
        internal DragDeltaDirectedEventArgs(DragDeltaEventArgs source,DraggingDeltaDirection direction)
            : base(source.HorizontalChange,source.VerticalChange)
            {
            Direction = direction;
            }
        }
    }
