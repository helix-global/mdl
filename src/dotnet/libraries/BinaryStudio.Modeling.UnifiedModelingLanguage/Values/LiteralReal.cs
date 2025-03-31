using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    using Real=Double;

    /// <summary>
    /// A <see cref="LiteralReal"/> is a specification of a Real <see cref="Value"/>.
    /// </summary>
    /// xmi:id="LiteralReal"
    public interface LiteralReal : LiteralSpecification
        {
        #region P:Value:Real
        /// <summary>
        /// The specified Real <see cref="Value"/>.
        /// </summary>
        /// xmi:id="LiteralReal-value"
        Real Value { get; }
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
        ///   xmi:id="LiteralReal-isComputable-spec"
        /// </rule>
        /// xmi:id="LiteralReal-isComputable"
        /// xmi:is-query="true"
        Boolean isComputable();
        #endregion
        #region M:realValue:Real
        /// <summary>
        /// The query <see cref="realValue"/> gives the <see cref="Value"/>.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.ValueSpecification.realValue"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (value)
        ///   ]]>
        ///   xmi:id="LiteralReal-realValue-spec"
        /// </rule>
        /// xmi:id="LiteralReal-realValue"
        /// xmi:is-query="true"
        Real realValue();
        #endregion
        }
    }
