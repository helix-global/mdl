using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EPackage : ENamespace,Package
        {
        public TemplateSignature OwnedTemplateSignature { get;set; }
        public IList<TemplateBinding> TemplateBinding { get; }
        public Boolean isTemplate()
            {
            throw new NotImplementedException();
            }

        public ParameterableElement[] parameterableElements()
            {
            throw new NotImplementedException();
            }

        public TemplateParameter OwningTemplateParameter { get;set; }
        public TemplateParameter TemplateParameter { get;set; }
        public Boolean isCompatibleWith(ParameterableElement p)
            {
            throw new NotImplementedException();
            }

        public Boolean isTemplateParameter()
            {
            throw new NotImplementedException();
            }

        public IList<Package> NestedPackage { get; }
        public Package NestingPackage { get;set; }
        public IList<Stereotype> OwnedStereotype { get; }
        public IList<Type> OwnedType { get; }
        public IList<PackageableElement> PackagedElement { get; }
        public IList<PackageMerge> PackageMerge { get; }
        public IList<ProfileApplication> ProfileApplication { get; }
        public String URI { get; set; }
        public Stereotype[] allApplicableStereotypes()
            {
            throw new NotImplementedException();
            }

        public Profile containingProfile()
            {
            throw new NotImplementedException();
            }

        public Boolean makesVisible(NamedElement el)
            {
            throw new NotImplementedException();
            }

        public Package[] nestedPackage()
            {
            throw new NotImplementedException();
            }

        public Stereotype[] ownedStereotype()
            {
            throw new NotImplementedException();
            }

        public Type[] ownedType()
            {
            throw new NotImplementedException();
            }

        public PackageableElement[] visibleMembers()
            {
            throw new NotImplementedException();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"Package"
                : $"Package{{{Name}}}";

            }
        #endregion
        }
    }