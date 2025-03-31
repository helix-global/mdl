using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

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
        #region P:EndData:LinkEndCreationData[]
        /// <summary>
        /// The <see cref="LinkEndData"/> that specifies the values to be placed on the <see cref="Association"/> ends for the new link.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.LinkAction.EndData"/>"
        /// </summary>
        /// xmi:id="CreateLinkAction-endData"
        /// xmi:aggregation="composite"
        /// xmi:association="A_endData_createLinkAction"
        [Multiplicity("2..*")]
        LinkEndCreationData[] EndData { get; }
        #endregion
        }
    }
