using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="CreateLinkAction"/> is a <see cref="WriteLinkAction"/> for creating links.
    /// </summary>
    /// <rule language="OCL">
    ///   The <see cref="Association"/> cannot be an abstract <see cref="Classifier"/>.
    ///   <![CDATA[
    ///     not self.association().isAbstract
    ///   ]]>
    ///   xmi:id="CreateLinkAction-association_not_abstract"
    /// </rule>
    /// xmi:id="CreateLinkAction"
    public interface CreateLinkAction : WriteLinkAction
        {
        #region P:EndData:LinkEndCreationData /*[2,*]*/
        /// <summary>
        /// The <see cref="LinkEndData"/> that specifies the values to be placed on the <see cref="Association"/> ends for the new link.
        /// </summary>
        /// xmi:id="CreateLinkAction-endData"
        /// xmi:aggregation="composite"
        /// xmi:redefines="LinkAction-endData{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.LinkAction.EndData"/>}"
        LinkEndCreationData /*[2,*]*/ EndData { get; }
        #endregion
        }
    }
