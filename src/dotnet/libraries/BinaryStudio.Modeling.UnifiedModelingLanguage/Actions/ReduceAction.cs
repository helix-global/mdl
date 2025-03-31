using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ReduceAction"/> is an <see cref="Action"/> that reduces a <see cref="Collection"/> to a single value by repeatedly combining the elements of the <see cref="Collection"/> using a <see cref="Reducer"/> <see cref="Behavior"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The reducer <see cref="Behavior"/> must have two input ownedParameters and one output ownedParameter, where the type of the output <see cref="Parameter"/> and the type of elements of the input collection conform to the types of the input Parameters.
    ///   <![CDATA[
    ///     let inputs: OrderedSet(Parameter) = reducer.inputParameters() in
    ///     let outputs: OrderedSet(Parameter) = reducer.outputParameters() in
    ///     inputs->size()=2 and outputs->size()=1 and
    ///     inputs.type->forAll(t | 
    ///     	outputs.type->forAll(conformsTo(t)) and 
    ///     	-- Note that the following only checks the case when the collection is via multiple tokens.
    ///     	collection.upperBound()>1 implies collection.type.conformsTo(t))
    ///   ]]>
    ///   xmi:id="ReduceAction-reducer_inputs_output"
    /// </rule>
    /// <rule language="">
    ///   The type of the collection <see cref="InputPin"/> must be a collection.
    ///   xmi:id="ReduceAction-input_type_is_collection"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the output of the reducer <see cref="Behavior"/> must conform to the type of the result <see cref="OutputPin"/>.
    ///   <![CDATA[
    ///     reducer.outputParameters().type->forAll(conformsTo(result.type))
    ///   ]]>
    ///   xmi:id="ReduceAction-output_types_are_compatible"
    /// </rule>
    /// xmi:id="ReduceAction"
    public interface ReduceAction : Action
        {
        #region P:Collection:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> that provides the <see cref="Collection"/> to be reduced.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Input"/>"
        /// </summary>
        /// xmi:id="ReduceAction-collection"
        /// xmi:aggregation="composite"
        /// xmi:association="A_collection_reduceAction"
        InputPin Collection { get; }
        #endregion
        #region P:IsOrdered:Boolean
        /// <summary>
        /// Indicates whether the order of the <see cref="Input"/> <see cref="Collection"/> should determine the order in which the <see cref="Reducer"/> <see cref="Behavior"/> is applied to its elements.
        /// </summary>
        /// xmi:id="ReduceAction-isOrdered"
        Boolean IsOrdered { get; }
        #endregion
        #region P:Reducer:Behavior
        /// <summary>
        /// A <see cref="Behavior"/> that is repreatedly applied to two elements of the <see cref="Input"/> <see cref="Collection"/> to produce a value that is of the same type as elements of the <see cref="Collection"/>.
        /// </summary>
        /// xmi:id="ReduceAction-reducer"
        /// xmi:association="A_reducer_reduceAction"
        Behavior Reducer { get; }
        #endregion
        #region P:Result:OutputPin
        /// <summary>
        /// The <see cref="Output"/> pin on which the <see cref="Result"/> value is placed.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Output"/>"
        /// </summary>
        /// xmi:id="ReduceAction-result"
        /// xmi:aggregation="composite"
        /// xmi:association="A_result_reduceAction"
        OutputPin Result { get; }
        #endregion
        }
    }
