using System;

namespace BinaryStudio.Modeling.PlatformUI.Controls.Primitives
    {
    [Flags]
    public enum DraggingScrollHitTestResultKind
        {
        None        = 0x00,
        Left        = 0x01,
        Top         = 0x02,
        Right       = 0x04,
        Bottom      = 0x08,
        LeftTop     = Left|Top,
        LeftBottom  = Left|Bottom,
        RightTop    = Right|Top,
        RightBottom = Right|Bottom,
        Outside     = 0x10
        }
    }
