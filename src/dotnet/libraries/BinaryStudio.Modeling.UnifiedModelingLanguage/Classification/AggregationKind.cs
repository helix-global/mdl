using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="AggregationKind"/> is an <see cref="Enumeration"/> for specifying the kind of aggregation of a <see cref="Property"/>.
    /// </summary>
    /// xmi:id="AggregationKind"
    public enum AggregationKind
        {
        /// <summary>
        /// Indicates that the <see cref="Property"/> has no aggregation.
        /// </summary>
        /// xmi:id="AggregationKind-none"
        None,
        /// <summary>
        /// Indicates that the <see cref="Property"/> has shared aggregation.
        /// </summary>
        /// xmi:id="AggregationKind-shared"
        Shared,
        /// <summary>
        /// Indicates that the <see cref="Property"/> is aggregated compositely, i.e., the composite object has responsibility for the existence and storage of the composed objects (parts).
        /// </summary>
        /// xmi:id="AggregationKind-composite"
        Composite
        }
    }
