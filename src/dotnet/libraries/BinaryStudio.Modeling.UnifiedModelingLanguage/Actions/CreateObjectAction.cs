using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="CreateObjectAction"/> is an <see cref="Action"/> that creates an instance of the specified <see cref="Classifier"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The classifier cannot be abstract.
    ///   <![CDATA[
    ///     not classifier.isAbstract 
    ///   ]]>
    ///   xmi:id="CreateObjectAction-classifier_not_abstract"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the result <see cref="OutputPin"/> is 1..1.
    ///   <![CDATA[
    ///     result.is(1,1)
    ///   ]]>
    ///   xmi:id="CreateObjectAction-multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   The classifier cannot be an <see cref="AssociationClass"/>.
    ///   <![CDATA[
    ///     not classifier.oclIsKindOf(AssociationClass)
    ///   ]]>
    ///   xmi:id="CreateObjectAction-classifier_not_association_class"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the result <see cref="OutputPin"/> must be the same as the classifier of the <see cref="CreateObjectAction"/>.
    ///   <![CDATA[
    ///     result.type = classifier
    ///   ]]>
    ///   xmi:id="CreateObjectAction-same_type"
    /// </rule>
    /// xmi:id="CreateObjectAction"
    public interface CreateObjectAction : Action
        {
        #region P:Classifier:Classifier
        /// <summary>
        /// The <see cref="Classifier"/> to be instantiated.
        /// </summary>
        /// xmi:id="CreateObjectAction-classifier"
        /// xmi:association="A_classifier_createObjectAction"
        Classifier Classifier { get; }
        #endregion
        #region P:Result:OutputPin
        /// <summary>
        /// The <see cref="OutputPin"/> on which the newly created object is placed.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Output"/>"
        /// </summary>
        /// xmi:id="CreateObjectAction-result"
        /// xmi:aggregation="composite"
        /// xmi:association="A_result_createObjectAction"
        OutputPin Result { get; }
        #endregion
        }
    }
