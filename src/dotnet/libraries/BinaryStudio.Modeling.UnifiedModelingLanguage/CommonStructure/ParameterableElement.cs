using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ParameterableElement"/> is an <see cref="Element"/> that can be exposed as a formal <see cref="TemplateParameter"/> for a template, or specified as an actual parameter in a binding of a template.
    /// </summary>
    /// xmi:id="ParameterableElement"
    public interface ParameterableElement : Element
        {
        #region P:OwningTemplateParameter:TemplateParameter
        /// <summary>
        /// The formal <see cref="TemplateParameter"/> that owns this <see cref="ParameterableElement"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.Owner"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.ParameterableElement.TemplateParameter"/>"
        /// </summary>
        /// xmi:id="ParameterableElement-owningTemplateParameter"
        /// xmi:association="A_ownedParameteredElement_owningTemplateParameter"
        [Multiplicity("0..1")]
        TemplateParameter OwningTemplateParameter { get; }
        #endregion
        #region P:TemplateParameter:TemplateParameter
        /// <summary>
        /// The <see cref="TemplateParameter"/> that exposes this <see cref="ParameterableElement"/> as a formal parameter.
        /// </summary>
        /// xmi:id="ParameterableElement-templateParameter"
        /// xmi:association="A_parameteredElement_templateParameter"
        [Multiplicity("0..1")]
        TemplateParameter TemplateParameter { get; }
        #endregion

        #region M:isCompatibleWith(ParameterableElement):Boolean
        /// <summary>
        /// The query <see cref="isCompatibleWith"/> determines if this <see cref="ParameterableElement"/> is compatible with the specified <see cref="ParameterableElement"/>. By default, this <see cref="ParameterableElement"/> is compatible with another <see cref="ParameterableElement"/> p if the kind of this <see cref="ParameterableElement"/> is the same as or a subtype of the kind of p. Subclasses of <see cref="ParameterableElement"/> should override this operation to specify different compatibility constraints.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.oclIsKindOf(p.oclType()))
        ///   ]]>
        ///   xmi:id="ParameterableElement-isCompatibleWith-spec"
        /// </rule>
        /// xmi:id="ParameterableElement-isCompatibleWith"
        /// xmi:is-query="true"
        Boolean isCompatibleWith(ParameterableElement p);
        #endregion
        #region M:isTemplateParameter:Boolean
        /// <summary>
        /// The query <see cref="isTemplateParameter"/> determines if this <see cref="ParameterableElement"/> is exposed as a formal <see cref="TemplateParameter"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (templateParameter->notEmpty())
        ///   ]]>
        ///   xmi:id="ParameterableElement-isTemplateParameter-spec"
        /// </rule>
        /// xmi:id="ParameterableElement-isTemplateParameter"
        /// xmi:is-query="true"
        Boolean isTemplateParameter();
        #endregion
        }
    }
