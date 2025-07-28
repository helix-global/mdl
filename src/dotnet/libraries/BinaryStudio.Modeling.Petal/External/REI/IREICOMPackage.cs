using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace RationalRose
    {
    /// <summary>
    /// The Package Class is a container for the model elements that correspond to the UML Package concept.<br/>
    /// Package class methods allow you to determine whether a package is the root package in a model, as well as to obtain the OLE object associated with the package.
    /// </summary>
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("47D975C1-8A8D-11D0-A214-444553540000")]
    [ComImport]
    public interface IREICOMPackage : IREICOMControllableUnit
        {
        #region M:IsRootPackage:Boolean
        /// <summary>This function finds out if the specified package is the root package (category) of the model.</summary>
        /// <returns>Returns a value of True if the package is the root package (category) of the model.</returns>
        [DispId(621)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean IsRootPackage();
        #endregion
        }
    }