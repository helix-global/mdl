using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal abstract class EType : EPackageableElement,Type
        {
        public Package Package { get;set; }
        public Boolean conformsTo(Type other)
            {
            throw new NotImplementedException();
            }

        protected EType()
            {
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"Type"
                : $"Type{{{Name}}}";
            }
        #endregion
        }
    }