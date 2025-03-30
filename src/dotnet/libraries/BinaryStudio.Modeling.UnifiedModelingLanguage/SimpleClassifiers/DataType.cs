using System;

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
        Property[] OwnedAttribute { get; }
        #endregion
        #region P:OwnedOperation:Operation[]
        /// <summary>
        /// The Operations owned by the <see cref="DataType"/>.
        /// </summary>
        /// xmi:id="DataType-ownedOperation"
        /// xmi:aggregation="composite"
        Operation[] OwnedOperation { get; }
        #endregion
        }
    }
