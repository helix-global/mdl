using System;

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
        ParameterableElement Default { get; }
        #endregion
        #region P:OwnedDefault:ParameterableElement
        /// <summary>
        /// The <see cref="ParameterableElement"/> that is owned by this <see cref="TemplateParameter"/> for the purpose of providing a <see cref="Default"/>.
        /// </summary>
        /// xmi:id="TemplateParameter-ownedDefault"
        /// xmi:aggregation="composite"
        ParameterableElement OwnedDefault { get; }
        #endregion
        #region P:OwnedParameteredElement:ParameterableElement
        /// <summary>
        /// The <see cref="ParameterableElement"/> that is owned by this <see cref="TemplateParameter"/> for the purpose of exposing it as the <see cref="ParameteredElement"/>.
        /// </summary>
        /// xmi:id="TemplateParameter-ownedParameteredElement"
        /// xmi:aggregation="composite"
        ParameterableElement OwnedParameteredElement { get; }
        #endregion
        #region P:ParameteredElement:ParameterableElement
        /// <summary>
        /// The <see cref="ParameterableElement"/> exposed by this <see cref="TemplateParameter"/>.
        /// </summary>
        /// xmi:id="TemplateParameter-parameteredElement"
        ParameterableElement ParameteredElement { get; }
        #endregion
        #region P:Signature:TemplateSignature
        /// <summary>
        /// The <see cref="TemplateSignature"/> that owns this <see cref="TemplateParameter"/>.
        /// </summary>
        /// xmi:id="TemplateParameter-signature"
        TemplateSignature Signature { get; }
        #endregion
        }
    }
