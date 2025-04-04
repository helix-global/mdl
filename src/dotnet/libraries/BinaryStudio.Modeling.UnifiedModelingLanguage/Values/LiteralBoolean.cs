﻿using System;
using System.Collections.Generic;
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
        Boolean Value { get;set; }
        #endregion

        #region M:booleanValue:Boolean
        /// <summary>
        /// The query <see cref="booleanValue"/> gives the <see cref="Value"/>.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.ValueSpecification.booleanValue"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (value)
        ///   ]]>
        ///   xmi:id="LiteralBoolean-booleanValue-spec"
        /// </rule>
        /// xmi:id="LiteralBoolean-booleanValue"
        /// xmi:is-query="true"
        Boolean booleanValue();
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
        ///   xmi:id="LiteralBoolean-isComputable-spec"
        /// </rule>
        /// xmi:id="LiteralBoolean-isComputable"
        /// xmi:is-query="true"
        Boolean isComputable();
        #endregion
        }
    }
