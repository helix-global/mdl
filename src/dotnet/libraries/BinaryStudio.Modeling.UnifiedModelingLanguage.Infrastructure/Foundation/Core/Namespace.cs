using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    /// <summary>
    /// <p>A namespace is a part of a model that contains a set of ModelElements each of whose names designates a unique element within the namespace.</p>
    /// <p>In the metamodel, a Namespace is a ModelElement that can own other ModelElements, like Associations and Classifiers. The name of each owned ModelElement must be unique within the Namespace. Moreover, each contained ModelElement is owned by at most one Namespace. The concrete subclasses of Namespace have additional constraints on which kind of elements may be contained. Namespace is an abstract metaclass.</p>
    /// <p>Note that explicit parts of a model element, such as the features of a Classifier, are not modeled as owned elements in a namespace. A namespace is used for unstructured contents such as the contents of a package or a class declared inside the scope of another class.</p>
    /// </summary>
    public interface Namespace : ModelElement
        {
        /// <summary>
        /// (association class ElementOwnership) A set of ModelElements owned by the Namespace. Its visibility attribute states whether the element is visible outside the namespace.
        /// </summary>
        List<ElementOwnership> ownedElement { get; }
        }
    }
