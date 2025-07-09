using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    /// <summary>
    /// <p>A model element is an element that is an abstraction drawn from the system being modeled. Contrast with view element, which is an element whose purpose is to provide a presentation of information for human comprehension.</p>
    /// <p>In the metamodel, a ModelElement is a named entity in a Model. It is the base for all modeling metaclasses in the UML (even though it is not displayed explicitly as such on diagrams for ElementOwnership, ElementResidence, ElementImport, TemplateParameter, TemplateArgument, and Argument). All other modeling metaclasses are either direct or indirect subclasses of ModelElement.</p>
    /// <p>Each ModelElement can be regarded as a template. A template has a set of templateParameters that denotes which of the parts of a ModelElement are the template parameters. A ModelElement is a template when there is at least one template parameter. If it is not a template, a ModelElement cannot have template parameters. However, such embedded parameters are not usually complete and need not satisfy well-formedness rules. It is the arguments supplied when the template is instantiated that must be well formed.</p>
    /// <p>Partially instantiated templates are allowed. This is the case when there are arguments provided for some, but not all templateParameters. A partially instantiated template is still a template, since it still has parameters.</p>
    /// </summary>
    public partial interface ModelElement : Element
        {
        IList<StateMachine> behavior { get; }
        /// <summary>
        /// Inverse of client. Designates a set of Dependency in which the ModelElement is a client.
        /// </summary>
        IList<Dependency> clientDependency { get; }
        //Component[] container { get; }
        /// <summary>
        /// An identifier for the ModelElement within its containing Namespace.
        /// </summary>
        String name { get;set; }
        /// <summary>
        /// <p>Designates the Namespace that contains the ModelElement.</p>
        /// <p>Every ModelElement except a root element must belong to exactly one Namespace or else be a composite part of another ModelElement (which is a kind of virtual namespace). The pathname of Namespace or ModelElement names starting from the root package provides a unique designation for every ModelElement. The association attribute visibility specifies the visibility of the element outside its namespace (see ElementOwnership).</p>
        /// </summary>
        Namespace @namespace { get; }
        /// <summary>
        /// A set of PresentationElements that present a view of the ModelElement.
        /// </summary>
        IList<PresentationElement> presentation { get; }
        IList<TaggedValue> referenceTag { get; }
        IList<Flow> sourceFlow { get; }
        /// <summary>
        /// Inverse of supplier. Designates a set of Dependency in which the ModelElement is a supplier.
        /// </summary>
        IList<Dependency> supplierDependency { get; }
        IList<Flow> targetFlow { get; }
        /// <summary>
        /// <p>(association class TemplateParameter) A composite aggregation ordered list of parameters. Each parameter is a dummy ModelElement designated as a placeholder for a real ModelElement to be substituted during a binding of the template (see Binding). The real model element must be of the same kind (or a descendant kind) as the dummy ModelElement. The properties of the dummy ModelElement are ignored, except the name of the dummy element is used as the name of the template parameter. The association class TemplateParameter may be associated with a default ModelElement of the same kind as the dummy ModelElement. In the case of a Binding that does not supply an argument corresponding to the parameter, the value of the default ModelElement is used. If a Binding lacks an argument and there is no default ModelElement, the construct is invalid.</p>
        /// <p>Note that the template parameter element lacks structure. For example, a parameter that is a Class lacks Features; they are found in the actual argument.</p>
        /// <p>Note that if a ModelElement has at least one templateParameter, then it is a template, otherwise it is an ordinary element.</p>
        /// </summary>
        IList<TemplateParameter> templateParameter { get; }
        ModelElement template { get; }
        }
    }
