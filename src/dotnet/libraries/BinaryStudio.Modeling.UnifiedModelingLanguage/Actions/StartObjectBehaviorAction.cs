using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="StartObjectBehaviorAction"/> is an <see cref="InvocationAction"/> that starts the execution either of a directly instantiated <see cref="Behavior"/> or of the classifierBehavior of an <see cref="Object"/>. Argument values may be supplied for the <see cref="Input"/> Parameters of the <see cref="Behavior"/>. If the <see cref="Behavior"/> is invoked synchronously, then <see cref="Output"/> values may be obtained for <see cref="Output"/> Parameters.
    /// </summary>
    /// <rule language="OCL">
    ///   The multiplicity of the object <see cref="InputPin"/> must be 1..1.
    ///   <![CDATA[
    ///     object.is(1,1)
    ///   ]]>
    ///   xmi:id="StartObjectBehaviorAction-multiplicity_of_object"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the object <see cref="InputPin"/> must be either a <see cref="Behavior"/> or a <see cref="BehavioredClassifier"/> with a classifierBehavior.
    ///   <![CDATA[
    ///     self.behavior()<>null
    ///   ]]>
    ///   xmi:id="StartObjectBehaviorAction-type_of_object"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="StartObjectBehaviorAction"/> may not specify onPort.
    ///   <![CDATA[
    ///     onPort->isEmpty()
    ///   ]]>
    ///   xmi:id="StartObjectBehaviorAction-no_onport"
    /// </rule>
    /// xmi:id="StartObjectBehaviorAction"
    public interface StartObjectBehaviorAction : CallAction
        {
        #region P:Object:InputPin
        /// <summary>
        /// An <see cref="InputPin"/> that holds the <see cref="Object"/> that is either a <see cref="Behavior"/> to be started or has a classifierBehavior to be started.
        /// </summary>
        /// xmi:id="StartObjectBehaviorAction-object"
        /// xmi:aggregation="composite"
        /// xmi:association="A_object_startObjectBehaviorAction"
        /// xmi:subsets="Action-input"
        InputPin Object { get; }
        #endregion

        #region M:behavior:Behavior
        /// <summary>
        /// If the type of the <see cref="Object"/> <see cref="InputPin"/> is a <see cref="Behavior"/>, then that <see cref="Behavior"/>. Otherwise, if the type of the <see cref="Object"/> <see cref="InputPin"/> is a <see cref="BehavioredClassifier"/>, then the classifierBehavior of that <see cref="BehavioredClassifier"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if object.type.oclIsKindOf(Behavior) then
        ///       object.type.oclAsType(Behavior)
        ///     else if object.type.oclIsKindOf(BehavioredClassifier) then
        ///       object.type.oclAsType(BehavioredClassifier).classifierBehavior
        ///     else
        ///       null
        ///     endif
        ///     endif)
        ///   ]]>
        ///   xmi:id="StartObjectBehaviorAction-behavior-spec"
        /// </rule>
        /// xmi:id="StartObjectBehaviorAction-behavior"
        /// xmi:is-query="true"
        Behavior behavior();
        #endregion
        #region M:inputParameters:Parameter[]
        /// <summary>
        /// Return the in and inout ownedParameters of the <see cref="Behavior"/> being called.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.behavior().inputParameters())
        ///   ]]>
        ///   xmi:id="StartObjectBehaviorAction-inputParameters-spec"
        /// </rule>
        /// xmi:id="StartObjectBehaviorAction-inputParameters"
        /// xmi:is-query="true"
        /// xmi:redefines="CallAction-inputParameters{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.CallAction.inputParameters"/>}"
        Parameter[] inputParameters();
        #endregion
        #region M:outputParameters:Parameter[]
        /// <summary>
        /// Return the inout, out and return ownedParameters of the <see cref="Behavior"/> being called.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.behavior().outputParameters())
        ///   ]]>
        ///   xmi:id="StartObjectBehaviorAction-outputParameters-spec"
        /// </rule>
        /// xmi:id="StartObjectBehaviorAction-outputParameters"
        /// xmi:is-query="true"
        /// xmi:redefines="CallAction-outputParameters{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.CallAction.outputParameters"/>}"
        Parameter[] outputParameters();
        #endregion
        }
    }
