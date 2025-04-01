using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ReclassifyObjectAction"/> is an <see cref="Action"/> that changes the Classifiers that classify an <see cref="Object"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The object <see cref="InputPin"/> has no type.
    ///   <![CDATA[
    ///     object.type = null
    ///   ]]>
    ///   xmi:id="ReclassifyObjectAction-input_pin"
    /// </rule>
    /// <rule language="OCL">
    ///   None of the newClassifiers may be abstract.
    ///   <![CDATA[
    ///     not newClassifier->exists(isAbstract)
    ///   ]]>
    ///   xmi:id="ReclassifyObjectAction-classifier_not_abstract"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the object <see cref="InputPin"/> is 1..1.
    ///   <![CDATA[
    ///     object.is(1,1)
    ///   ]]>
    ///   xmi:id="ReclassifyObjectAction-multiplicity"
    /// </rule>
    /// xmi:id="ReclassifyObjectAction"
    public interface ReclassifyObjectAction : Action
        {
        #region P:IsReplaceAll:Boolean
        /// <summary>
        /// Specifies whether existing Classifiers should be removed before adding the new Classifiers.
        /// </summary>
        /// xmi:id="ReclassifyObjectAction-isReplaceAll"
        Boolean IsReplaceAll { get;set; }
        #endregion
        #region P:NewClassifier:IList<Classifier>
        /// <summary>
        /// A set of Classifiers to be added to the Classifiers of the given <see cref="Object"/>.
        /// </summary>
        /// xmi:id="ReclassifyObjectAction-newClassifier"
        /// xmi:association="A_newClassifier_reclassifyObjectAction"
        IList<Classifier> NewClassifier { get; }
        #endregion
        #region P:Object:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> that holds the <see cref="Object"/> to be reclassified.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="ReclassifyObjectAction-object"
        /// xmi:aggregation="composite"
        /// xmi:association="A_object_reclassifyObjectAction"
        InputPin Object { get;set; }
        #endregion
        #region P:OldClassifier:IList<Classifier>
        /// <summary>
        /// A set of Classifiers to be removed from the Classifiers of the given <see cref="Object"/>.
        /// </summary>
        /// xmi:id="ReclassifyObjectAction-oldClassifier"
        /// xmi:association="A_oldClassifier_reclassifyObjectAction"
        IList<Classifier> OldClassifier { get; }
        #endregion
        }
    }
