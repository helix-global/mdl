﻿using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="DataType"/> is a type whose instances are identified only by their value.
    /// </summary>
    /// xmi:id="DataType"
    public interface DataType : Classifier
        {
        #region P:OwnedAttribute:IList<Property>
        /// <summary>
        /// The attributes owned by the <see cref="DataType"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.Attribute"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="DataType-ownedAttribute"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedAttribute_datatype"
        [Ordered]
        IList<Property> OwnedAttribute { get; }
        #endregion
        #region P:OwnedOperation:IList<Operation>
        /// <summary>
        /// The Operations owned by the <see cref="DataType"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.Feature"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="DataType-ownedOperation"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedOperation_datatype"
        /// xmi:subsets="A_redefinitionContext_redefinableElement-redefinableElement"
        [Ordered]
        IList<Operation> OwnedOperation { get; }
        #endregion
        }
    }
