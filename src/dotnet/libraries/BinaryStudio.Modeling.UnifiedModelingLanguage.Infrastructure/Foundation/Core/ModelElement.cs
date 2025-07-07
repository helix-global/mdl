using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface ModelElement : Element
        {
        Boolean IsSpecification { get;set; }
        StateMachine[] behavior { get; }
        ClassifierRole[] classifierRole { get; }
        Dependency[] clientDependency { get; }
        Collaboration[] collaboration { get; }
        CollaborationInstanceSet[] collaborationInstanceSet { get; }
        Comment[] comment { get; }
        Constraint[] constraint { get; }
        TemplateParameter[] defaultedParameter { get; }
        ElementImport[] elementImport { get; }
        ElementResidence[] elementResidence { get; }
        Name name { get; }
        Namespace @namespace { get; }
        TemplateParameter parameterTemplate { get; }
        Partition[] partition { get; }
        PresentationElement[] presentation { get; }
        TaggedValue[] referenceTag { get; }
        Flow[] sourceFlow { get; }
        Stereotype[] stereotype { get; }
        Dependency[] supplierDependency { get; }
        TaggedValue[] taggedValue { get; }
        Flow[] targetFlow { get; }
        TemplateArgument[] templateArgument { get; }
        TemplateParameter[] templateParameter { get; }
        VisibilityKind visibility { get;set; }

        //Component[] container { get; }
        //ModelElement[] templateParameter { get; }
        //ModelElement template { get; }
        //Package[] thePackage { get; }
        }
    }
