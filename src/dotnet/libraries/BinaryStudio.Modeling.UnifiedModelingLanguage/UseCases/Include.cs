using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

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
        /// xmi:association="A_addition_include"
        /// xmi:subsets="DirectedRelationship-target"
        UseCase Addition { get; }
        #endregion
        #region P:IncludingCase:UseCase
        /// <summary>
        /// The <see cref="UseCase"/> which includes the <see cref="Addition"/> and owns the <see cref="Include"/> relationship.
        /// </summary>
        /// xmi:id="Include-includingCase"
        /// xmi:association="A_include_includingCase"
        /// xmi:subsets="DirectedRelationship-source"
        /// xmi:subsets="NamedElement-namespace"
        UseCase IncludingCase { get; }
        #endregion
        }
    }
