using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="RedefinableTemplateSignature"/> supports the addition of formal <see cref="Template"/> parameters in a specialization of a <see cref="Template"/> <see cref="Classifier"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   If any of the parent Classifiers are a template, then the extendedSignature must include the signature of that <see cref="Classifier"/>.
    ///   <![CDATA[
    ///     classifier.allParents()->forAll(c | c.ownedTemplateSignature->notEmpty() implies self->closure(extendedSignature)->includes(c.ownedTemplateSignature))
    ///   ]]>
    ///   xmi:id="RedefinableTemplateSignature-redefines_parents"
    /// </rule>
    /// xmi:id="RedefinableTemplateSignature"
    public interface RedefinableTemplateSignature : RedefinableElement,TemplateSignature
        {
        #region P:Classifier:Classifier
        /// <summary>
        /// The <see cref="Classifier"/> that owns this <see cref="RedefinableTemplateSignature"/>.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.TemplateSignature.Template"/>"
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.RedefinitionContext"/>"
        /// </summary>
        /// xmi:id="RedefinableTemplateSignature-classifier"
        /// xmi:association="A_ownedTemplateSignature_classifier"
        Classifier Classifier { get; }
        #endregion
        #region P:ExtendedSignature:RedefinableTemplateSignature[]
        /// <summary>
        /// The signatures extended by this <see cref="RedefinableTemplateSignature"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.RedefinedElement"/>"
        /// </summary>
        /// xmi:id="RedefinableTemplateSignature-extendedSignature"
        /// xmi:association="A_extendedSignature_redefinableTemplateSignature"
        RedefinableTemplateSignature[] ExtendedSignature { get; }
        #endregion
        #region P:InheritedParameter:TemplateParameter[]
        /// <summary>
        /// The formal <see cref="Template"/> parameters of the extended signatures.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.TemplateSignature.Parameter"/>"
        /// </summary>
        /// xmi:id="RedefinableTemplateSignature-inheritedParameter"
        /// xmi:association="A_inheritedParameter_redefinableTemplateSignature"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        TemplateParameter[] InheritedParameter { get; }
        #endregion

        #region M:inheritedParameter:TemplateParameter[]
        /// <summary>
        /// Derivation for <see cref="RedefinableTemplateSignature"/>::/<see cref="InheritedParameter"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if extendedSignature->isEmpty() then Set{} else extendedSignature.parameter->asSet() endif)
        ///   ]]>
        ///   xmi:id="RedefinableTemplateSignature-inheritedParameter.1-spec"
        /// </rule>
        /// xmi:id="RedefinableTemplateSignature-inheritedParameter.1"
        /// xmi:is-query="true"
        TemplateParameter[] inheritedParameter();
        #endregion
        #region M:isConsistentWith(RedefinableElement):Boolean
        /// <summary>
        /// The query <see cref="isConsistentWith"/> specifies, for any two RedefinableTemplateSignatures in a context in which redefinition is possible, whether redefinition would be logically consistent. A redefining <see cref="Template"/> signature is always consistent with a redefined <see cref="Template"/> signature, as redefinition only adds new formal parameters.
        /// Redefines:
        ///   <see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.isConsistentWith"/>"
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (redefiningElement.oclIsKindOf(RedefinableTemplateSignature))
        ///   ]]>
        ///   xmi:id="RedefinableTemplateSignature-isConsistentWith-spec"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     redefiningElement.isRedefinitionContextValid(self)
        ///   ]]>
        ///   xmi:id="RedefinableTemplateSignature-isConsistentWith-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// xmi:id="RedefinableTemplateSignature-isConsistentWith"
        /// xmi:is-query="true"
        Boolean isConsistentWith(RedefinableElement redefiningElement);
        #endregion
        }
    }
