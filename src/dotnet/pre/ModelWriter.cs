using System;
using System.IO;
using System.Linq;

namespace pre
    {
    internal class ModelWriter
        {
        #region M:WriteTo(Model,String)
        public void WriteTo(Model source,String target) {
            WriteTo(source.OwnedPackage.FirstOrDefault().Value,target);
            }
        #endregion
        #region M:WriteTo(Package,String)
        private void WriteTo(Package source,String target) {
            if (!Directory.Exists(target)) { Directory.CreateDirectory(target); }
            foreach (var c in source.OwnedClass) {
                var classFileName = Path.Combine(target,$"{c.Value.Name}.cs");
                using (var stream = File.Exists(classFileName)
                    ? new FileStream(classFileName,FileMode.Truncate)
                    : new FileStream(classFileName,FileMode.CreateNew))
                    {
                    c.Value.WriteCSharp(stream);
                    }
                }
            foreach (var e in source.OwnedEnumeration) {
                var enumFileName = Path.Combine(target,$"{e.Value.Name}.cs");
                using (var stream = File.Exists(enumFileName)
                    ? new FileStream(enumFileName,FileMode.Truncate)
                    : new FileStream(enumFileName,FileMode.CreateNew))
                    {
                    e.Value.WriteCSharp(stream);
                    }
                }
            foreach (var package in source.OwnedPackage) {
                var folder = Path.Combine(target,package.Value.Name);
                WriteTo(package.Value,folder);
                }
            }
        #endregion
        }
    }