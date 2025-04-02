using System;
using BinaryStudio.Modeling.MetadataInterchange;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EPackageImport : EDirectedRelationship,PackageImport
        {
        [IsIDREF] public Package ImportedPackage { get;set; }
        public Namespace ImportingNamespace { get;set; }
        public VisibilityKind Visibility { get;set; }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return (ImportedPackage != null)
                ? $"PackageImport{{{ImportedPackage.Name}}}"
                : $"PackageImport";
            }
        #endregion
        }
    }