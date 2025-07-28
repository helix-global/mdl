using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace RationalRose
    {
    /// <summary>
    /// The <see cref="IREICOMControllableUnit"/> class is an abstract class that exposes Rose’s controllable unit functionality in the extensibility interface.<br/>
    /// For example, you can:
    /// <list type="bullet">
    ///   <item>Load and unload units.</item>
    ///   <item>Determine whether a unit is modifiable or has been modified.</item>
    ///   <item>Determine whether or not a unit is controlled.</item>
    ///   <item>Get the file name associated with a unit.</item>
    ///   <item>Save a unit to a file.</item>
    /// </list><br/>
    /// </summary>
    [Guid("32C862A7-8AA9-11D0-A70B-0000F803584A")]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [ComImport]
    public interface IREICOMControllableUnit : IREICOMItem
        {
        [DispId(12881)]
        Int32 PetalVersion { [DispId(12881), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(12881), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

        #region M:IsControlled:Boolean
        /// <summary>This function checks whether a given controllable unit has an associated file.</summary>
        /// <returns>Returns a value of True if the given controllable unit has an associated file.</returns>
        [DispId(12433)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean IsControlled();
        #endregion
        #region M:Control(String):Boolean
        /// <summary>This method associates a controllable unit with a filename, so that it can be passed to a configuration management application.</summary>
        /// <param name="Path">Fully qualified path and file name that contain the unit.</param>
        /// <returns>Returns a value of True when the unit is successfully controlled.</returns>
        [DispId(12434)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean Control([MarshalAs(UnmanagedType.BStr)] String Path);
        #endregion
        #region M:IsLoaded:Boolean
        /// <summary>This function checks whether a given controllable unit is loaded in the current model.</summary>
        /// <returns>Returns a value of True if the given controllable unit is loaded in the current model.</returns>
        [DispId(12435)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean IsLoaded();
        #endregion
        #region M:Load:Boolean
        /// <summary>This function loads a controllable unit in the current model.</summary>
        /// <returns>Returns a value of True when the controllable unit is loaded in the current model.</returns>
        [DispId(12436)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean Load();
        #endregion
        #region M:IsModifiable:Boolean
        /// <summary>This function checks whether a given controllable unit is flagged as modifiable.</summary>
        /// <returns>Returns a value of True if the unit is flagged as modifiable.</returns>
        [DispId(12438)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean IsModifiable();
        #endregion
        #region M:Unload:Boolean
        /// <summary>This function unloads a controllable unit from the current model.</summary>
        /// <returns>Returns a value of True when the controllable unit is unloaded from the current model.</returns>
        [DispId(12439)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean Unload();
        #endregion
        #region M:Modifiable(Boolean):Boolean
        /// <summary>
        /// This function sets a controllable unit as modifiable or not modifiable:
        /// <list type="bullet">
        ///   <item>If you pass a parameter of True on this method, the controllable unit will be modifiable.</item>
        ///   <item>If you pass a parameter of False on this method, the controllable unit will not be modifiable.</item>
        /// </list>
        /// </summary>
        /// <param name="Modifiable">If True, controllable unit is modifiable; if False, controllable unit is not modifiable.</param>
        /// <returns>Returns a value of True when the controllable unit’s modifiable status has been successfully set.</returns>
        [DispId(12440)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean Modifiable(Boolean Modifiable);
        #endregion
        #region M:GetFileName:String
        /// <summary>This function retrieves the name of the file that contains the controllable unit.</summary>
        /// <returns>Returns the name of the file that contains the controllable unit.</returns>
        [DispId(12441)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.BStr)]
        String GetFileName();
        #endregion
        #region M:Save:Boolean
        /// <summary>This function saves a controllable unit.</summary>
        /// <returns>Returns a value of True when the controllable unit is successfully saved.</returns>
        [DispId(12442)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean Save();
        #endregion
        #region M:SaveAs(String):Boolean
        /// <summary>This function saves a controllable unit to a different file.</summary>
        /// <param name="Path">Fully qualified path and file name in which to save the controllable unit.</param>
        /// <returns>Returns a value of True when the controllable unit is successfully saved.</returns>
        [DispId(12443)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean SaveAs([MarshalAs(UnmanagedType.BStr)] String Path);
        #endregion
        #region M:IsModified:Boolean
        /// <summary>This function checks whether a given controllable unit has been modified since the last time it was checked out of source control.</summary>
        /// <returns>Returns a value of True if the unit has been modified since the last time it was checked out of source control.</returns>
        [DispId(12654)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean IsModified();
        #endregion
        #region M:Uncontrol:Boolean
        /// <summary>This function uncontrols a controllable unit.</summary>
        /// <returns>Returns a value of True when the controllable unit is uncontrolled.</returns>
        [DispId(12655)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean Uncontrol();
        #endregion
        #region M:Refresh
        /// <summary>This method updates a loaded controllable unit. Use Refresh to update a controllable unit that has changed since it was loaded. To determine whether or not a loaded controllable unit needs updating, use the NeedsRefreshing method.</summary>
        [DispId(12701)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Refresh();
        #endregion
        #region M:GetSubUnitItems:IREICOMControllableUnitCollection
        /// <summary>This method retrieves the immediate subunits of the specified controllable unit. This method is not recursive. If the subunits of the specified controllable unit have subunits, GetSubUnitItems does not include those subunits in the returned collection. </summary>
        /// <returns>Returns the collection of controllable units that are immediate subunits of the specified controllable unit.</returns>
        [DispId(12702)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMControllableUnitCollection GetSubUnitItems();
        #endregion
        #region M:IsLocked:Boolean
        /// <summary>This method checks whether or not a given controllable unit is locked by another process.</summary>
        /// <returns>
        /// Returns a value of True if the controllable unit is locked and is therefore in use by another process and cannot be modified.<br/>
        /// Returns a value of False if the controllable unit is locked by the calling process which can, therefore, modify the controllable unit.
        /// </returns>
        [DispId(12703)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean IsLocked();
        #endregion
        #region M:NeedsRefreshing:Boolean
        /// <summary>This method checks whether or not the specified controllable unit needs to be updated. That is, this method checks whether or not the controllable unit has changed since it was loaded. After determining that the controllable unit needs to be updated, use the Refresh method to update the controllable unit.</summary>
        /// <returns>Returns a value of True when the controllable unit has changed and needs to be updated.</returns>
        [DispId(12704)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean NeedsRefreshing();
        #endregion
        #region M:GetAllSubUnitItems:IREICOMControllableUnitCollection
        /// <summary>This method recursively retrieves all subunits of the specified controllable unit. It retrieves the immediate subunits of the specified controllable unit plus all subunits of the immediate subunits and so on.</summary>
        /// <returns>Recursively returns the collection of controllable units that are subunits of the specified controllable unit.</returns>
        [DispId(12707)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMControllableUnitCollection GetAllSubUnitItems();
        #endregion
        #region M:Lock
        /// <summary>This method attempts to lock a controllable unit. For the lock to be successful, the controllable unit must not be locked by another process. To determine whether or not the controllable unit is locked by another process, use IsLocked.</summary>
        [DispId(12708)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Lock();
        #endregion
        #region M:Unlock
        /// <summary>This method attempts to unlock a controllable unit. For the unlock to be successful, the calling process must own the lock on the controllable unit. To determine whether or not the controllable unit is locked by another process, use IsLocked.</summary>
        [DispId(12709)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Unlock();
        #endregion
        }
    }