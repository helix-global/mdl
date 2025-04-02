using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal abstract class ENamespace : ENamedElement,Namespace
        {
        public IList<ElementImport> ElementImport { get; }
        public IList<PackageableElement> ImportedMember { get; }
        public IList<NamedElement> Member { get; }
        public IList<NamedElement> OwnedMember { get; }
        public IList<Constraint> OwnedRule { get; }
        public IList<PackageImport> PackageImport { get; }

        protected ENamespace()
            {
            PackageImport = new List<PackageImport>();
            OwnedRule = new List<Constraint>();
            }

        public PackageableElement[] excludeCollisions(PackageableElement[] imps)
            {
            throw new NotImplementedException();
            }

        public String[] getNamesOfMember(NamedElement element)
            {
            throw new NotImplementedException();
            }

        public PackageableElement[] importedMember()
            {
            throw new NotImplementedException();
            }

        public PackageableElement[] importMembers(PackageableElement[] imps)
            {
            throw new NotImplementedException();
            }

        public Boolean membersAreDistinguishable()
            {
            throw new NotImplementedException();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"Namespace"
                : $"Namespace{{{Name}}}";
            }
        #endregion
        }
    }