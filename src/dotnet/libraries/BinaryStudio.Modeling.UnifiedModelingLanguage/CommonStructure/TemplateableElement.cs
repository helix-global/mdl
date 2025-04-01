using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="TemplateableElement"/> is an <see cref="Element"/> that can optionally be defined as a template and bound to other templates.
    /// </summary>
    /// xmi:id="TemplateableElement"
    public interface TemplateableElement : Element
        {
        #region P:OwnedTemplateSignature:TemplateSignature
        /// <summary>
        /// The optional <see cref="TemplateSignature"/> specifying the formal TemplateParameters for this <see cref="TemplateableElement"/>. If a <see cref="TemplateableElement"/> has a <see cref="TemplateSignature"/>, then it is a template.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="TemplateableElement-ownedTemplateSignature"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedTemplateSignature_template"
        [Multiplicity("0..1")]
        TemplateSignature OwnedTemplateSignature { get;set; }
        #endregion
        #region P:TemplateBinding:IList<TemplateBinding>
        /// <summary>
        /// The optional TemplateBindings from this <see cref="TemplateableElement"/> to one or more templates.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="TemplateableElement-templateBinding"
        /// xmi:aggregation="composite"
        /// xmi:association="A_templateBinding_boundElement"
        /// xmi:subsets="A_source_directedRelationship-directedRelationship"
        IList<TemplateBinding> TemplateBinding { get; }
        #endregion

        #region M:isTemplate:Boolean
        /// <summary>
        /// The query <see cref="isTemplate"/> returns whether this <see cref="TemplateableElement"/> is actually a template.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (ownedTemplateSignature <> null)
        ///   ]]>
        ///   xmi:id="TemplateableElement-isTemplate-spec"
        /// </rule>
        /// xmi:id="TemplateableElement-isTemplate"
        /// xmi:is-query="true"
        Boolean isTemplate();
        #endregion
        #region M:parameterableElements:ParameterableElement[]
        /// <summary>
        /// The query <see cref="parameterableElements"/> returns the set of ParameterableElements that may be used as the parameteredElements for a <see cref="TemplateParameter"/> of this <see cref="TemplateableElement"/>. By default, this set includes all the ownedElements. Subclasses may override this operation if they choose to restrict the set of ParameterableElements.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.allOwnedElements()->select(oclIsKindOf(ParameterableElement)).oclAsType(ParameterableElement)->asSet())
        ///   ]]>
        ///   xmi:id="TemplateableElement-parameterableElements-spec"
        /// </rule>
        /// xmi:id="TemplateableElement-parameterableElements"
        /// xmi:is-query="true"
        ParameterableElement[] parameterableElements();
        #endregion
        }
    }
