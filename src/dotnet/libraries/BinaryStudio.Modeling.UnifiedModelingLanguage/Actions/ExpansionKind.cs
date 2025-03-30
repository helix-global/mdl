using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="ExpansionKind"/> is an enumeration type used to specify how an <see cref="ExpansionRegion"/> executes its contents.
    /// </summary>
    /// xmi:id="ExpansionKind"
    public enum ExpansionKind
        {
        /// <summary>
        /// The content of the <see cref="ExpansionRegion"/> is executed concurrently for the elements of the input collections.
        /// </summary>
        /// xmi:id="ExpansionKind-parallel"
        Parallel,
        /// <summary>
        /// The content of the <see cref="ExpansionRegion"/> is executed iteratively for the elements of the input collections, in the order of the input elements, if the collections are ordered.
        /// </summary>
        /// xmi:id="ExpansionKind-iterative"
        Iterative,
        /// <summary>
        /// A stream of input collection elements flows into a single execution of the content of the <see cref="ExpansionRegion"/>, in the order of the collection elements if the input collections are ordered.
        /// </summary>
        /// xmi:id="ExpansionKind-stream"
        Stream
        }
    }
