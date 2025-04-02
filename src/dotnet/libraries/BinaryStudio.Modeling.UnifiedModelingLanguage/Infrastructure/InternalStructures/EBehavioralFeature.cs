using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal abstract class EBehavioralFeature : ENamespace, BehavioralFeature
        {
        public Boolean IsLeaf { get;set; }
        public IList<RedefinableElement> RedefinedElement { get; }
        public IList<Classifier> RedefinitionContext { get; }
        public Classifier FeaturingClassifier { get; }
        public Boolean IsStatic { get; set; }
        public CallConcurrencyKind Concurrency { get;set; }
        public Boolean IsAbstract { get; set; }
        public IList<Behavior> Method { get; }
        public IList<Parameter> OwnedParameter { get; }
        public IList<ParameterSet> OwnedParameterSet { get; }
        public IList<Type> RaisedException { get; }

        protected EBehavioralFeature()
            {
            OwnedParameter = new List<Parameter>();
            }

        public Boolean isConsistentWith(RedefinableElement redefiningElement)
            {
            throw new NotImplementedException();
            }

        public Boolean isRedefinitionContextValid(RedefinableElement redefinedElement)
            {
            throw new NotImplementedException();
            }

        public Parameter[] inputParameters()
            {
            throw new NotImplementedException();
            }

        public Parameter[] outputParameters()
            {
            throw new NotImplementedException();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"BehavioralFeature"
                : $"BehavioralFeature{{{Name}}}";
            }
        #endregion
        }
    }