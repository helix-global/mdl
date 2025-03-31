using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="EnumerationLiteral"/> is a user-defined data value for an <see cref="Enumeration"/>.
    /// </summary>
    /// xmi:id="EnumerationLiteral"
    public interface EnumerationLiteral : InstanceSpecification
        {
        #region P:Classifier:Enumeration
        /// <summary>
        /// The <see cref="Classifier"/> of this <see cref="EnumerationLiteral"/> derived to be equal to its <see cref="Enumeration"/>.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.InstanceSpecification.Classifier"/>"
        /// </summary>
        /// xmi:id="EnumerationLiteral-classifier"
        /// xmi:association="A_classifier_enumerationLiteral"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        Enumeration Classifier { get; }
        #endregion
        #region P:Enumeration:Enumeration
        /// <summary>
        /// The <see cref="Enumeration"/> that this <see cref="EnumerationLiteral"/> is a member of.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        /// </summary>
        /// xmi:id="EnumerationLiteral-enumeration"
        /// xmi:association="A_ownedLiteral_enumeration"
        Enumeration Enumeration { get; }
        #endregion

        #region M:classifier:Enumeration
        /// <summary>
        /// Derivation of <see cref="Enumeration"/>::/<see cref="Classifier"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (enumeration)
        ///   ]]>
        ///   xmi:id="EnumerationLiteral-classifier.1-spec"
        /// </rule>
        /// xmi:id="EnumerationLiteral-classifier.1"
        /// xmi:is-query="true"
        Enumeration classifier();
        #endregion
        }
    }
