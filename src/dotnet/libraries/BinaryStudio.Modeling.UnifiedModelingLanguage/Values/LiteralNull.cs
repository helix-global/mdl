using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="LiteralNull"/> specifies the lack of a value.
    /// </summary>
    /// xmi:id="LiteralNull"
    public interface LiteralNull : LiteralSpecification
        {

        #region M:isComputable:Boolean
        /// <summary>
        /// The query <see cref="isComputable"/> is redefined to be true.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (true)
        ///   ]]>
        ///   xmi:id="LiteralNull-isComputable-spec"
        /// </rule>
        /// xmi:id="LiteralNull-isComputable"
        /// xmi:is-query="true"
        /// xmi:redefines="ValueSpecification-isComputable{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.ValueSpecification.isComputable"/>}"
        Boolean isComputable();
        #endregion
        #region M:isNull:Boolean
        /// <summary>
        /// The query <see cref="isNull"/> returns true.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (true)
        ///   ]]>
        ///   xmi:id="LiteralNull-isNull-spec"
        /// </rule>
        /// xmi:id="LiteralNull-isNull"
        /// xmi:is-query="true"
        /// xmi:redefines="ValueSpecification-isNull{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.ValueSpecification.isNull"/>}"
        Boolean isNull();
        #endregion
        }
    }
