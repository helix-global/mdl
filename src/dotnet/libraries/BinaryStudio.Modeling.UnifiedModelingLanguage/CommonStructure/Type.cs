using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Type"/> constrains the values represented by a <see cref="TypedElement"/>.
    /// </summary>
    /// xmi:id="Type"
    public interface Type : PackageableElement
        {
        #region P:Package:Package
        /// <summary>
        /// Specifies the owning <see cref="Package"/> of this <see cref="Type"/>, if any.
        /// Subsets:
        /// </summary>
        /// xmi:id="Type-package"
        /// xmi:association="A_ownedType_package"
        /// xmi:subsets="A_packagedElement_owningPackage-owningPackage"
        [Multiplicity("0..1")]
        Package Package { get; }
        #endregion

        #region M:conformsTo(Type):Boolean
        /// <summary>
        /// The query <see cref="conformsTo"/> gives true for a <see cref="Type"/> that conforms to another. By default, two Types do not conform to each other. This query is intended to be redefined for specific conformance situations.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (false)
        ///   ]]>
        ///   xmi:id="Type-conformsTo-spec"
        /// </rule>
        /// xmi:id="Type-conformsTo"
        /// xmi:is-query="true"
        Boolean conformsTo(Type other);
        #endregion
        }
    }
