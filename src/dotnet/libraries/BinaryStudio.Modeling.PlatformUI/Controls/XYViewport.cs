using System.Windows;
using System.Windows.Controls.Primitives;

namespace BinaryStudio.Modeling.PlatformUI.Controls
    {
    public class XYViewport : MultiSelector
        {
        static XYViewport()
            {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(XYViewport), new FrameworkPropertyMetadata(typeof(XYViewport)));
            }
        }
    }
