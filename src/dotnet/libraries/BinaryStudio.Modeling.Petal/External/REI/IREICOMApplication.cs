using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace RationalRose
    {
    /// <summary>
    /// Use the application class to:
    /// <list type="bullet">
    ///   <item>Create a new model</item>
    ///   <item>Select an existing model as the current model</item>
    ///   <item>Determine the characteristics of the Rational Rose application being controlled by your script.</item>
    /// </list>
    /// Here are a few of the application characteristics you can control with application class properties and methods:
    /// <list type="bullet">
    ///   <item>How (and if) the Rational Rose application appears on the computer screen while the script is running</item>
    ///   <item>The size and position of the Rational Rose application window</item>
    ///   <item>Whether to write errors to the error log</item>
    /// </list>
    /// </summary>
    [SuppressMessage("ReSharper","UnusedMember.Global")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("D7BC1B40-8618-11CF-B3D4-00A0241DB1D0")]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [ComImport]
    public interface IREICOMApplication
        {
        #region P:Visible:Boolean
        /// <summary>
        /// Controls whether the Rose application is visible on the computer screen.
        /// </summary>
        [DispId(202)]
        Boolean Visible { [DispId(202), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(202), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:Top:Int16
        /// <summary>
        /// Specifies the distance between the top of the main window and top of the screen.
        /// </summary>
        [DispId(205)]
        Int16 Top { [DispId(205), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(205), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:Left:Int16
        /// <summary>
        /// Specifies the distance between the left side of the main window and the left side of the screen.
        /// </summary>
        [DispId(206)]
        Int16 Left { [DispId(206), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(206), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:Height:Int16
        /// <summary>
        /// Specifies the height of the main window.
        /// </summary>
        [DispId(207)]
        Int16 Height { [DispId(207), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(207), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:Width:Int16
        /// <summary>
        /// Specifies the width of the main window.
        /// </summary>
        [DispId(208)]
        Int16 Width { [DispId(208), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(208), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:CurrentModel:IREICOMModel
        /// <summary>
        /// Specifies the model that is currently open in Rose.
        /// </summary>
        [DispId(209)]
        IREICOMModel CurrentModel { [DispId(209), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(209), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:PathMap:IREICOMPathMap
        /// <summary>
        /// Returns the path map defined for the current Rose application.
        /// </summary>
        [DispId(224)]
        IREICOMPathMap PathMap { [DispId(224), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(224), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:Version:String
        /// <summary>
        /// Returns the version of the currently active Rose application.  Corresponds to the information provided when you select About from the Help menu in Rose.
        /// </summary>
        [DispId(231)]
        String Version { [DispId(231), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(231), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:ProductName:String
        /// <summary>
        /// Returns the product name for the currently active Rose application.
        /// </summary>
        [DispId(232)]
        String ProductName { [DispId(232), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(232), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:ApplicationPath:String
        /// <summary>
        /// Specifies the path to the Rose application to execute.
        /// </summary>
        [DispId(233)]
        String ApplicationPath { [DispId(233), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(233), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:AddInManager:IREICOMAddInManager
        /// <summary>
        /// Specifies the Rational Rose add-in manager belonging to the currently active Rational Rose executable.
        /// </summary>
        [DispId(12544)]
        IREICOMAddInManager AddInManager { [DispId(12544), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(12544), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:CommandLine:String
        /// <summary>
        /// This property contains the command line option string that is passed when the Rose executable is run.
        /// </summary>
        [DispId(12586)]
        String CommandLine { [DispId(12586), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(12586), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion
        #region P:IsInitialized:String
        /// <summary>
        /// This property indicates whether the specified Rose application is fully initialized.
        /// </summary>
        [DispId(12809)]
        Boolean IsInitialized { [DispId(12809), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; [DispId(12809), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [param: In] set; }
        #endregion

        #region M:OpenModel(String):IREICOMModel
        /// <summary>This method opens a Rational Rose model and returns it as a model object.</summary>
        /// <param name="ModelName">Name of the model being opened including path.</param>
        /// <returns>Contains the model being opened.</returns>
        [DispId(210)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMModel OpenModel([MarshalAs(UnmanagedType.BStr)] String ModelName);
        #endregion
        #region M:NewModel:IREICOMModel
        /// <summary>This function creates a new Rational Rose model and returns it as a model object.</summary>
        /// <returns>Contains the newly created Rational Rose model.</returns>
        [DispId(211)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMModel NewModel();
        #endregion
        #region M:Exit
        /// <summary>
        /// This subroutine exits the Rational Rose application.
        /// </summary>
        [DispId(212)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Exit();
        #endregion
        #region M:WriteErrorLog(String)
        /// <summary>This subroutine writes an error message to a log window.</summary>
        /// <param name="Message">Message text to write to the error log window.</param>
        [DispId(213)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void WriteErrorLog([MarshalAs(UnmanagedType.BStr)] String Message);
        #endregion
        #region M:Save(Boolean)
        /// <summary>This subroutine saves the current Rational Rose model.</summary>
        /// <param name="SaveUnits">Indicates whether the current model is comprised of controlled units.</param>
        [DispId(214)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Save(Boolean SaveUnits);
        #endregion
        #region M:SaveAs(String,Boolean)
        /// <summary>
        /// This subroutine names and saves the current Rational Rose model.
        /// </summary>
        /// <param name="FileName">Name of the model being saved.</param>
        /// <param name="SaveUnits">Indicates whether the current model is comprised of controlled units.</param>
        [DispId(215)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SaveAs([MarshalAs(UnmanagedType.BStr)] String FileName, Boolean SaveUnits);
        #endregion
        #region M:CompileScriptFile(String,String,Boolean)
        /// <summary>This subroutine compiles the script contained in the specified file.</summary>
        /// <param name="FileName">Name of the file that contains the script being compiled; include the .ebs file extension.</param>
        /// <param name="BinaryName">Name of the binary file in which to save the compiled script; use the .ebx file extension.</param>
        /// <param name="Debug">Set to True to embed the script’s source code in the compiled file. This allows the script debugger to display the source code when it enters external modules.</param>
        [DispId(218)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CompileScriptFile([MarshalAs(UnmanagedType.BStr)] String FileName, [MarshalAs(UnmanagedType.BStr)] String BinaryName, Boolean Debug);
        #endregion

        [DispId(221)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SelectObjectInBrowser([MarshalAs(UnmanagedType.Interface)] IREICOMObject theRoseObject);

        #region M:OpenModelAsTemplate(String):IREICOMModel
        /// <summary>This function retrieves an existing model to be used as a template from which to create a new model.</summary>
        /// <param name="FileName">Name of the file that contains the model being returned.</param>
        /// <returns>Returns the model contained in the specified file.</returns>
        [DispId(223)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMModel OpenModelAsTemplate([MarshalAs(UnmanagedType.BStr)] String FileName);
        #endregion

        [DispId(225)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void OpenScript([MarshalAs(UnmanagedType.BStr)] String FileName);

        [DispId(226)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NewScript();

        #region M:GetLicensedApplication(String):IREICOMApplication
        /// <summary>This function retrieves an instance of the licensed application given the application’s licensing key.</summary>
        /// <param name="Key">Licensing key for the application being retrieved.</param>
        /// <returns>Returns the instance of the licensed application.</returns>
        [DispId(235)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMApplication GetLicensedApplication([MarshalAs(UnmanagedType.BStr)] String Key);
        #endregion
        #region M:ExecuteScript(String)
        /// <summary>This subroutine executes the source or compiled image of a script contained the specified file. You can specify the file without its extension. If the script is currently open in the script editor, Rational Rose will execute the open script. Otherwise, Rational Rose will search for the source script (.ebs) and execute it, if found. If not found, Rational Rose will search for and execute the compiled script (.ebx file).</summary>
        /// <param name="FileName">Name of the file that contains the script to execute.</param>
        [DispId(236)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ExecuteScript([MarshalAs(UnmanagedType.BStr)] String FileName);
        #endregion
        #region M:OpenURL(String):Boolean
        /// <summary>This function opens a URL, given the URL string.</summary>
        /// <param name="URL">URL that contains the external document.</param>
        /// <returns>Returns a value of true when the specified URL is successfully opened.</returns>
        [DispId(12587)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean OpenURL([MarshalAs(UnmanagedType.BStr)] String URL);
        #endregion
        #region M:OpenExternalDocument(String):Boolean
        /// <summary>This function opens an external document, given a fully qualified name of the file that contains the document.</summary>
        /// <param name="FileName">Fully qualified file name or the URL that contains the external document.</param>
        /// <returns>Returns a value of true when the specified document is successfully opened.</returns>
        [DispId(12588)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean OpenExternalDocument([MarshalAs(UnmanagedType.BStr)] String FileName);
        #endregion
        #region M:GetProfileString(String,String,String):String
        /// <summary>This function retrieves a profile string entry in the Rose.ini file, given a section, entry, and default value.</summary>
        /// <param name="Section">Name of the Rose.ini file section from which the profile string is being retrieved. For example: [PathMap].</param>
        /// <param name="Entry">The name of the Rose.ini file entry whose profile string is being retrieved  For example: $SCRIPT_PATH.</param>
        /// <param name="Default">Default value of the entry being retrieved. In the [PathMap] $SCRIPT_PATH example, the default value is the path to the folder that contains the scripts being called by the application.</param>
        /// <returns>Returns the profile string that corresponds to the given section, entry, and default value.</returns>
        [DispId(12589)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.BStr)]
        String GetProfileString([MarshalAs(UnmanagedType.BStr)] String Section, [MarshalAs(UnmanagedType.BStr)] String Entry, [MarshalAs(UnmanagedType.BStr)] String Default);
        #endregion
        #region M:WriteProfileString(String,String,String):Boolean
        /// <summary>This function retrieves a profile string entry in the Rose.ini file, given a section, entry, and default value.</summary>
        /// <param name="Section">Name of the Rose.ini file section to which the profile string is being written. For example: [PathMap].</param>
        /// <param name="Entry">The name of the Rose.ini file entry whose profile string is being written. For example: $SCRIPT_PATH.</param>
        /// <param name="Value">Value of the entry being written. In the [PathMap] $SCRIPT_PATH example, the value is the actual path to the folder that contains the scripts being called by the application.</param>
        /// <returns>Returns a value of true when the specified ProfileString is successfully written to the Rose.ini file.</returns>
        [DispId(12590)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean WriteProfileString([MarshalAs(UnmanagedType.BStr)] String Section, [MarshalAs(UnmanagedType.BStr)] String Entry, [MarshalAs(UnmanagedType.BStr)] String Value);
        #endregion

        [DispId(12679)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean UpdateBrowserOverlayImage([MarshalAs(UnmanagedType.Interface)] IREICOMItem theItem);

        [DispId(12688)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean UpdateBrowserDocOverlayImage([MarshalAs(UnmanagedType.Interface)] IREICOMExternalDocument theDocument);

        #region M:OpenRoseModel(String,Boolean):IREICOMModel
        /// <summary>This method opens a Rational Rose model with or without prompting the user whether or not to open all of its subunits.</summary>
        /// <param name="ModelPath">Path and filename of an existing Rational Rose model to be loaded.</param>
        /// <param name="PromptSubUnits">
        /// Set this argument to TRUE to load the Model and, if it has subunits, display the "Load Subunits" prompt. This gives the user a choice as to whether or not to load the subunits.
        /// Set this argument to FALSE to load the model and all of its subunits without prompting the user.
        /// </param>
        /// <returns>Returns the model contained in the specified path and file.</returns>
        [DispId(12697)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMModel OpenRoseModel([MarshalAs(UnmanagedType.BStr)] String ModelPath, Boolean PromptSubUnits);
        #endregion
        #region M:GetRoseIniPath:String
        /// <summary>This method retrieves the path to the Rose.ini file for the current user.</summary>
        /// <returns>Returns a string containing the path to and filename of the Rose.ini file for the current user.</returns>
        [DispId(12698)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.BStr)]
        String GetRoseIniPath();
        #endregion
        #region M:SaveModel(Boolean):Int32
        /// <summary>This method saves the currently open model and returns a value to indicate whether the save was successful.</summary>
        /// <param name="SaveUnits">Set to Yes to include the model’s controlled units in the save.</param>
        /// <returns>Returns a value of 0 if the model was saved with no errors.</returns>
        [DispId(12856)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Int32 SaveModel(Boolean SaveUnits);
        #endregion
        #region M:EnableUserEditOfItem(IREICOMItem):Boolean
        /// <summary>
        /// When you add a model element or relationship to a model through the user interface, the item name defaults to a placeholder and is immediately placed into edit mode so you can start typing a desired name. However, when you add a RoseItem object to a model through a script or add-in, the browser does not display the item name in edit mode. This method allows your script or add-in to place a RoseItem object name in the browser into edit mode. This is helpful if your script or add-in interacts with users in real-time and you want to prompt your users to edit the item name.<br/>
        /// Note: Rose Script syntax is slightly different from Rose Automation syntax because the Rose Script implementation of this method needs information about the inheritance hierarchy. Rose Script is expecting only RoseItem objects, not children objects. Therefore, for children objects, such as Class objects, you must use the TypeCast method in your Rose Script syntax of EnableUserEditOfDiagram to convert child objects, such as Class objects, to RoseItem objects.
        /// </summary>
        /// <param name="Item">RoseItem object whose name is to be made editable.</param>
        /// <returns>
        /// Returns TRUE if the RoseItem name is in edit mode in the browser.
        /// Returns FALSE if the RoseItem name cannot be placed into edit mode in the browser. For example, if the RoseItem does not exist, this method returns FALSE.
        /// </returns>
        [DispId(12859)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean EnableUserEditOfItem([MarshalAs(UnmanagedType.Interface)] IREICOMItem Item);
        #endregion
        #region M:EnableUserEditOfDiagram(IREICOMDiagram):Boolean
        /// <summary>
        /// When you add a diagram to a model through the user interface, the diagram name defaults to a placeholder and is immediately placed into edit mode so you can start typing a desired name. However, when you add a Diagram object to a model through a script or add-in, the browser does not display the diagram name in edit mode. This method allows your script or add-in to place diagram names in the browser into edit mode. This is helpful if your script or add-in interacts with users in real-time and you want to prompt your users to edit the diagram name.<br/>
        /// Note: Rose Script syntax is slightly different from Rose Automation syntax because the Rose Script implementation of this method needs information about the inheritance hierarchy. Rose Script is expecting only Diagram objects, not children objects. Therefore, for children objects, such as ClassDiagram objects, you must use the TypeCast method in your Rose Script syntax of EnableUserEditOfDiagram to convert child objects, such as ClassDiagram objects, to Diagram objects.
        /// </summary>
        /// <param name="Diagram">RoseDiagram object whose name is to be made editable.</param>
        /// <returns>Returns TRUE if the RoseDiagram name is in edit mode in the browser.
        /// Returns FALSE if the RoseDiagram name cannot be placed into edit mode in the browser. For example, if the RoseDiagram does not exist, this method returns FALSE.
        /// </returns>
        [DispId(12860)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean EnableUserEditOfDiagram([MarshalAs(UnmanagedType.Interface)] IREICOMDiagram Diagram);
        #endregion

        [DispId(12861)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean EditorOpenFile([MarshalAs(UnmanagedType.BStr)] String FileName, [MarshalAs(UnmanagedType.BStr)] String fileDomain);

        [DispId(12862)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.BStr)]
        String EditorDomainOf([MarshalAs(UnmanagedType.BStr)] String FileName);

        [DispId(12863)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IREICOMStringCollection EditorGetOpenFiles();

        [DispId(12864)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean EditorIsDirty([MarshalAs(UnmanagedType.BStr)] String FileName);

        [DispId(12865)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean EditorIsVisible([MarshalAs(UnmanagedType.BStr)] String FileName);

        [DispId(12866)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean EditorRefreshFile([MarshalAs(UnmanagedType.BStr)] String FileName);

        [DispId(12867)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean EditorDisplayFile([MarshalAs(UnmanagedType.BStr)] String FileName);

        [DispId(12868)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean LogCreateTab([MarshalAs(UnmanagedType.BStr)] String tabName, [MarshalAs(UnmanagedType.BStr)] String domain);

        [DispId(12869)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean LogCloseTab([MarshalAs(UnmanagedType.BStr)] String tabName, [MarshalAs(UnmanagedType.BStr)] String domain);

        [DispId(12870)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean LogClearTab([MarshalAs(UnmanagedType.BStr)] String tabName, [MarshalAs(UnmanagedType.BStr)] String domain);

        [DispId(12871)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean LogSetActiveTab([MarshalAs(UnmanagedType.BStr)] String tabName, [MarshalAs(UnmanagedType.BStr)] String domain);

        [DispId(12872)]
        [MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Boolean LogWriteTab([MarshalAs(UnmanagedType.BStr)] String tabName, [MarshalAs(UnmanagedType.BStr)] String domain, [MarshalAs(UnmanagedType.BStr)] String Text);
        }
    }
