using System;
using System.IO;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Archives.Zip;

namespace BinaryStudio.DirectoryServices
    {
    internal class LocalFile : IFile
        {
        public String FileName { get; }
        public String FullName { get; }

        public LocalFile(String filename) {
            FullName = filename;
            FileName = Path.GetFileName(filename);
            }

        public Stream OpenRead()
            {
            return File.OpenRead(FullName);
            }

        #region M:GetService(Type):Object
        /// <summary>Gets the service object of the specified type.</summary>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns>A service object of type <paramref name="serviceType" />.
        /// -or- <see langword="null" /> if there is no service object of type <paramref name="serviceType" />.</returns>
        public Object GetService(Type serviceType) {
            if (serviceType == typeof(IFile)) { return this; }
            if (serviceType == typeof(IFolder)) {
                switch (Path.GetExtension(FileName)) {
                    case ".rar": { return new ArchiveService(FullName,RarArchive.Open(OpenRead()));      }
                    case ".jar": { return new ArchiveService(FullName,ZipArchive.Open(OpenRead()));      }
                    case ".zip": { return new ArchiveService(FullName,ZipArchive.Open(OpenRead()));      }
                    case ".7z" : { return new ArchiveService(FullName,SevenZipArchive.Open(OpenRead())); }
                    }
                }
            return null;
            }
        #endregion
        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return FullName;
            }
        #endregion
        }
    }