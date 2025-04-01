using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    using Integer=Int32;

    /// <summary>
    /// A <see cref="LiteralInteger"/> is a specification of an Integer <see cref="Value"/>.
    /// </summary>
    /// xmi:id="LiteralInteger"
    public interface LiteralInteger : LiteralSpecification
        {
        #region P:Value:Integer
        /// <summary>
        /// The specified Integer <see cref="Value"/>.
        /// </summary>
        /// xmi:id="LiteralInteger-value"
        Integer Value { get;set; }
        #endregion

        #region M:integerValue:Integer
        /// <summary>
        /// The query <see cref="integerValue"/> gives the <see cref="Value"/>.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.ValueSpecification.integerValue"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (value)
        ///   ]]>
        ///   xmi:id="LiteralInteger-integerValue-spec"
        /// </rule>
        /// xmi:id="LiteralInteger-integerValue"
        /// xmi:is-query="true"
        Integer integerValue();
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
        ///   xmi:id="LiteralInteger-isComputable-spec"
        /// </rule>
        /// xmi:id="LiteralInteger-isComputable"
        /// xmi:is-query="true"
        Boolean isComputable();
        #endregion
        }
    }
