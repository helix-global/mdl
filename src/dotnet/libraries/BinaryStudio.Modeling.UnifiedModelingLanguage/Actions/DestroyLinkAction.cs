using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="DestroyLinkAction"/> is a <see cref="WriteLinkAction"/> that destroys links (including link objects).
    /// </summary>
    /// xmi:id="DestroyLinkAction"
    public interface DestroyLinkAction : WriteLinkAction
        {
        #region P:EndData:IList<LinkEndDestructionData>
        /// <summary>
        /// The <see cref="LinkEndData"/> that the values of the <see cref="Association"/> ends for the links to be destroyed.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.LinkAction.EndData"/>"
        /// </summary>
        /// xmi:id="DestroyLinkAction-endData"
        /// xmi:aggregation="composite"
        /// xmi:association="A_endData_destroyLinkAction"
        [Multiplicity("2..*")]
        IList<LinkEndDestructionData> EndData { get; }
        #endregion
        }
    }
