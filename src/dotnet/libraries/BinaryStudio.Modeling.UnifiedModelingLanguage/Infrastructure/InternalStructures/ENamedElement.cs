using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal abstract class ENamedElement : EElement,NamedElement
        {
        public IList<Dependency> ClientDependency { get; }
        public String Name { get;set; }
        public StringExpression NameExpression { get;set; }
        public Namespace Namespace { get; }
        public String QualifiedName { get; }
        public VisibilityKind? Visibility { get;set; }

        protected ENamedElement()
            {
            }

        public Namespace[] allNamespaces()
            {
            throw new NotImplementedException();
            }

        public Package[] allOwningPackages()
            {
            throw new NotImplementedException();
            }

        public Dependency[] clientDependency()
            {
            throw new NotImplementedException();
            }

        public Boolean isDistinguishableFrom(NamedElement n, Namespace ns)
            {
            throw new NotImplementedException();
            }

        public String qualifiedName()
            {
            throw new NotImplementedException();
            }

        public String separator()
            {
            throw new NotImplementedException();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"NamedElement"
                : $"NamedElement{{{Name}}}";
            }
        #endregion
        }
    }