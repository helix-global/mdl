using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EFeature : ERedefinableElement,Feature
        {
        public Classifier FeaturingClassifier { get; }
        public Boolean IsStatic { get;set; }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"Feature"
                : $"Feature{{{Name}}}";
            }
        #endregion
        }
    }