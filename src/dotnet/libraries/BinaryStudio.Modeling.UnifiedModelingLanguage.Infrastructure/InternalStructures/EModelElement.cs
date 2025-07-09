using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EModelElement : EElement,ModelElement
        {
        IList<StateMachine> ModelElement.behavior { get; }
        IList<Dependency> ModelElement.clientDependency { get; }
        IList<Constraint> ModelElement.constraint { get; }
        public Name name { get; }
        public Namespace @namespace { get; }
        IList<PresentationElement> ModelElement.presentation { get; }
        IList<TaggedValue> ModelElement.referenceTag { get; }
        IList<Flow> ModelElement.sourceFlow { get; }
        IList<Stereotype> ModelElement.stereotype { get; }
        IList<Dependency> ModelElement.supplierDependency { get; }
        IList<TaggedValue> ModelElement.taggedValue { get; }
        IList<Flow> ModelElement.targetFlow { get; }
        IList<TemplateParameter> ModelElement.templateParameter { get; }
        ModelElement ModelElement.template { get; }
        }
    }