using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BinaryStudio.DirectoryServices
    {
    internal class LocalFolder : IFolder
        {
        public String Folder { get; }
        public LocalFolder(String folder)
            {
            if (folder == null) { throw new ArgumentNullException(nameof(folder)); }
            Folder = folder;
            }

        #region M:EnumerateFileOrFolderEntries(String):IEnumerable<IFileOrFolder>
        public IEnumerable<IFileOrFolder> EnumerateFileOrFolderEntries(String searchPath) {
            if (searchPath == null) { throw new ArgumentNullException(nameof(searchPath)); }
            var searchPathParts = searchPath.Split(new []{"/","\\"},StringSplitOptions.None);
            var fullPath = Path.Combine(Folder,searchPathParts[0]);
            if (Directory.Exists(fullPath)) {
                foreach (var i in (new LocalFolder(fullPath)).EnumerateFileOrFolderEntries(String.Join("\\",searchPathParts.Skip(1)))) {
                    yield return i;
                    }
                }
            else if (File.Exists(fullPath)) {
                var file = new LocalFile(fullPath);
                if (searchPathParts.Length == 1) {
                    yield return file;
                    }
                else if (file.GetService(typeof(IFolder)) is IFolder folder) {
                    foreach (var i in folder.EnumerateFileOrFolderEntries(String.Join("\\",searchPathParts.Skip(1)))) {
                        yield return i;
                        }
                    }
                }
            else
                {
                throw new FileNotFoundException();
                }
            }
        #endregion
        //#region M:EnumerateFileOrFolderEntries(String):IEnumerable<IFileOrFolder>
        //public IEnumerable<IFileOrFolder> EnumerateFileOrFolderEntries(String searchPattern) {
        //    return EnumerateFileOrFolderEntries(searchPattern,SearchOption.TopDirectoryOnly);
        //    }
        //#endregion
        //#region M:GetFilesI(String,String):IEnumerable<String>
        //private static IEnumerable<IFileOrFolder> GetFilesI(String Folder,String SearchPattern,SearchOption searchOption) {
        //    var folders = new List<String>();
        //    try
        //        {
        //        foreach (var folder in Directory.EnumerateDirectories(Folder,"*.*",SearchOption.TopDirectoryOnly)) {
        //            folders.Add(folder);
        //            }
        //        }
        //    catch (UnauthorizedAccessException)
        //        {
        //        }
        //    catch
        //        {
        //        throw;
        //        }
        //    foreach (var folder in folders) { yield return new LocalFolder(folder); }
        //    if (searchOption == SearchOption.AllDirectories) {
        //        foreach (var folder in folders) {
        //            foreach (var i in GetFilesI(folder,SearchPattern,searchOption)) {
        //                yield return i;
        //                }
        //            }
        //        }
        //    foreach (var file in Directory.EnumerateFiles(Folder, SearchPattern, SearchOption.TopDirectoryOnly).OrderBy(i => i)) {
        //        yield return new LocalFile(file);
        //        }
        //    }
        //#endregion

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return Folder;
            }
        #endregion
        #region M:GetService(Type):Object
        /// <summary>Gets the service object of the specified type.</summary>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns>A service object of type <paramref name="serviceType" />.
        /// -or- <see langword="null" /> if there is no service object of type <paramref name="serviceType" />.</returns>
        public Object GetService(Type serviceType) {
            if (serviceType == typeof(IFolder)) { return this; }
            return null;
            }
        #endregion

        public IEnumerable<IFile> GetFiles() {
            yield break;
            //foreach (var e in EnumerateFileOrFolderEntries("*.*",SearchOption.TopDirectoryOnly)) {
            //    if (e is IFile r) {
            //        yield return r;
            //        }
            //    }
            }
        }
    }