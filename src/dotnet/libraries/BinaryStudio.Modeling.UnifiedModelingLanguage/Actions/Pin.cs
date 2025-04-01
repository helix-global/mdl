using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Pin"/> is an <see cref="ObjectNode"/> and <see cref="MultiplicityElement"/> that provides input values to an <see cref="Action"/> or accepts output values from an <see cref="Action"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   A control <see cref="Pin"/> has a control type.
    ///   <![CDATA[
    ///     isControl implies isControlType
    ///   ]]>
    ///   xmi:id="Pin-control_pins"
    /// </rule>
    /// <rule language="OCL">
    ///   <see cref="Pin"/> multiplicity is not unique.
    ///   <![CDATA[
    ///     not isUnique
    ///   ]]>
    ///   xmi:id="Pin-not_unique"
    /// </rule>
    /// xmi:id="Pin"
    public interface Pin : MultiplicityElement,ObjectNode
        {
        #region P:IsControl:Boolean
        /// <summary>
        /// Indicates whether the <see cref="Pin"/> provides data to the <see cref="Action"/> or just controls how the <see cref="Action"/> executes.
        /// </summary>
        /// xmi:id="Pin-isControl"
        Boolean IsControl { get;set; }
        #endregion
        }
    }
