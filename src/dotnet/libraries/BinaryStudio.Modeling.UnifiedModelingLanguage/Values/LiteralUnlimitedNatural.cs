using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="LiteralUnlimitedNatural"/> is a specification of an UnlimitedNatural number.
    /// </summary>
    /// xmi:id="LiteralUnlimitedNatural"
    public interface LiteralUnlimitedNatural : LiteralSpecification
        {
        #region P:Value:UnlimitedNatural
        /// <summary>
        /// The specified UnlimitedNatural <see cref="Value"/>.
        /// </summary>
        /// xmi:id="LiteralUnlimitedNatural-value"
        UnlimitedNatural Value { get; }
        #endregion

        #region M:isComputable:Boolean
        /// <summary>
        /// The query <see cref="isComputable"/> is redefined to be true.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.ValueSpecification.isComputable"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (true)
        ///   ]]>
        ///   xmi:id="LiteralUnlimitedNatural-isComputable-spec"
        /// </rule>
        /// xmi:id="LiteralUnlimitedNatural-isComputable"
        /// xmi:is-query="true"
        Boolean isComputable();
        #endregion
        #region M:unlimitedValue:UnlimitedNatural
        /// <summary>
        /// The query <see cref="unlimitedValue"/> gives the <see cref="Value"/>.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.ValueSpecification.unlimitedValue"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (value)
        ///   ]]>
        ///   xmi:id="LiteralUnlimitedNatural-unlimitedValue-spec"
        /// </rule>
        /// xmi:id="LiteralUnlimitedNatural-unlimitedValue"
        /// xmi:is-query="true"
        UnlimitedNatural unlimitedValue();
        #endregion
        }
    }
