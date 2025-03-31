using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    using Integer=Int32;

    /// <summary>
    /// An <see cref="Operation"/> is a <see cref="BehavioralFeature"/> of a <see cref="Classifier"/> that specifies the <see cref="Name"/>, <see cref="Type"/>, parameters, and constraints for invoking an associated <see cref="Behavior"/>. An <see cref="Operation"/> may invoke both the execution of <see cref="Method"/> behaviors as well as other behavioral responses. <see cref="Operation"/> specializes <see cref="TemplateableElement"/> in order to support specification of template operations and bound operations. <see cref="Operation"/> specializes <see cref="ParameterableElement"/> to specify that an operation can be exposed as a formal template parameter, and provided as an actual parameter in a binding of a template.
    /// </summary>
    /// <rule language="OCL">
    ///   An <see cref="Operation"/> can have at most one return parameter; i.e., an owned parameter with the direction set to 'return.'
    ///   <![CDATA[
    ///     self.ownedParameter->select(direction = ParameterDirectionKind::return)->size() <= 1
    ///   ]]>
    ///   xmi:id="Operation-at_most_one_return"
    /// </rule>
    /// <rule language="OCL">
    ///   A bodyCondition can only be specified for a query <see cref="Operation"/>.
    ///   <![CDATA[
    ///     bodyCondition <> null implies isQuery
    ///   ]]>
    ///   xmi:id="Operation-only_body_for_query"
    /// </rule>
    /// xmi:id="Operation"
    public interface Operation : ParameterableElement,BehavioralFeature,TemplateableElement
        {
        #region P:BodyCondition:Constraint
        /// <summary>
        /// An optional <see cref="Constraint"/> on the result values of an invocation of this <see cref="Operation"/>.
        /// </summary>
        /// xmi:id="Operation-bodyCondition"
        /// xmi:aggregation="composite"
        /// xmi:association="A_bodyCondition_bodyContext"
        /// xmi:subsets="Namespace-ownedRule"
        [Multiplicity("0..1")]
        Constraint BodyCondition { get; }
        #endregion
        #region P:Class:Class
        /// <summary>
        /// The <see cref="Class"/> that owns this operation, if any.
        /// </summary>
        /// xmi:id="Operation-class"
        /// xmi:association="A_ownedOperation_class"
        /// xmi:subsets="Feature-featuringClassifier"
        /// xmi:subsets="NamedElement-namespace"
        /// xmi:subsets="RedefinableElement-redefinitionContext"
        [Multiplicity("0..1")]
        Class Class { get; }
        #endregion
        #region P:Datatype:DataType
        /// <summary>
        /// The <see cref="DataType"/> that owns this <see cref="Operation"/>, if any.
        /// </summary>
        /// xmi:id="Operation-datatype"
        /// xmi:association="A_ownedOperation_datatype"
        /// xmi:subsets="Feature-featuringClassifier"
        /// xmi:subsets="NamedElement-namespace"
        /// xmi:subsets="RedefinableElement-redefinitionContext"
        [Multiplicity("0..1")]
        DataType Datatype { get; }
        #endregion
        #region P:Interface:Interface
        /// <summary>
        /// The <see cref="Interface"/> that owns this <see cref="Operation"/>, if any.
        /// </summary>
        /// xmi:id="Operation-interface"
        /// xmi:association="A_ownedOperation_interface"
        /// xmi:subsets="Feature-featuringClassifier"
        /// xmi:subsets="NamedElement-namespace"
        /// xmi:subsets="RedefinableElement-redefinitionContext"
        [Multiplicity("0..1")]
        Interface Interface { get; }
        #endregion
        #region P:IsOrdered:Boolean
        /// <summary>
        /// Specifies whether the return parameter is ordered or not, if present.  This information is derived from the return result for this <see cref="Operation"/>.
        /// </summary>
        /// xmi:id="Operation-isOrdered"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        Boolean IsOrdered { get; }
        #endregion
        #region P:IsQuery:Boolean
        /// <summary>
        /// Specifies whether an execution of the <see cref="BehavioralFeature"/> leaves the state of the system unchanged (<see cref="IsQuery"/>=true) or whether side effects may occur (<see cref="IsQuery"/>=false).
        /// </summary>
        /// xmi:id="Operation-isQuery"
        Boolean IsQuery { get; }
        #endregion
        #region P:IsUnique:Boolean
        /// <summary>
        /// Specifies whether the return parameter is unique or not, if present. This information is derived from the return result for this <see cref="Operation"/>.
        /// </summary>
        /// xmi:id="Operation-isUnique"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        Boolean IsUnique { get; }
        #endregion
        #region P:Lower:Integer
        /// <summary>
        /// Specifies the <see cref="Lower"/> multiplicity of the return parameter, if present. This information is derived from the return result for this <see cref="Operation"/>.
        /// </summary>
        /// xmi:id="Operation-lower"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        [Multiplicity("0..1")]
        Integer Lower { get; }
        #endregion
        #region P:OwnedParameter:Parameter[]
        /// <summary>
        /// The parameters owned by this <see cref="Operation"/>.
        /// </summary>
        /// xmi:id="Operation-ownedParameter"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedParameter_operation"
        /// xmi:redefines="BehavioralFeature-ownedParameter{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.BehavioralFeature.OwnedParameter"/>}"
        [Ordered]
        Parameter[] OwnedParameter { get; }
        #endregion
        #region P:Postcondition:Constraint[]
        /// <summary>
        /// An optional set of Constraints specifying the state of the system when the <see cref="Operation"/> is completed.
        /// </summary>
        /// xmi:id="Operation-postcondition"
        /// xmi:aggregation="composite"
        /// xmi:association="A_postcondition_postContext"
        /// xmi:subsets="Namespace-ownedRule"
        Constraint[] Postcondition { get; }
        #endregion
        #region P:Precondition:Constraint[]
        /// <summary>
        /// An optional set of Constraints on the state of the system when the <see cref="Operation"/> is invoked.
        /// </summary>
        /// xmi:id="Operation-precondition"
        /// xmi:aggregation="composite"
        /// xmi:association="A_precondition_preContext"
        /// xmi:subsets="Namespace-ownedRule"
        Constraint[] Precondition { get; }
        #endregion
        #region P:RaisedException:Type[]
        /// <summary>
        /// The Types representing exceptions that may be raised during an invocation of this operation.
        /// </summary>
        /// xmi:id="Operation-raisedException"
        /// xmi:association="A_raisedException_operation"
        /// xmi:redefines="BehavioralFeature-raisedException{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.BehavioralFeature.RaisedException"/>}"
        Type[] RaisedException { get; }
        #endregion
        #region P:RedefinedOperation:Operation[]
        /// <summary>
        /// The Operations that are redefined by this <see cref="Operation"/>.
        /// </summary>
        /// xmi:id="Operation-redefinedOperation"
        /// xmi:association="A_redefinedOperation_operation"
        /// xmi:subsets="RedefinableElement-redefinedElement"
        Operation[] RedefinedOperation { get; }
        #endregion
        #region P:TemplateParameter:OperationTemplateParameter
        /// <summary>
        /// The <see cref="OperationTemplateParameter"/> that exposes this element as a formal parameter.
        /// </summary>
        /// xmi:id="Operation-templateParameter"
        /// xmi:association="A_operation_templateParameter_parameteredElement"
        /// xmi:redefines="ParameterableElement-templateParameter{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.ParameterableElement.TemplateParameter"/>}"
        [Multiplicity("0..1")]
        OperationTemplateParameter TemplateParameter { get; }
        #endregion
        #region P:Type:Type
        /// <summary>
        /// The return <see cref="Type"/> of the operation, if present. This information is derived from the return result for this <see cref="Operation"/>.
        /// </summary>
        /// xmi:id="Operation-type"
        /// xmi:association="A_type_operation"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        [Multiplicity("0..1")]
        Type Type { get; }
        #endregion
        #region P:Upper:UnlimitedNatural
        /// <summary>
        /// The <see cref="Upper"/> multiplicity of the return parameter, if present. This information is derived from the return result for this <see cref="Operation"/>.
        /// </summary>
        /// xmi:id="Operation-upper"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        [Multiplicity("0..1")]
        UnlimitedNatural Upper { get; }
        #endregion

        #region M:isConsistentWith(RedefinableElement):Boolean
        /// <summary>
        /// The query <see cref="isConsistentWith"/> specifies, for any two Operations in a context in which redefinition is possible, whether redefinition would be consistent. A redefining operation is consistent with a redefined operation if
        /// it has the same number of owned parameters, and for each parameter the following holds:
        /// 
        /// - Direction, ordering and uniqueness are the same.
        /// - The corresponding types are covariant, contravariant or invariant.
        /// - The multiplicities are compatible, depending on the parameter direction.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (redefiningElement.oclIsKindOf(Operation) and
        ///     let op : Operation = redefiningElement.oclAsType(Operation) in
        ///     	self.ownedParameter->size() = op.ownedParameter->size() and
        ///     	Sequence{1..self.ownedParameter->size()}->
        ///     		forAll(i |  
        ///     		  let redefiningParam : Parameter = op.ownedParameter->at(i),
        ///                    redefinedParam : Parameter = self.ownedParameter->at(i) in
        ///                      (redefiningParam.isUnique = redefinedParam.isUnique) and
        ///                      (redefiningParam.isOrdered = redefinedParam. isOrdered) and
        ///                      (redefiningParam.direction = redefinedParam.direction) and
        ///                      (redefiningParam.type.conformsTo(redefinedParam.type) or
        ///                          redefinedParam.type.conformsTo(redefiningParam.type)) and
        ///                      (redefiningParam.direction = ParameterDirectionKind::inout implies
        ///                              (redefinedParam.compatibleWith(redefiningParam) and
        ///                              redefiningParam.compatibleWith(redefinedParam))) and
        ///                      (redefiningParam.direction = ParameterDirectionKind::_'in' implies
        ///                              redefinedParam.compatibleWith(redefiningParam)) and
        ///                      ((redefiningParam.direction = ParameterDirectionKind::out or
        ///                           redefiningParam.direction = ParameterDirectionKind::return) implies
        ///                              redefiningParam.compatibleWith(redefinedParam))
        ///     		))
        ///   ]]>
        ///   xmi:id="Operation-isConsistentWith-spec"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     redefiningElement.isRedefinitionContextValid(self)
        ///   ]]>
        ///   xmi:id="Operation-isConsistentWith-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// xmi:id="Operation-isConsistentWith"
        /// xmi:is-query="true"
        /// xmi:redefines="RedefinableElement-isConsistentWith{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.isConsistentWith"/>}"
        Boolean isConsistentWith(RedefinableElement redefiningElement);
        #endregion
        #region M:isOrdered:Boolean
        /// <summary>
        /// If this operation has a return parameter, <see cref="IsOrdered"/> equals the value of <see cref="IsOrdered"/> for that parameter. Otherwise <see cref="IsOrdered"/> is false.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if returnResult()->notEmpty() then returnResult()-> exists(isOrdered) else false endif)
        ///   ]]>
        ///   xmi:id="Operation-isOrdered.1-spec"
        /// </rule>
        /// xmi:id="Operation-isOrdered.1"
        /// xmi:is-query="true"
        Boolean isOrdered();
        #endregion
        #region M:isUnique:Boolean
        /// <summary>
        /// If this operation has a return parameter, <see cref="IsUnique"/> equals the value of <see cref="IsUnique"/> for that parameter. Otherwise <see cref="IsUnique"/> is true.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if returnResult()->notEmpty() then returnResult()->exists(isUnique) else true endif)
        ///   ]]>
        ///   xmi:id="Operation-isUnique.1-spec"
        /// </rule>
        /// xmi:id="Operation-isUnique.1"
        /// xmi:is-query="true"
        Boolean isUnique();
        #endregion
        #region M:lower:Integer
        /// <summary>
        /// If this operation has a return parameter, <see cref="Lower"/> equals the value of <see cref="Lower"/> for that parameter. Otherwise <see cref="Lower"/> has no value.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if returnResult()->notEmpty() then returnResult()->any(true).lower else null endif)
        ///   ]]>
        ///   xmi:id="Operation-lower.1-spec"
        /// </rule>
        /// xmi:id="Operation-lower.1"
        /// xmi:is-query="true"
        Integer lower();
        #endregion
        #region M:returnResult:Parameter[]
        /// <summary>
        /// The query <see cref="returnResult"/> returns the set containing the return parameter of the <see cref="Operation"/> if one exists, otherwise, it returns an empty set
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (ownedParameter->select (direction = ParameterDirectionKind::return))
        ///   ]]>
        ///   xmi:id="Operation-returnResult-spec"
        /// </rule>
        /// xmi:id="Operation-returnResult"
        /// xmi:is-query="true"
        Parameter[] returnResult();
        #endregion
        #region M:type:Type
        /// <summary>
        /// If this operation has a return parameter, <see cref="Type"/> equals the value of <see cref="Type"/> for that parameter. Otherwise <see cref="Type"/> has no value.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if returnResult()->notEmpty() then returnResult()->any(true).type else null endif)
        ///   ]]>
        ///   xmi:id="Operation-type.1-spec"
        /// </rule>
        /// xmi:id="Operation-type.1"
        /// xmi:is-query="true"
        Type type();
        #endregion
        #region M:upper:UnlimitedNatural
        /// <summary>
        /// If this operation has a return parameter, <see cref="Upper"/> equals the value of <see cref="Upper"/> for that parameter. Otherwise <see cref="Upper"/> has no value.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if returnResult()->notEmpty() then returnResult()->any(true).upper else null endif)
        ///   ]]>
        ///   xmi:id="Operation-upper.1-spec"
        /// </rule>
        /// xmi:id="Operation-upper.1"
        /// xmi:is-query="true"
        UnlimitedNatural upper();
        #endregion
        }
    }
