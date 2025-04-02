using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal abstract class EPackageableElement : ENamedElement,PackageableElement
        {
        public TemplateParameter OwningTemplateParameter { get;set; }
        public TemplateParameter TemplateParameter { get;set; }

        protected EPackageableElement()
            {
            }

        public Boolean isCompatibleWith(ParameterableElement p)
            {
            throw new NotImplementedException();
            }

        public Boolean isTemplateParameter()
            {
            throw new NotImplementedException();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"PackageableElement"
                : $"PackageableElement{{{Name}}}";
            }
        #endregion
        }
    }