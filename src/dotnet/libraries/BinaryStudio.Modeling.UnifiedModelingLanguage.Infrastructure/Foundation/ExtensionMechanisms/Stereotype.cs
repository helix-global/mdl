using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Stereotype : GeneralizableElement
        {
        String baseClass { get; }
        TagDefinition[] definedTag { get; }
        ModelElement[] extendedElement { get; }
        Geometry icon { get; }
        Constraint[] stereotypeConstraint { get; }
        }
    }
