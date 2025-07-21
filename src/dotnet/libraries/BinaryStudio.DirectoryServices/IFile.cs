using System;
using System.IO;

namespace BinaryStudio.DirectoryServices
    {
    public interface IFile : IFileOrFolder
        {
        String FileName { get; }
        String FullName { get; }

        #region M:OpenRead:Stream
        /// <summary>Opens this file service for reading.</summary>
        /// <returns>A read-only <see cref="T:System.IO.Stream"/> for this file service content.</returns>
        Stream OpenRead();
        #endregion
        }
    }