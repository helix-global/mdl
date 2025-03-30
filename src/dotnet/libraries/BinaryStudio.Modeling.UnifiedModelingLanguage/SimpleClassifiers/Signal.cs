using System;

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
        Property[] OwnedAttribute { get; }
        #endregion
        }
    }
