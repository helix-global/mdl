using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="Enumeration"/> is a <see cref="DataType"/> whose values are enumerated in the model as EnumerationLiterals.
    /// </summary>
    /// <rule language="OCL">
    ///   <![CDATA[
    ///     ownedAttribute->forAll(isReadOnly)
    ///   ]]>
    ///   xmi:id="Enumeration-immutable"
    /// </rule>
    /// xmi:id="Enumeration"
    public interface Enumeration : DataType
        {
        #region P:OwnedLiteral:IList<EnumerationLiteral>
        /// <summary>
        /// The ordered set of literals owned by this <see cref="Enumeration"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Enumeration-ownedLiteral"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedLiteral_enumeration"
        [Ordered]
        IList<EnumerationLiteral> OwnedLiteral { get; }
        #endregion
        }
    }
