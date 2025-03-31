using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ParameterSet"/> designates alternative sets of inputs or outputs that a <see cref="Behavior"/> may use.
    /// </summary>
    /// <rule language="OCL">
    ///   The Parameters in a <see cref="ParameterSet"/> must all be inputs or all be outputs of the same parameterized entity, and the <see cref="ParameterSet"/> is owned by that entity.
    ///   <![CDATA[
    ///     parameter->forAll(p1, p2 | self.owner = p1.owner and self.owner = p2.owner and p1.direction = p2.direction)
    ///   ]]>
    ///   xmi:id="ParameterSet-same_parameterized_entity"
    /// </rule>
    /// <rule language="OCL">
    ///   If a parameterized entity has input Parameters that are in a <see cref="ParameterSet"/>, then any inputs that are not in a <see cref="ParameterSet"/> must be streaming. Same for output Parameters.
    ///   <![CDATA[
    ///     ((parameter->exists(direction = ParameterDirectionKind::_'in')) implies 
    ///         behavioralFeature.ownedParameter->select(p | p.direction = ParameterDirectionKind::_'in' and p.parameterSet->isEmpty())->forAll(isStream))
    ///         and
    ///     ((parameter->exists(direction = ParameterDirectionKind::out)) implies 
    ///         behavioralFeature.ownedParameter->select(p | p.direction = ParameterDirectionKind::out and p.parameterSet->isEmpty())->forAll(isStream))  
    ///     
    ///   ]]>
    ///   xmi:id="ParameterSet-input"
    /// </rule>
    /// <rule language="OCL">
    ///   Two ParameterSets cannot have exactly the same set of Parameters.
    ///   <![CDATA[
    ///     parameter->forAll(parameterSet->forAll(s1, s2 | s1->size() = s2->size() implies s1.parameter->exists(p | not s2.parameter->includes(p))))
    ///   ]]>
    ///   xmi:id="ParameterSet-two_parameter_sets"
    /// </rule>
    /// xmi:id="ParameterSet"
    public interface ParameterSet : NamedElement
        {
        #region P:Condition:Constraint[]
        /// <summary>
        /// A constraint that should be satisfied for the <see cref="Owner"/> of the Parameters in an input <see cref="ParameterSet"/> to start execution using the values provided for those Parameters, or the <see cref="Owner"/> of the Parameters in an output <see cref="ParameterSet"/> to end execution providing the values for those Parameters, if all preconditions and conditions on input ParameterSets were satisfied.
        /// </summary>
        /// xmi:id="ParameterSet-condition"
        /// xmi:aggregation="composite"
        /// xmi:association="A_condition_parameterSet"
        /// xmi:subsets="Element-ownedElement"
        Constraint[] Condition { get; }
        #endregion
        #region P:Parameter:Parameter[]
        /// <summary>
        /// Parameters in the <see cref="ParameterSet"/>.
        /// </summary>
        /// xmi:id="ParameterSet-parameter"
        /// xmi:association="A_parameterSet_parameter"
        [Multiplicity("1..*")]
        Parameter[] Parameter { get; }
        #endregion
        }
    }
