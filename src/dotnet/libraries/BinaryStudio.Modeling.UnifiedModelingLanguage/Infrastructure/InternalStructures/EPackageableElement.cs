using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EPackageableElement : ENamedElement,PackageableElement
        {
        public TemplateParameter OwningTemplateParameter { get; set; }
        public TemplateParameter TemplateParameter { get; set; }
        public Boolean isCompatibleWith(ParameterableElement p)
            {
            throw new NotImplementedException();
            }

        public Boolean isTemplateParameter()
            {
            throw new NotImplementedException();
            }
        }
    }