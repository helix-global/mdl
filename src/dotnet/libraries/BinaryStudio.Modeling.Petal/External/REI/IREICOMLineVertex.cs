using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.Runtime.CompilerServices.MethodImplOptions;

namespace RationalRose
    {
    /// <summary>
    /// The <see cref="IREICOMLineVertex"/> class defines objects that are the points where one line segment of an association or relation view ends and the next line segment begins.
    /// </summary>
    [Guid("B53888D2-3094-11D2-8153-00104B97EBD5")]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [ComImport]
    public interface IREICOMLineVertex : IREICOMObject
        {
        #region M:GetXPosition:Int16
        /// <summary>This method returns the X coordinate of the point where an association or relation view line segment begins or ends.</summary>
        /// <returns>X coordinate of the specified <see cref="IREICOMLineVertex"/> in Logical Units relative to the upper left hand corner of the image rendered by the Diagram <see cref="IREICOMDiagram.RenderToClipboard"/> method.</returns>
        [DispId(12694)]
        [MethodImpl(PreserveSig|InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int16 GetXPosition();
        #endregion
        #region M:GetYPosition:Int16
        /// <summary>This method returns the Y coordinate of the point where an association or relation view line segment begins or ends.</summary>
        /// <returns>Y coordinate of the specified <see cref="IREICOMLineVertex"/> in Logical Units relative to the upper left hand corner of the image rendered by the Diagram <see cref="IREICOMDiagram.RenderToClipboard"/> method.</returns>
        [DispId(12695)]
        [MethodImpl(PreserveSig|InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int16 GetYPosition();
        #endregion
        }
    }
