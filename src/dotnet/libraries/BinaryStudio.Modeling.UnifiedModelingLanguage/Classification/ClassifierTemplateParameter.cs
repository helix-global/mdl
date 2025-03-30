using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ClassifierTemplateParameter"/> exposes a <see cref="Classifier"/> as a formal template parameter.
    /// </summary>
    /// <rule language="OCL">
    ///   If allowSubstitutable is true, then there must be a constrainingClassifier.
    ///   <![CDATA[
    ///     allowSubstitutable implies constrainingClassifier->notEmpty()
    ///   ]]>
    ///   xmi:id="ClassifierTemplateParameter-has_constraining_classifier"
    /// </rule>
    /// <rule language="OCL">
    ///   The parameteredElement has no direct features, and if constrainedElement is empty it has no generalizations.
    ///   <![CDATA[
    ///     parameteredElement.feature->isEmpty() and (constrainingClassifier->isEmpty() implies  parameteredElement.allParents()->isEmpty())
    ///   ]]>
    ///   xmi:id="ClassifierTemplateParameter-parametered_element_no_features"
    /// </rule>
    /// <rule language="OCL">
    ///   If the parameteredElement is not abstract, then the <see cref="Classifier"/> used as an argument shall not be abstract.
    ///   <![CDATA[
    ///     (not parameteredElement.isAbstract) implies templateParameterSubstitution.actual->forAll(a | not a.oclAsType(Classifier).isAbstract)
    ///   ]]>
    ///   xmi:id="ClassifierTemplateParameter-matching_abstract"
    /// </rule>
    /// <rule language="OCL">
    ///   The argument to a <see cref="ClassifierTemplateParameter"/> is a <see cref="Classifier"/>.
    ///   <![CDATA[
    ///      templateParameterSubstitution.actual->forAll(a | a.oclIsKindOf(Classifier))
    ///   ]]>
    ///   xmi:id="ClassifierTemplateParameter-actual_is_classifier"
    /// </rule>
    /// <rule language="OCL">
    ///   If there are any constrainingClassifiers, then every argument must be the same as or a specialization of them, or if allowSubstitutable is true, then it can also be substitutable.
    ///   <![CDATA[
    ///     templateParameterSubstitution.actual->forAll( a |
    ///       let arg : Classifier = a.oclAsType(Classifier) in
    ///         constrainingClassifier->forAll(
    ///           cc |  
    ///              arg = cc or arg.conformsTo(cc) or (allowSubstitutable and arg.isSubstitutableFor(cc))
    ///           )
    ///     )
    ///   ]]>
    ///   xmi:id="ClassifierTemplateParameter-constraining_classifiers_constrain_args"
    /// </rule>
    /// <rule language="OCL">
    ///   If there are any constrainingClassifiers, then the parameteredElement must be the same as or a specialization of them, or if allowSubstitutable is true, then it can also be substitutable.
    ///   <![CDATA[
    ///     constrainingClassifier->forAll(
    ///          cc |  parameteredElement = cc or parameteredElement.conformsTo(cc) or (allowSubstitutable and parameteredElement.isSubstitutableFor(cc))
    ///     )
    ///     
    ///   ]]>
    ///   xmi:id="ClassifierTemplateParameter-constraining_classifiers_constrain_parametered_element"
    /// </rule>
    /// xmi:id="ClassifierTemplateParameter"
    public interface ClassifierTemplateParameter : TemplateParameter
        {
        #region P:AllowSubstitutable:Boolean
        /// <summary>
        /// Constrains the required relationship between an actual parameter and the <see cref="ParameteredElement"/> for this formal parameter.
        /// </summary>
        /// xmi:id="ClassifierTemplateParameter-allowSubstitutable"
        Boolean AllowSubstitutable { get; }
        #endregion
        #region P:ConstrainingClassifier:Classifier[]
        /// <summary>
        /// The classifiers that constrain the argument that can be used for the parameter. If the <see cref="AllowSubstitutable"/> attribute is true, then any <see cref="Classifier"/> that is compatible with this constraining <see cref="Classifier"/> can be substituted; otherwise, it must be either this <see cref="Classifier"/> or one of its specializations. If this property is empty, there are no constraints on the <see cref="Classifier"/> that can be used as an argument.
        /// </summary>
        /// xmi:id="ClassifierTemplateParameter-constrainingClassifier"
        Classifier[] ConstrainingClassifier { get; }
        #endregion
        #region P:ParameteredElement:Classifier
        /// <summary>
        /// The <see cref="Classifier"/> exposed by this <see cref="ClassifierTemplateParameter"/>.
        /// </summary>
        /// xmi:id="ClassifierTemplateParameter-parameteredElement"
        /// xmi:redefines="TemplateParameter-parameteredElement{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.TemplateParameter.ParameteredElement"/>}"
        Classifier ParameteredElement { get; }
        #endregion
        }
    }
