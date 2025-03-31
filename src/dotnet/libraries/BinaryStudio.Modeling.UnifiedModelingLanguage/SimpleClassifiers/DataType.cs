using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="DataType"/> is a type whose instances are identified only by their value.
    /// </summary>
    /// xmi:id="DataType"
    public interface DataType : Classifier
        {
        #region P:OwnedAttribute:Property[]
        /// <summary>
        /// The attributes owned by the <see cref="DataType"/>.
        /// </summary>
        /// xmi:id="DataType-ownedAttribute"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedAttribute_datatype"
        /// xmi:subsets="Classifier-attribute"
        /// xmi:subsets="Namespace-ownedMember"
        [Ordered]
        Property[] OwnedAttribute { get; }
        #endregion
        #region P:OwnedOperation:Operation[]
        /// <summary>
        /// The Operations owned by the <see cref="DataType"/>.
        /// </summary>
        /// xmi:id="DataType-ownedOperation"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedOperation_datatype"
        /// xmi:subsets="A_redefinitionContext_redefinableElement-redefinableElement"
        /// xmi:subsets="Classifier-feature"
        /// xmi:subsets="Namespace-ownedMember"
        [Ordered]
        Operation[] OwnedOperation { get; }
        #endregion
        }
    }
