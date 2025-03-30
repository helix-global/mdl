using System;
using System.IO;

namespace pre
    {
    public class ModelWriter
        {
        #region M:WriteTo(Model,String)
        public void WriteTo(Model source,String target) {
            WriteTo(source.NestedPackages[0],target);
            }
        #endregion
        #region M:WriteTo(Package,String)
        private void WriteTo(Package source,String target) {
            if (!Directory.Exists(target)) { Directory.CreateDirectory(target); }
            foreach (var c in source.NestedClasses) {
                var classFileName = Path.Combine(target,$"{c.Name}.cs");
                using (var stream = File.Exists(classFileName)
                    ? new FileStream(classFileName,FileMode.Truncate)
                    : new FileStream(classFileName,FileMode.CreateNew))
                    {
                    c.WriteCSharp(stream);
                    }
                }
            foreach (var e in source.NestedEnumeration) {
                var enumFileName = Path.Combine(target,$"{e.Name}.cs");
                using (var stream = File.Exists(enumFileName)
                    ? new FileStream(enumFileName,FileMode.Truncate)
                    : new FileStream(enumFileName,FileMode.CreateNew))
                    {
                    e.WriteCSharp(stream);
                    }
                }
            foreach (var package in source.NestedPackages) {
                var folder = Path.Combine(target,package.Name);
                WriteTo(package,folder);
                }
            }
        #endregion
        }
    }