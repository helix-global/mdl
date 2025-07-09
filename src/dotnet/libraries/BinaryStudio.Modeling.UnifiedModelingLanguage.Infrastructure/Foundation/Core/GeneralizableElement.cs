using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    /// <summary>
    /// <p>A generalizable element is a model element that may participate in a generalization relationship.</p>
    /// <p>In the metamodel, a GeneralizableElement can be a generalization of other GeneralizableElements (i.e., all Features defined in and all ModelElements contained in the ancestors are also present in the GeneralizableElement). GeneralizableElement is an abstract metaclass.</p>
    /// </summary>
    public interface GeneralizableElement : ModelElement
        {
        /// <summary>
        /// Specifies whether the GeneralizableElement is a root GeneralizableElement with no ancestors. True indicates that it may not have ancestors, false indicates that it may have ancestors (whether or not it actually has any ancestors at the moment).
        /// </summary>
        Boolean isRoot { get;set; }
        /// <summary>
        /// Specifies whether the GeneralizableElement is a GeneralizableElement with no descendents. True indicates that it may not have descendents, false indicates that it may have descendents (whether or not it actually has any descendents at the moment).
        /// </summary>
        Boolean isLeaf { get;set; }
        /// <summary>
        /// Specifies whether the GeneralizableElement may not have a direct instance. True indicates that an instance of the GeneralizableElement must be an instance of a child of the GeneralizableElement. False indicates that there may be an instance of the GeneralizableElement that is not an instance of a child. An abstract GeneralizableElement is not instantiable since it does not contain all necessary information. That is, it may not have a direct instance. It may have an indirect instance, and a model at a higher level of abstraction may include instances of an abstract type, with the understanding that in a fully expanded concrete snapshot, such instances would have concrete types that are descendants of the abstract types.
        /// </summary>
        Boolean isAbstract { get;set; }
        /// <summary>
        /// Designates a Generalization whose parent GeneralizableElement is the immediate ancestor of the current GeneralizableElement.
        /// </summary>
        IList<Generalization> generalization { get; }
        /// <summary>
        /// Designates a Generalization whose child GeneralizableElement is the immediate descendent of the current GeneralizableElement.
        /// </summary>
        IList<Generalization> specialization { get; }
        }
    }
