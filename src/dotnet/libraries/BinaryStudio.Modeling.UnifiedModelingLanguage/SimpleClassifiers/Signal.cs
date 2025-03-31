using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Signal"/> is a specification of a kind of communication between objects in which a reaction is asynchronously triggered in the receiver without a reply.
    /// </summary>
    /// xmi:id="Signal"
    public interface Signal : Classifier
        {
        #region P:OwnedAttribute:Property[]
        /// <summary>
        /// The attributes owned by the <see cref="Signal"/>.
        /// </summary>
        /// xmi:id="Signal-ownedAttribute"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedAttribute_owningSignal"
        /// xmi:subsets="Classifier-attribute"
        /// xmi:subsets="Namespace-ownedMember"
        [Ordered]
        Property[] OwnedAttribute { get; }
        #endregion
        }
    }
