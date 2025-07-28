using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace RationalRose
    {
    /// <summary>
    /// Once you use the application class methods to set the current model, the model class provides properties and methods that allow you to work with the objects in that model.<br/>
    /// For example, you can:
    /// <list type="bullet">
    ///   <item>Add objects (classes, categories, relationships, processors, devices, diagrams, etc.) to the model.</item>
    ///   <item>Retrieve objects from the model.</item>
    ///   <item>Delete objects from the model.</item>
    /// </list>
    /// </summary>
    [Guid("E38942A0-8621-11CF-B3D4-00A0241DB1D0")]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [ComImport]
    public interface IREICOMModel : IREICOMPackage
        {
        #region P:RootCategory:IREICOMCategory
        /// <summary>
        /// Category named "Top Level" in Rose. RootCategory corresponds to the model’s logical view.
        /// </summary>
        [DispId(417)]
        IREICOMCategory RootCategory { [DispId(417), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(417), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:RootSubsystem:IREICOMSubsystem
        /// <summary>
        /// Subsystem named "Top Level" in Rose. RootSubsystem corresponds to the model’s component view.
        /// </summary>
        [DispId(418)]
        IREICOMSubsystem RootSubsystem { [DispId(418), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(418), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:DeploymentDiagram:IREICOMDeploymentDiagram
        /// <summary>
        /// Specifies a deployment diagram belonging to the model.
        /// </summary>
        [DispId(420)]
        IREICOMDeploymentDiagram DeploymentDiagram { [DispId(420), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(420), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:UseCases:IREICOMUseCaseCollection
        /// <summary>
        /// Specifies the collection that contains the use cases that belong to the model.
        /// </summary>
        [DispId(421)]
        IREICOMUseCaseCollection UseCases { [DispId(421), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(421), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:RootUseCaseCategory:IREICOMCategory
        /// <summary>
        /// Root category to which the use cases belong. RootUseCaseCategory corresponds to the model’s UseCase view.
        /// </summary>
        [DispId(422)]
        IREICOMCategory RootUseCaseCategory { [DispId(422), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(422), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:DefaultProperties:IREICOMDefaultModelProperties
        /// <summary>
        /// Collection of default properties belonging to the model.
        /// </summary>
        [DispId(12471)]
        IREICOMDefaultModelProperties DefaultProperties { [DispId(12471), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(12471), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:DeploymentUnit:IREICOMDeploymentUnit
        /// <summary>
        /// This property corresponds to the controllable unit form of the Deployment Diagram. This allows you to control, uncontrol, load, or unload the Deployment Diagram.
        /// </summary>
        [DispId(12676)]
        IREICOMDeploymentUnit DeploymentUnit { [DispId(12676), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(12676), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:DefaultLanguage:String
        /// <summary>
        /// This property is any valid string to be assigned as the default language to all subsequently created classes and components until the default language is set to something else.
        /// </summary>
        [DispId(12680)]
        String DefaultLanguage { [DispId(12680), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(12680), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:Notation:REINotationTypes
        /// <summary>This property specifies the Notation used by the model (e.g., Booch).</summary>
        [DispId(12691)]
        REINotationTypes Notation { [DispId(12691), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(12691), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion

        [DispId(12882)]
        Boolean MaintainModelForAutoloading { [DispId(12882), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(12882), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }

        #region M:GetAllAssociations:IREICOMAssociationCollection
        [DispId(412)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMAssociationCollection GetAllAssociations();
        #endregion
        #region M:AddProcessor(String):IREICOMProcessor
        /// <summary>This function creates a new processor and adds it to a model.</summary>
        /// <param name="Name">Name of the Processor being added to the model.</param>
        /// <returns>Returns the processor being added to the model.</returns>
        [DispId(424)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMProcessor AddProcessor([MarshalAs(UnmanagedType.BStr)] String Name);
        #endregion
        #region M:DeleteProcessor(IREICOMProcessor):Boolean
        /// <summary>This function deletes a processor from a model.</summary>
        /// <param name="Processor">Instance of the processor being deleted.</param>
        /// <returns>Returns a value of True when the processor is deleted from the model.</returns>
        [DispId(425)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean DeleteProcessor([MarshalAs(UnmanagedType.Interface)] IREICOMProcessor Processor);
        #endregion
        #region M:AddDevice(String):IREICOMDevice
        /// <summary>This function creates a new device and adds it to a model.</summary>
        /// <param name="Name">Name of the device being added to the model.</param>
        /// <returns>Returns the newly created device.</returns>
        [DispId(426)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMDevice AddDevice([MarshalAs(UnmanagedType.BStr)] String Name);
        #endregion
        #region M:DeleteDevice(IREICOMDevice):Boolean
        /// <summary>This function deletes a device from a model.</summary>
        /// <param name="Device">Instance of the device being deleted.</param>
        /// <returns>Returns a value of True when the device is deleted.</returns>
        [DispId(427)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean DeleteDevice([MarshalAs(UnmanagedType.Interface)] IREICOMDevice Device);
        #endregion
        #region M:GetSelectedClasses:IREICOMClassCollection
        /// <summary>This function returns all classes selected in the current model.</summary>
        /// <returns>Returns the collection of classes currently selected in the model.</returns>
        [DispId(428)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMClassCollection GetSelectedClasses();
        #endregion
        #region M:GetSelectedCategories:IREICOMCategoryCollection
        /// <summary>This function returns all categories selected in the current model.</summary>
        /// <returns>Returns the collection of categories currently selected in the model.</returns>
        [DispId(429)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMCategoryCollection GetSelectedCategories();
        #endregion
        #region M:GetSelectedModules:IREICOMModuleCollection
        /// <summary>This function returns all modules selected in the current model.</summary>
        /// <returns>Contains the collection of modules currently selected in the model.</returns>
        [DispId(430)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMModuleCollection GetSelectedModules();
        #endregion
        #region M:GetSelectedSubsystems:IREICOMSubsystemCollection
        /// <summary>This function returns all subsystems selected in the current model.</summary>
        /// <returns>Returns the collection of subsystems currently selected in the model.</returns>
        [DispId(431)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMSubsystemCollection GetSelectedSubsystems();
        #endregion
        #region M:GetAllClasses:IREICOMClassCollection
        /// <summary>This method returns all classes belonging to all categories in the model.</summary>
        /// <returns>Returns the collection of classes retrieved from the model.</returns>
        [DispId(432)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMClassCollection GetAllClasses();
        #endregion
        #region M:GetAllCategories:IREICOMCategoryCollection
        /// <summary>This function returns all categories belonging to the model.</summary>
        /// <returns>Returns the collection of categories retrieved from the model.</returns>
        [DispId(433)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMCategoryCollection GetAllCategories();
        #endregion
        #region M:GetAllModules:IREICOMModuleCollection
        /// <summary>This function returns all modules belonging to the model.</summary>
        /// <returns>Returns the collection of modules retrieved from the model.</returns>
        [DispId(434)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMModuleCollection GetAllModules();
        #endregion
        #region M:GetAllSubsystems:IREICOMSubsystemCollection
        /// <summary>This function returns all subsystems belonging to the model.</summary>
        /// <returns>Returns the collection of subsystems retrieved from the model.</returns>
        [DispId(435)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMSubsystemCollection GetAllSubsystems();
        #endregion
        #region M:GetAllProcessors:IREICOMProcessorCollection
        /// <summary>This function returns all processors belonging to the model.</summary>
        /// <returns>Returns the collection of processors retrieved from the model.</returns>
        [DispId(436)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMProcessorCollection GetAllProcessors();
        #endregion
        #region M:GetAllDevices:IREICOMDeviceCollection
        /// <summary>This function returns all devices belonging to the model.</summary>
        /// <returns>Returns the collection of devices retrieved from the model.</returns>
        [DispId(437)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMDeviceCollection GetAllDevices();
        #endregion
        #region M:GetSelectedUseCases:IREICOMUseCaseCollection
        /// <summary>This function returns all use cases selected in the current model.</summary>
        /// <returns>Returns the collection of use cases currently selected in the model.</returns>
        [DispId(438)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMUseCaseCollection GetSelectedUseCases();
        #endregion
        #region M:GetAllUseCases:IREICOMUseCaseCollection
        /// <summary>This function returns all use cases belonging to the model.</summary>
        /// <returns>Returns the collection of use cases retrieved from the model.</returns>
        [DispId(439)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMUseCaseCollection GetAllUseCases();
        #endregion
        #region M:FindItems(String):IREICOMItemCollection
        /// <summary>This function returns a collection of items belonging to the model.</summary>
        /// <param name="ItemName">Name of the item for which to search the model.</param>
        /// <returns>Returns a collection of items that match the given item name.</returns>
        [DispId(12472)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMItemCollection FindItems([MarshalAs(UnmanagedType.BStr)] String ItemName);
        #endregion
        #region M:FindItemWithID(String):IREICOMItem
        /// <summary>This function returns a specific item given the item’s unique ID.</summary>
        /// <param name="UniqueID">UniqueID of the item for which to search.</param>
        /// <returns>Returns the item that corresponds to the given UniqueID.</returns>
        [DispId(12473)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMItem FindItemWithID([MarshalAs(UnmanagedType.BStr)] String UniqueID);
        #endregion
        #region M:FindClasses(String):IREICOMClassCollection
        /// <summary>This function returns a collection of classes belonging to the model.</summary>
        /// <param name="ClassName">Name of the class for which to search the model.</param>
        /// <returns>Returns a collection of classes that match the given class name.</returns>
        [DispId(12474)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMClassCollection FindClasses([MarshalAs(UnmanagedType.BStr)] String ClassName);
        #endregion
        #region M:FindClassWithID(String):IREICOMClass
        /// <summary>This function returns a specific class given the class’s unique ID.</summary>
        /// <param name="UniqueID">UniqueID of the Class for which to search.</param>
        /// <returns>Returns the Class that corresponds to the given UniqueID.</returns>
        [DispId(12475)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMClass FindClassWithID([MarshalAs(UnmanagedType.BStr)] String UniqueID);
        #endregion
        #region M:FindCategories(String):IREICOMCategoryCollection
        /// <summary>This function returns a collection of categories belonging to the model.</summary>
        /// <param name="CategoryName">Name of the category for which to search the model.</param>
        /// <returns>Returns a collection of categories that match the given category name.</returns>
        [DispId(12476)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMCategoryCollection FindCategories([MarshalAs(UnmanagedType.BStr)] String CategoryName);
        #endregion
        #region M:FindCategoryWithID(String):IREICOMCategory
        /// <summary>This function returns a specific category given the category’s unique ID.</summary>
        /// <param name="UniqueID">UniqueID of the category for which to search.</param>
        /// <returns>Returns the category that corresponds to the given UniqueID.</returns>
        [DispId(12477)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMCategory FindCategoryWithID([MarshalAs(UnmanagedType.BStr)] String UniqueID);
        #endregion
        #region M:GetActiveDiagram:IREICOMDiagram
        /// <summary>This function returns the currently active diagram from the current model. The active diagram is the window in Rose which currently has the focus.</summary>
        /// <returns>
        /// Returns the currently active Rose diagram from the model.<br/>
        /// Returns nothing if a window that is not a diagram, such as a script window or the Browser, has the focus.
        /// </returns>
        [DispId(12527)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMDiagram GetActiveDiagram();
        #endregion
        #region M:GetSelectedItems:IREICOMItemCollection
        /// <summary>This method returns the collection of all RoseItems selected in the current model. These items may be classes, components, packages, etc. GetSelectedItems returns all selected RoseItem objects regardless of whether they are selected in the browser or the currently active diagram. This method gives you the flexibility to work with different types of selected items (e.g., packages and classes) at the same time. This is instead of having to separate different types of items and then work with each type (e.g., GetSelectedClasses and work with the classes, then GetSelectedCategories and work with the packages).</summary>
        /// <returns>Returns the collection of RoseItems currently selected in the model. Please note that the only items returned are those that inherit from RoseItem. For example, External Documents do not inherit from RoseItem and, therefore, are not returned by this method.</returns>
        [DispId(12681)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMItemCollection GetSelectedItems();
        #endregion
        #region M:ResolveReferences
        /// <summary>This method fixes unresolved references in the current model provided all the necessary model elements are loaded in the model. This method iterates through all the items in the model and resolves any previously unresolved associations and relations.</summary>
        [DispId(12710)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ResolveReferences();
        #endregion
        #region M:GetSelectedExternalDocuments:IREICOMExternalDocumentCollection
        /// <summary>This method retrieves all external documents selected in the current model.</summary>
        /// <returns>Returns the collection of external documents currently selected in the model.</returns>
        [DispId(12788)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMExternalDocumentCollection GetSelectedExternalDocuments();
        #endregion
        #region M:FindDiagramWithID(String):IREICOMDiagram
        /// <summary>This method retrieves the diagram given its unique internal Rose identification.</summary>
        /// <param name="UniqueID">Unique ID of the diagram to retrieve.</param>
        /// <returns>Returns the diagram that corresponds to the given unique ID.</returns>
        [DispId(12817)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMDiagram FindDiagramWithID([MarshalAs(UnmanagedType.BStr)] String UniqueID);
        #endregion
        #region M:LoadControlledUnits(IREICOMControllableUnitCollection):Boolean
        /// <summary>This method loads specified unloaded controlled units into a model.</summary>
        /// <param name="ControlledUnits">Collection of controlled units to be loaded.</param>
        /// <returns>Returns TRUE if the controlled units are successfully loaded into the model.</returns>
        [DispId(12828)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean LoadControlledUnits([MarshalAs(UnmanagedType.Interface)] IREICOMControllableUnitCollection ControlledUnits);
        #endregion
        #region M:GetSelectedDiagrams:IREICOMDiagramCollection
        /// <summary>This method returns all diagrams selected in the browser.</summary>
        /// <returns>Collection of diagrams currently selected in the browser.</returns>
        [DispId(12831)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMDiagramCollection GetSelectedDiagrams();
        #endregion
        #region M:Import(String):Boolean
        /// <summary>This method imports packages (REI Category class) and subsystems into the current model.</summary>
        /// <param name="Name">Name of the package or subsystem to be imported.</param>
        /// <returns>Returns TRUE if the package or subsystem is successfully imported into the model.</returns>
        [DispId(12835)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean Import([MarshalAs(UnmanagedType.BStr)] String Name);
        #endregion
        #region M:GetAllClassesEx(Boolean,Boolean):IREICOMClassCollection
        /// <summary>
        /// The GetAllClassesEx method gives you more control than the GetAllClasses method. The GetAllClassesEx method allows you to specify which classes are to be returned in the resulting collection. You can retrieve a combination of child and nested classes for a Model object depending on how you set the blnRecursive and blnNested arguments.
        /// </summary>
        /// <param name="Recursive">
        /// Set to TRUE to retrieve all classes in each child package (Category object) of the Use Case and Logical Views in addition to the classes in the Use Case and Logical Views.<br/>
        /// Set to FALSE to retrieve only the classes whose context is the Use Case or Logical View.
        /// </param>
        /// <param name="Nested">
        /// Set to TRUE to retrieve all nested classes and all their sub-nested classes.<br/>
        /// Set to FALSE to retrieve only the non-nested classes.
        /// </param>
        /// <returns>The collection of classes retrieved from the model.</returns>
        [DispId(12858)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMClassCollection GetAllClassesEx(Boolean Recursive, Boolean Nested);
        #endregion

        [DispId(12879)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int16 LoadClassClosure([MarshalAs(UnmanagedType.Interface)] IREICOMClass theClass, Int16 depth, Boolean bReportInfoNotFound);

        [DispId(12880)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int16 LoadClosure([MarshalAs(UnmanagedType.BStr)] String sFQName, Int16 depth, Boolean bReportInfoNotFound);
        }
    }