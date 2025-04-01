using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A Template Signature bundles the set of formal TemplateParameters for a <see cref="Template"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   Parameters must own the ParameterableElements they parameter or those ParameterableElements must be owned by the <see cref="TemplateableElement"/> being templated.
    ///   <![CDATA[
    ///     template.ownedElement->includesAll(parameter.parameteredElement->asSet() - parameter.ownedParameteredElement->asSet())
    ///   ]]>
    ///   xmi:id="TemplateSignature-own_elements"
    /// </rule>
    /// <rule language="OCL">
    ///   The names of the parameters of a <see cref="TemplateSignature"/> are unique.
    ///   <![CDATA[
    ///     parameter->forAll( p1, p2 | (p1 <> p2 and p1.parameteredElement.oclIsKindOf(NamedElement) and p2.parameteredElement.oclIsKindOf(NamedElement) ) implies
    ///        p1.parameteredElement.oclAsType(NamedElement).name <> p2.parameteredElement.oclAsType(NamedElement).name)
    ///   ]]>
    ///   xmi:id="TemplateSignature-unique_parameters"
    /// </rule>
    /// xmi:id="TemplateSignature"
    public interface TemplateSignature : Element
        {
        #region P:OwnedParameter:IList<TemplateParameter>
        /// <summary>
        /// The formal parameters that are owned by this <see cref="TemplateSignature"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.TemplateSignature.Parameter"/>"
        /// </summary>
        /// xmi:id="TemplateSignature-ownedParameter"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedParameter_signature"
        [Ordered]
        IList<TemplateParameter> OwnedParameter { get; }
        #endregion
        #region P:Parameter:IList<TemplateParameter>
        /// <summary>
        /// The ordered set of all formal TemplateParameters for this <see cref="TemplateSignature"/>.
        /// </summary>
        /// xmi:id="TemplateSignature-parameter"
        /// xmi:association="A_parameter_templateSignature"
        [Multiplicity("1..*")][Ordered]
        IList<TemplateParameter> Parameter { get; }
        #endregion
        #region P:Template:TemplateableElement
        /// <summary>
        /// The <see cref="TemplateableElement"/> that owns this <see cref="TemplateSignature"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.Owner"/>"
        /// </summary>
        /// xmi:id="TemplateSignature-template"
        /// xmi:association="A_ownedTemplateSignature_template"
        TemplateableElement Template { get;set; }
        #endregion
        }
    }
