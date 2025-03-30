using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="Include"/> relationship specifies that a <see cref="UseCase"/> contains the behavior defined in another <see cref="UseCase"/>.
    /// </summary>
    /// xmi:id="Include"
    public interface Include : DirectedRelationship,NamedElement
        {
        #region P:Addition:UseCase
        /// <summary>
        /// The <see cref="UseCase"/> that is to be included.
        /// </summary>
        /// xmi:id="Include-addition"
        UseCase Addition { get; }
        #endregion
        #region P:IncludingCase:UseCase
        /// <summary>
        /// The <see cref="UseCase"/> which includes the <see cref="Addition"/> and owns the <see cref="Include"/> relationship.
        /// </summary>
        /// xmi:id="Include-includingCase"
        UseCase IncludingCase { get; }
        #endregion
        }
    }
