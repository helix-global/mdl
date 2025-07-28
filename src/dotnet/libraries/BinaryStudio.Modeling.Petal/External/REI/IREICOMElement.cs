using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace RationalRose
    {
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("D067F15F-6987-11D0-BBF0-00A024C67143")]
    [ComImport]
    public interface IREICOMElement : IREICOMObject
        {
        #region P:Name:String
        /// <summary>
        /// Name of a model element.
        /// </summary>
        [DispId(100)]
        String Name { [DispId(100), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(100), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:Application:Object
        /// <summary>Name of a model element.</summary>
        [DispId(12523)]
        Object Application { [DispId(12523), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(12523), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:Model:IREICOMModel
        /// <summary>Name of a model element.</summary>
        [DispId(12524)]
        IREICOMModel Model { [DispId(12524), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(12524), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion

        #region M:GetUniqueID:String
        /// <summary>This function retrieves the unique ID for a model element. Each element in a model has a unique ID, which is set internally. You cannot set this value, but you can retrieve it.</summary>
        /// <returns>Returns the string value of the element’s unique ID.</returns>
        [DispId(102)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.BStr)]
        String GetUniqueID();
        #endregion
        #region M:GetCurrentPropertySetName(String):String
        /// <summary>This function returns the name of the currently active property set given the element and a tool name.</summary>
        /// <param name="ToolName">Name of the tool to which the property set belongs.</param>
        /// <returns>Returns the name of the currently active property set.</returns>
        [DispId(109)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.BStr)]
        String GetCurrentPropertySetName([MarshalAs(UnmanagedType.BStr)] String ToolName);
        #endregion
        #region M:OverrideProperty(String,String,String):Boolean
        /// <summary>This function overrides the default value of a element’s property. If the given property does not exist in the default set, a new string type property is created for this element only.</summary>
        /// <param name="ToolName">Name of the tool to which the property applies.</param>
        /// <param name="PropName">Name of the property whose default value is being overridden.</param>
        /// <param name="Value">Value being set in place of the default value.</param>
        /// <returns>Returns a value of True when the property value is successfully overridden.</returns>
        [DispId(110)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean OverrideProperty([MarshalAs(UnmanagedType.BStr)] String ToolName, [MarshalAs(UnmanagedType.BStr)] String PropName, [MarshalAs(UnmanagedType.BStr)] String Value);
        #endregion
        #region M:InheritProperty(String,String):Boolean
        /// <summary>This function removes the overridden value from an element’s property so that the default value is used . If there is no default value, then a call to the GetPropertyValue method on the inherited property returns an empty string.</summary>
        /// <param name="ToolName">Name of the tool to which the property applies.</param>
        /// <param name="PropName">Name of the property whose value is being inherited.</param>
        /// <returns>Returns a value of True when the property is returned to its inherited (default) value.</returns>
        [DispId(111)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean InheritProperty([MarshalAs(UnmanagedType.BStr)] String ToolName, [MarshalAs(UnmanagedType.BStr)] String PropName);
        #endregion
        #region M:GetPropertyValue(String,String):String
        /// <summary>This function retrieves the current value of a property of an element, given a property and tool name.</summary>
        /// <param name="ToolName">Name of the tool for which a property value is being retrieved.</param>
        /// <param name="PropName">Name of the property whose value is being retrieved.</param>
        /// <returns>Returns the current value for the given tool and property.</returns>
        [DispId(119)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.BStr)]
        String GetPropertyValue([MarshalAs(UnmanagedType.BStr)] String ToolName, [MarshalAs(UnmanagedType.BStr)] String PropName);
        #endregion
        #region M:GetDefaultPropertyValue(String,String):String
        /// <summary>This function retrieves the default property value given a tool name and property name.</summary>
        /// <param name="ToolName">Name of the tool to which the property applies.</param>
        /// <param name="PropName">Name of the property being retrieved.</param>
        /// <returns>Returns the default property value for the specified tool name and property name.</returns>
        [DispId(120)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.BStr)]
        String GetDefaultPropertyValue([MarshalAs(UnmanagedType.BStr)] String ToolName, [MarshalAs(UnmanagedType.BStr)] String PropName);
        #endregion
        #region M:FindProperty(String,String):IREICOMProperty
        /// <summary>Returns the default property given its name and associated tool name.</summary>
        /// <param name="ToolName">Name of the tool to which the overridden or default property applies.</param>
        /// <param name="PropName">Name of the overridden or default property being retrieved.</param>
        /// <returns>Returns the overridden or default property given its name and its associated tool name.</returns>
        [DispId(121)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMProperty FindProperty([MarshalAs(UnmanagedType.BStr)] String ToolName, [MarshalAs(UnmanagedType.BStr)] String PropName);
        #endregion
        #region M:GetAllProperties:IREICOMPropertyCollection
        /// <summary>This function returns the collection of properties belonging to the specified element.</summary>
        /// <returns>Returns the collection of properties belonging to the specified element.</returns>
        [DispId(122)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMPropertyCollection GetAllProperties();
        #endregion
        #region M:GetToolProperties(String):IREICOMPropertyCollection
        /// <summary>This function retrieves the properties for the given element and tool name.</summary>
        /// <param name="ToolName">Name of the tool for which a properties value is being retrieved.</param>
        /// <returns>Returns the collection of properties defined for the specified tool name and element.</returns>
        [DispId(123)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMPropertyCollection GetToolProperties([MarshalAs(UnmanagedType.BStr)] String ToolName);
        #endregion
        #region M:IsOverriddenProperty(String,String):Boolean
        /// <summary>This function indicates whether the default value of a property is currently overridden by a different value.</summary>
        /// <param name="ToolName">Tool name to which the property applies.</param>
        /// <param name="PropName">Name of the property whose overridden status is being checked.</param>
        /// <returns>Returns a value of True if the default value of a property is currently overridden.</returns>
        [DispId(124)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean IsOverriddenProperty([MarshalAs(UnmanagedType.BStr)] String ToolName, [MarshalAs(UnmanagedType.BStr)] String PropName);
        #endregion
        #region M:IsDefaultProperty(String,String):Boolean
        /// <summary>This function indicates whether the current value of a property is set to its default value.</summary>
        /// <param name="ToolName">Tool name to which the property applies.</param>
        /// <param name="PropName">Name of the property whose default status is being checked.</param>
        /// <returns>Returns a value of True if the current value of the property is set to its default value.</returns>
        [DispId(125)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean IsDefaultProperty([MarshalAs(UnmanagedType.BStr)] String ToolName, [MarshalAs(UnmanagedType.BStr)] String PropName);
        #endregion
        #region M:FindDefaultProperty(String,String):IREICOMProperty
        /// <summary>This method returns the default property, regardless of whether or not it has been overridden. To retrieve the overridden property, use FindProperty.</summary>
        /// <param name="ToolName">Name of the tool to which the default property applies.</param>
        /// <param name="PropName">Name of the default property being retrieved.</param>
        /// <returns>Returns the default property given its name and associated tool name.</returns>
        [DispId(126)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMProperty FindDefaultProperty([MarshalAs(UnmanagedType.BStr)] String ToolName, [MarshalAs(UnmanagedType.BStr)] String PropName);
        #endregion
        #region M:CreateProperty(String,String,String,String):Boolean
        /// <summary>This function creates a new property for a given model element and tool.</summary>
        /// <param name="ToolName">Name of the tool to which the property applies.</param>
        /// <param name="PropName">Name of the property being created.</param>
        /// <param name="Value">Default value of the new property.</param>
        /// <param name="Type">Property type of the property.</param>
        /// <returns>Returns a value of True when the property is created for the element.</returns>
        [DispId(127)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean CreateProperty([MarshalAs(UnmanagedType.BStr)] String ToolName, [MarshalAs(UnmanagedType.BStr)] String PropName, [MarshalAs(UnmanagedType.BStr)] String Value, [MarshalAs(UnmanagedType.BStr)] String Type);
        #endregion
        #region M:GetPropertyClassName:String
        /// <summary>This function retrieves the class name of a given element.</summary>
        /// <returns>Returns the class name for the given element.</returns>
        [DispId(128)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.BStr)]
        String GetPropertyClassName();
        #endregion
        #region M:GetDefaultSetNames(String):IREICOMStringCollection
        /// <summary>This function retrieves the names of the default property sets defined for the specified element and tool.</summary>
        /// <param name="ToolName">Name of the tool whose default set names are being retrieved.</param>
        /// <returns>Returns the names of the default property sets defined for the given element and tool name.</returns>
        [DispId(129)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMStringCollection GetDefaultSetNames([MarshalAs(UnmanagedType.BStr)] String ToolName);
        #endregion
        #region M:GetToolNames:IREICOMStringCollection
        /// <summary>This function retrieves the names of the tools defined for the specified element.</summary>
        /// <returns>Returns the names of the tools for the given element.</returns>
        [DispId(130)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMStringCollection GetToolNames();
        #endregion
        #region M:SetCurrentPropertySetName(String,String):Boolean
        /// <summary>This function specifies a given property set as the current property set for the element.</summary>
        /// <param name="ToolName">Name of the tool to which the property set applies.</param>
        /// <param name="SetName">Name of the property set to become the current set.</param>
        /// <returns>Returns a value of True when the given property set is set to the current property set for the element.</returns>
        [DispId(131)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean SetCurrentPropertySetName([MarshalAs(UnmanagedType.BStr)] String ToolName, [MarshalAs(UnmanagedType.BStr)] String SetName);
        #endregion
        #region M:GetQualifiedName:String
        /// <summary>
        /// This function retrieves the qualified name of a model element.<br/>
        /// The qualified name includes the names of the packages to which the element belongs. This allows the name to resolve to a specific class, since Rational Rose allows multiple classes of the same name to exist in a model, as long as they are in different packages.
        /// </summary>
        /// <returns>Returns the qualified name of the element.</returns>
        [DispId(12555)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.BStr)]
        String GetQualifiedName();
        #endregion
        #region M:RenderIconToClipboard:Boolean
        /// <summary>This method renders the browser icon of the specified element to the Clipboard.</summary>
        /// <returns>
        /// Returns the outcome of the rendering.<br/>
        /// If the icon is successfully rendered to the clipboard, this value is TRUE.<br/>
        /// If the icon is not successfully rendered to the clipboard, this value is FALSE.
        /// </returns>
        [DispId(12820)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean RenderIconToClipboard();
        #endregion
        #region M:GetIconIndex:Int16
        /// <summary>This method retrieves the index of the bitmap, in Rose’s predefined set of browser icons, for the specified element.</summary>
        /// <returns>Index of the specified element’s browser icon.</returns>
        [DispId(12824)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int16 GetIconIndex();
        #endregion
        #region M:GetUserOverriddenProperties(String):IREICOMPropertyCollection
        [DispId(12886)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMPropertyCollection GetUserOverriddenProperties([MarshalAs(UnmanagedType.BStr)] String ToolName);
        #endregion
        }
    }