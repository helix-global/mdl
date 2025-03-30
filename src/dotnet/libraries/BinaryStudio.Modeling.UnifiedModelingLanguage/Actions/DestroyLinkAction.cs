using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="DestroyLinkAction"/> is a <see cref="WriteLinkAction"/> that destroys links (including link objects).
    /// </summary>
    /// xmi:id="DestroyLinkAction"
    public interface DestroyLinkAction : WriteLinkAction
        {
        #region P:EndData:LinkEndDestructionData /*[2,*]*/
        /// <summary>
        /// The <see cref="LinkEndData"/> that the values of the <see cref="Association"/> ends for the links to be destroyed.
        /// </summary>
        /// xmi:id="DestroyLinkAction-endData"
        /// xmi:aggregation="composite"
        /// xmi:redefines="LinkAction-endData{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.LinkAction.EndData"/>}"
        LinkEndDestructionData /*[2,*]*/ EndData { get; }
        #endregion
        }
    }
