using System;
using System.Collections.Generic;
using System.IO;

namespace BinaryStudio.DirectoryServices
    {
    public interface IFolder : IFileOrFolder
        {
        /// <summary>Returns the file services (including their paths) in the directory service.</summary>
        /// <returns>A list of file services.</returns>
        IEnumerable<IFile> GetFiles();
        IEnumerable<IFileOrFolder> EnumerateFileOrFolderEntries(String searchPath);
        }
    }