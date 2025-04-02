using System;
using BinaryStudio.Modeling.MetadataInterchange;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EInstanceValue : EValueSpecification,InstanceValue
        {
        [IsIDREF] public InstanceSpecification Instance { get;set; }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"InstanceValue"
                : $"InstanceValue{{{Name}}}";
            }
        #endregion
        }
    }