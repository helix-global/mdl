using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EInstanceSpecification : EPackageableElement, InstanceSpecification
        {
        public IList<PackageableElement> DeployedElement { get; }
        public IList<Deployment> Deployment { get; }
        public PackageableElement[] deployedElement()
            {
            throw new System.NotImplementedException();
            }

        public IList<Classifier> Classifier { get; }
        public IList<Slot> Slot { get; }
        public ValueSpecification Specification { get;set; }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"InstanceSpecification"
                : $"InstanceSpecification{{{Name}}}";
            }
        #endregion
        }
    }