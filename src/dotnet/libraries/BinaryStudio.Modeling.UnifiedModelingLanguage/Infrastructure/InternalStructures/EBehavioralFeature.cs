using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EBehavioralFeature : ENamespace, BehavioralFeature
        {
        public Boolean IsLeaf { get;set; }
        public IList<RedefinableElement> RedefinedElement { get; }
        public IList<Classifier> RedefinitionContext { get; }
        public Boolean isConsistentWith(RedefinableElement redefiningElement)
            {
            throw new NotImplementedException();
            }

        public Boolean isRedefinitionContextValid(RedefinableElement redefinedElement)
            {
            throw new NotImplementedException();
            }

        public Classifier FeaturingClassifier { get; }
        public Boolean IsStatic { get; set; }
        public CallConcurrencyKind Concurrency { get;set; }
        public Boolean IsAbstract { get; set; }
        public IList<Behavior> Method { get; }
        public IList<Parameter> OwnedParameter { get; }
        public IList<ParameterSet> OwnedParameterSet { get; }
        public IList<Type> RaisedException { get; }
        public Parameter[] inputParameters()
            {
            throw new NotImplementedException();
            }

        public Parameter[] outputParameters()
            {
            throw new NotImplementedException();
            }
        }
    }