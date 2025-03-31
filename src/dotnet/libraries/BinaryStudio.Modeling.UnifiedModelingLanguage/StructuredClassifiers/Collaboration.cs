using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Collaboration"/> describes a structure of collaborating elements (roles), each performing a specialized function, which collectively accomplish some desired functionality. 
    /// </summary>
    /// xmi:id="Collaboration"
    public interface Collaboration : BehavioredClassifier,StructuredClassifier
        {
        #region P:CollaborationRole:ConnectableElement[]
        /// <summary>
        /// Represents the participants in the <see cref="Collaboration"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.StructuredClassifier.Role"/>"
        /// </summary>
        /// xmi:id="Collaboration-collaborationRole"
        /// xmi:association="A_collaborationRole_collaboration"
        ConnectableElement[] CollaborationRole { get; }
        #endregion
        }
    }
