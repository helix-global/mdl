using System;
using System.Collections.Generic;
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
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.DirectedRelationship.Target"/>"
        /// </summary>
        /// xmi:id="Include-addition"
        /// xmi:association="A_addition_include"
        UseCase Addition { get;set; }
        #endregion
        #region P:IncludingCase:UseCase
        /// <summary>
        /// The <see cref="UseCase"/> which includes the <see cref="Addition"/> and owns the <see cref="Include"/> relationship.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.DirectedRelationship.Source"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        /// </summary>
        /// xmi:id="Include-includingCase"
        /// xmi:association="A_include_includingCase"
        UseCase IncludingCase { get;set; }
        #endregion
        }
    }
