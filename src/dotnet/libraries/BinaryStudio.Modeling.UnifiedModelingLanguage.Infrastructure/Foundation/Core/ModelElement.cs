using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ModelElement : Element
        {
        IList<StateMachine> behavior { get; }
        IList<Dependency> clientDependency { get; }
        IList<Constraint> constraint { get; }
        //Component[] container { get; }
        Name name { get; }
        Namespace @namespace { get; }
        IList<PresentationElement> presentation { get; }
        IList<TaggedValue> referenceTag { get; }
        IList<Flow> sourceFlow { get; }
        IList<Stereotype> stereotype { get; }
        IList<Dependency> supplierDependency { get; }
        IList<TaggedValue> taggedValue { get; }
        IList<Flow> targetFlow { get; }
        IList<TemplateParameter> templateParameter { get; }
        ModelElement template { get; }
        }
    }
