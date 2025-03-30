using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Collaboration"/> describes a structure of collaborating elements (roles), each performing a specialized function, which collectively accomplish some desired functionality. 
    /// </summary>
    /// xmi:id="Collaboration"
    public interface Collaboration : StructuredClassifier,BehavioredClassifier
        {
        #region P:CollaborationRole:ConnectableElement[]
        /// <summary>
        /// Represents the participants in the <see cref="Collaboration"/>.
        /// </summary>
        /// xmi:id="Collaboration-collaborationRole"
        ConnectableElement[] CollaborationRole { get; }
        #endregion
        }
    }
