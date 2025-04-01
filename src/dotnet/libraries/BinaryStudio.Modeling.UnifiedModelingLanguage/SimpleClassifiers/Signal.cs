using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Signal"/> is a specification of a kind of communication between objects in which a reaction is asynchronously triggered in the receiver without a reply.
    /// </summary>
    /// xmi:id="Signal"
    public interface Signal : Classifier
        {
        #region P:OwnedAttribute:IList<Property>
        /// <summary>
        /// The attributes owned by the <see cref="Signal"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.Attribute"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Signal-ownedAttribute"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedAttribute_owningSignal"
        [Ordered]
        IList<Property> OwnedAttribute { get; }
        #endregion
        }
    }
