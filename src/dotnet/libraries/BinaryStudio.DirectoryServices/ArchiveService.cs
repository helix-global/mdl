using System;
using System.Collections.Generic;
using System.IO;
using SharpCompress.Archives;

namespace BinaryStudio.DirectoryServices
    {
    internal class ArchiveService : IFolder
        {
        public IArchive Archive { get; }
        public String FileName { get; }

        public ArchiveService(String filename, IArchive archive)
            {
            FileName = filename;
            Archive = archive;
            }

        public IEnumerable<IFile> GetFiles() {
            foreach (var entry in Archive.Entries) {
                if (!entry.IsDirectory) {
                    yield return new ArchiveEntryService(FileName, entry);
                    }
                }
            }

        #region M:EnumerateFileOrFolderEntries(String):IEnumerable<IFileOrFolder>
        public IEnumerable<IFileOrFolder> EnumerateFileOrFolderEntries(String searchPath) {
            if (searchPath == null) { throw new ArgumentNullException(nameof(searchPath)); }
            if (m_entries == null) {
                m_entries = new Dictionary<String,IFile>();
                foreach (var entry in Archive.Entries) {
                    if (!entry.IsDirectory) {
                        m_entries[entry.Key.Replace("/","\\")] = new ArchiveEntryService(FileName,entry);
                        }
                    }
                }
            if (m_entries.TryGetValue(searchPath,out var e)) {
                yield return e;
                }
            var searchPathParts = searchPath.Split(new []{"/","\\"},StringSplitOptions.None);
            yield break;
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
        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return FileName;
            }
        #endregion

        private IDictionary<String,IFile> m_entries;
        }
    }