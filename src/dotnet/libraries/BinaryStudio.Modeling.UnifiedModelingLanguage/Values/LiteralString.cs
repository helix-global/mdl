using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="LiteralString"/> is a specification of a String <see cref="Value"/>.
    /// </summary>
    /// xmi:id="LiteralString"
    public interface LiteralString : LiteralSpecification
        {
        #region P:Value:String
        /// <summary>
        /// The specified String <see cref="Value"/>.
        /// </summary>
        /// xmi:id="LiteralString-value"
        [Multiplicity("0..1")]
        String Value { get; }
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
        ///   xmi:id="LiteralString-isComputable-spec"
        /// </rule>
        /// xmi:id="LiteralString-isComputable"
        /// xmi:is-query="true"
        Boolean isComputable();
        #endregion
        #region M:stringValue:String
        /// <summary>
        /// The query <see cref="stringValue"/> gives the <see cref="Value"/>.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.ValueSpecification.stringValue"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (value)
        ///   ]]>
        ///   xmi:id="LiteralString-stringValue-spec"
        /// </rule>
        /// xmi:id="LiteralString-stringValue"
        /// xmi:is-query="true"
        String stringValue();
        #endregion
        }
    }
