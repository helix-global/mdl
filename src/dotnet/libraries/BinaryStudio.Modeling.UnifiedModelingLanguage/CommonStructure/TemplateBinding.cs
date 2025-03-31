using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="TemplateBinding"/> is a <see cref="DirectedRelationship"/> between a <see cref="TemplateableElement"/> and a template. A <see cref="TemplateBinding"/> specifies the TemplateParameterSubstitutions of actual parameters for the formal parameters of the template.
    /// </summary>
    /// <rule language="OCL">
    ///   Each parameterSubstitution must refer to a formal <see cref="TemplateParameter"/> of the target <see cref="TemplateSignature"/>.
    ///   <![CDATA[
    ///     parameterSubstitution->forAll(b | signature.parameter->includes(b.formal))
    ///   ]]>
    ///   xmi:id="TemplateBinding-parameter_substitution_formal"
    /// </rule>
    /// <rule language="OCL">
    ///   A TemplateBiinding contains at most one <see cref="TemplateParameterSubstitution"/> for each formal <see cref="TemplateParameter"/> of the target <see cref="TemplateSignature"/>.
    ///   <![CDATA[
    ///     signature.parameter->forAll(p | parameterSubstitution->select(b | b.formal = p)->size() <= 1)
    ///   ]]>
    ///   xmi:id="TemplateBinding-one_parameter_substitution"
    /// </rule>
    /// xmi:id="TemplateBinding"
    public interface TemplateBinding : DirectedRelationship
        {
        #region P:BoundElement:TemplateableElement
        /// <summary>
        /// The <see cref="TemplateableElement"/> that is bound by this <see cref="TemplateBinding"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.DirectedRelationship.Source"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.Owner"/>"
        /// </summary>
        /// xmi:id="TemplateBinding-boundElement"
        /// xmi:association="A_templateBinding_boundElement"
        TemplateableElement BoundElement { get; }
        #endregion
        #region P:ParameterSubstitution:TemplateParameterSubstitution[]
        /// <summary>
        /// The TemplateParameterSubstitutions owned by this <see cref="TemplateBinding"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="TemplateBinding-parameterSubstitution"
        /// xmi:aggregation="composite"
        /// xmi:association="A_parameterSubstitution_templateBinding"
        TemplateParameterSubstitution[] ParameterSubstitution { get; }
        #endregion
        #region P:Signature:TemplateSignature
        /// <summary>
        /// The <see cref="TemplateSignature"/> for the template that is the <see cref="Target"/> of this <see cref="TemplateBinding"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.DirectedRelationship.Target"/>"
        /// </summary>
        /// xmi:id="TemplateBinding-signature"
        /// xmi:association="A_signature_templateBinding"
        TemplateSignature Signature { get; }
        #endregion
        }
    }
