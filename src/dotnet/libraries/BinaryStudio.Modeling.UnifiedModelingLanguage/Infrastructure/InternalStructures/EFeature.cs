using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EFeature : ERedefinableElement,Feature
        {
        public Classifier FeaturingClassifier { get; }
        public Boolean IsStatic { get;set; }
        }
    }