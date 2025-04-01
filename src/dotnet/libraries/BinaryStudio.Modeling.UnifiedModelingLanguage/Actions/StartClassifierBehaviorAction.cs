using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="StartClassifierBehaviorAction"/> is an <see cref="Action"/> that starts the classifierBehavior of the <see cref="Input"/> <see cref="Object"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The multiplicity of the object <see cref="InputPin"/> is 1..1
    ///   <![CDATA[
    ///     object.is(1,1)
    ///   ]]>
    ///   xmi:id="StartClassifierBehaviorAction-multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   If the <see cref="InputPin"/> has a type, then the type or one of its ancestors must have a classifierBehavior.
    ///   <![CDATA[
    ///     object.type->notEmpty() implies 
    ///        (object.type.oclIsKindOf(BehavioredClassifier) and object.type.oclAsType(BehavioredClassifier).classifierBehavior<>null)
    ///   ]]>
    ///   xmi:id="StartClassifierBehaviorAction-type_has_classifier"
    /// </rule>
    /// xmi:id="StartClassifierBehaviorAction"
    public interface StartClassifierBehaviorAction : Action
        {
        #region P:Object:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> that holds the <see cref="Object"/> whose classifierBehavior is to be started.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="StartClassifierBehaviorAction-object"
        /// xmi:aggregation="composite"
        /// xmi:association="A_object_startClassifierBehaviorAction"
        InputPin Object { get;set; }
        #endregion
        }
    }
