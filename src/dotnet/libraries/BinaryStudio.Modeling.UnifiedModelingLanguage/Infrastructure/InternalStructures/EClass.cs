using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EClass : EEncapsulatedClassifier,Class
        {
        public Behavior ClassifierBehavior { get;set; }
        public IList<InterfaceRealization> InterfaceRealization { get; }
        public IList<Behavior> OwnedBehavior { get; }
        public IList<Extension> Extension { get; }
        public Boolean IsActive { get;set; }
        public IList<Classifier> NestedClassifier { get; }
        public IList<Operation> OwnedOperation { get; }
        public IList<Reception> OwnedReception { get; }
        public IList<Class> SuperClass { get; }

        public EClass()
            {
            OwnedOperation = new List<Operation>();
            }

        public Extension[] extension()
            {
            throw new NotImplementedException();
            }

        public Class[] superClass()
            {
            throw new NotImplementedException();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"Class"
                : $"Class{{{Name}}}";
            }
        #endregion
        }
    }