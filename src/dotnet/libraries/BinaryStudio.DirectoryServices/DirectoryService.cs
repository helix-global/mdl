using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Archives.Zip;

namespace BinaryStudio.DirectoryServices
    {
    public class DirectoryService
        {
        #region M:GetService<T>(Object,{out}T):Boolean
        public static Boolean GetService<T>(Object source,out T o) {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }
            if (source.GetType() == typeof(T)) {
                o = (T)source;
                return true;
                }
            #region {IFileService}
            if (typeof(T) == typeof(IFile)) {
                if (source is Uri URI) {
                    switch (URI.Scheme) {
                        case "file" :
                            {
                            if (GetFile(URI.LocalPath,out var r)) {
                                o = (T)r;
                                return true;
                                }
                            }
                            break;
                        throw new NotSupportedException();
                        }
                    }
                }
            #endregion
            o = default;
            return false;
            }
        #endregion
        private static Boolean GetFile(String fullpath,out IFile o) {
            o = default;
            if (File.Exists(fullpath)) {
                o = new LocalFile(fullpath);
                return true;
                }
            var parts = fullpath.Split(new []{"/","\\"},StringSplitOptions.None);
            if (parts.Length > 0) {
                if (parts[0].EndsWith(":")) {
                    var folder = new LocalFolder($"{parts[0]}\\");
                    var path = String.Join("\\",parts.Skip(1));
                    o = folder.EnumerateFileOrFolderEntries(path).OfType<IFile>().FirstOrDefault();
                    return o != null;

                    //for (var i = 1;i < parts.Length;i++) {
                    //    var probe = Path.Combine(folder,parts[i]);
                    //    if (Directory.Exists(probe)) {
                    //        folder = probe;
                    //        continue;
                    //        }
                    //    if (File.Exists(probe)) {
                    //        var e = Path.GetExtension(parts[i]);
                    //        IDirectoryService S = null;
                    //        switch (e) {
                    //            case ".rar": { S = new ArchiveService(probe, RarArchive.Open(File.OpenRead(probe)));      } break;
                    //            case ".jar": { S = new ArchiveService(probe, ZipArchive.Open(File.OpenRead(probe)));      } break;
                    //            case ".zip": { S = new ArchiveService(probe, ZipArchive.Open(File.OpenRead(probe)));      } break;
                    //            case ".7z" : { S = new ArchiveService(probe, SevenZipArchive.Open(File.OpenRead(probe))); } break;
                    //            default: throw new NotSupportedException();
                    //            }
                    //        throw new NotSupportedException();
                    //        }
                    //    }
                    }
                }
            return false;
            }

        //public static IEnumerable<IFileService> GetFiles(IDirectoryService Service,String SearchPattern) {
        //    if (Service == null) { yield break; }
        //    if (SearchPattern == null) { throw new ArgumentNullException(nameof(SearchPattern)); }
        //    foreach (var FileService in GetFiles(Service,SearchPattern,new String[0])) {
        //        yield return FileService;
        //        }
        //    }

        //public static IEnumerable<IFileService> GetFiles(IDirectoryService Service,String SearchPattern,IList<String> ContainerPatterns) {
        //    if (Service == null) { yield break; }
        //    if (SearchPattern == null) { throw new ArgumentNullException(nameof(SearchPattern)); }
        //    ContainerPatterns = ContainerPatterns ?? EmptyArray<String>.Value;
        //    foreach (var FileService in Service.GetFiles()) {
        //        if (PathUtils.IsMatch(SearchPattern,FileService.FullName)) { yield return FileService; }
        //        if ((ContainerPatterns.Count > 0) && PathUtils.IsMatch(ContainerPatterns,FileService.FullName)) {
        //            var service = GetService<IDirectoryService>(FileService);
        //            if (service != null) {
        //                foreach (var NestedFileService in GetFiles(service,SearchPattern,ContainerPatterns)) {
        //                    yield return NestedFileService;
        //                    }
        //                }
        //            }
        //        }
        //    }
        }
    }
