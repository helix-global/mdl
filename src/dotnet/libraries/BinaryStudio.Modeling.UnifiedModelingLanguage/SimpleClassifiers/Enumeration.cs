using System;
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
        #region P:OwnedLiteral:EnumerationLiteral[]
        /// <summary>
        /// The ordered set of literals owned by this <see cref="Enumeration"/>.
        /// </summary>
        /// xmi:id="Enumeration-ownedLiteral"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedLiteral_enumeration"
        /// xmi:subsets="Namespace-ownedMember"
        [Ordered]
        EnumerationLiteral[] OwnedLiteral { get; }
        #endregion
        }
    }
