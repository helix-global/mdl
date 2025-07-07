using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface AssociationEnd : ModelElement
        {
        AggregationKind aggregation { get; }
        Association association { get; }
        AssociationEndRole[] associationEndRole { get; }
        ChangeableKind changeability { get; }
        Boolean isNavigable { get; }
        LinkEnd[] linkEnd { get; }
        Multiplicity multiplicity { get; }
        OrderingKind ordering { get; }
        Classifier participant { get; }
        Attribute[] qualifier { get; }
        Classifier[] specification { get; }
        ScopeKind targetScope { get; }
        }
    }
