using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="LiteralBoolean"/> is a specification of a Boolean <see cref="Value"/>.
    /// </summary>
    /// xmi:id="LiteralBoolean"
    public interface LiteralBoolean : LiteralSpecification
        {
        #region P:Value:Boolean
        /// <summary>
        /// The specified Boolean <see cref="Value"/>.
        /// </summary>
        /// xmi:id="LiteralBoolean-value"
        Boolean Value { get; }
        #endregion

        #region M:booleanValue:Boolean
        /// <summary>
        /// The query <see cref="booleanValue"/> gives the <see cref="Value"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (value)
        ///   ]]>
        ///   xmi:id="LiteralBoolean-booleanValue-spec"
        /// </rule>
        /// xmi:id="LiteralBoolean-booleanValue"
        /// xmi:is-query="true"
        /// xmi:redefines="ValueSpecification-booleanValue{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.ValueSpecification.booleanValue"/>}"
        Boolean booleanValue();
        #endregion
        #region M:isComputable:Boolean
        /// <summary>
        /// The query <see cref="isComputable"/> is redefined to be true.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (true)
        ///   ]]>
        ///   xmi:id="LiteralBoolean-isComputable-spec"
        /// </rule>
        /// xmi:id="LiteralBoolean-isComputable"
        /// xmi:is-query="true"
        /// xmi:redefines="ValueSpecification-isComputable{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.ValueSpecification.isComputable"/>}"
        Boolean isComputable();
        #endregion
        }
    }
