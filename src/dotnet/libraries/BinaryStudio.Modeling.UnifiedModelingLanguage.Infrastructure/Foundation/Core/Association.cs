using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Association : GeneralizableElement,Relationship
        {
        AssociationRole[] associationRole { get; }
        [Multiplicity("2..*")] AssociationEnd[] connection { get; }
        Link[] link { get; }
        }
    }
