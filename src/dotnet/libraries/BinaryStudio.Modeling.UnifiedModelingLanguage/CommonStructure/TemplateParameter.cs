using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="TemplateParameter"/> exposes a <see cref="ParameterableElement"/> as a formal parameter of a template.
    /// </summary>
    /// <rule language="OCL">
    ///   The default must be compatible with the formal <see cref="TemplateParameter"/>.
    ///   <![CDATA[
    ///     default <> null implies default.isCompatibleWith(parameteredElement)
    ///   ]]>
    ///   xmi:id="TemplateParameter-must_be_compatible"
    /// </rule>
    /// xmi:id="TemplateParameter"
    public interface TemplateParameter : Element
        {
        #region P:Default:ParameterableElement
        /// <summary>
        /// The <see cref="ParameterableElement"/> that is the <see cref="Default"/> for this formal <see cref="TemplateParameter"/>.
        /// </summary>
        /// xmi:id="TemplateParameter-default"
        /// xmi:association="A_default_templateParameter"
        [Multiplicity("0..1")]
        ParameterableElement Default { get; }
        #endregion
        #region P:OwnedDefault:ParameterableElement
        /// <summary>
        /// The <see cref="ParameterableElement"/> that is owned by this <see cref="TemplateParameter"/> for the purpose of providing a <see cref="Default"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.TemplateParameter.Default"/>"
        /// </summary>
        /// xmi:id="TemplateParameter-ownedDefault"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedDefault_templateParameter"
        [Multiplicity("0..1")]
        ParameterableElement OwnedDefault { get; }
        #endregion
        #region P:OwnedParameteredElement:ParameterableElement
        /// <summary>
        /// The <see cref="ParameterableElement"/> that is owned by this <see cref="TemplateParameter"/> for the purpose of exposing it as the <see cref="ParameteredElement"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.TemplateParameter.ParameteredElement"/>"
        /// </summary>
        /// xmi:id="TemplateParameter-ownedParameteredElement"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedParameteredElement_owningTemplateParameter"
        [Multiplicity("0..1")]
        ParameterableElement OwnedParameteredElement { get; }
        #endregion
        #region P:ParameteredElement:ParameterableElement
        /// <summary>
        /// The <see cref="ParameterableElement"/> exposed by this <see cref="TemplateParameter"/>.
        /// </summary>
        /// xmi:id="TemplateParameter-parameteredElement"
        /// xmi:association="A_parameteredElement_templateParameter"
        ParameterableElement ParameteredElement { get; }
        #endregion
        #region P:Signature:TemplateSignature
        /// <summary>
        /// The <see cref="TemplateSignature"/> that owns this <see cref="TemplateParameter"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.Owner"/>"
        /// </summary>
        /// xmi:id="TemplateParameter-signature"
        /// xmi:association="A_ownedParameter_signature"
        /// xmi:subsets="A_parameter_templateSignature-templateSignature"
        TemplateSignature Signature { get; }
        #endregion
        }
    }
