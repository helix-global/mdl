using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="ObjectFlow"/> is an <see cref="ActivityEdge"/> that is traversed by object tokens that may hold values. Object flows also support multicast/receive, token <see cref="Selection"/> from object nodes, and <see cref="Transformation"/> of tokens.
    /// </summary>
    /// <rule language="OCL">
    ///   A selection <see cref="Behavior"/> has one input <see cref="Parameter"/> and one output <see cref="Parameter"/>. The input <see cref="Parameter"/> must have the same as or a supertype of the type of the source <see cref="ObjectNode"/>, be non-unique and have multiplicity 0..*. The output <see cref="Parameter"/> must be the same or a subtype of the type of source <see cref="ObjectNode"/>. The <see cref="Behavior"/> cannot have side effects.
    ///   <![CDATA[
    ///     selection<>null implies
    ///     	selection.inputParameters()->size()=1 and
    ///     	selection.inputParameters()->forAll(not isUnique and is(0,*)) and
    ///     	selection.outputParameters()->size()=1
    ///   ]]>
    ///   xmi:id="ObjectFlow-input_and_output_parameter"
    /// </rule>
    /// <rule language="OCL">
    ///   ObjectFlows may not have ExecutableNodes at either end.
    ///   <![CDATA[
    ///     not (source.oclIsKindOf(ExecutableNode) or target.oclIsKindOf(ExecutableNode))
    ///   ]]>
    ///   xmi:id="ObjectFlow-no_executable_nodes"
    /// </rule>
    /// <rule language="OCL">
    ///   A transformation <see cref="Behavior"/> has one input <see cref="Parameter"/> and one output <see cref="Parameter"/>. The input <see cref="Parameter"/> must be the same as or a supertype of the type of object token coming from the source end. The output <see cref="Parameter"/> must be the same or a subtype of the type of object token expected downstream. The <see cref="Behavior"/> cannot have side effects.
    ///   <![CDATA[
    ///     transformation<>null implies
    ///     	transformation.inputParameters()->size()=1 and
    ///     	transformation.outputParameters()->size()=1
    ///   ]]>
    ///   xmi:id="ObjectFlow-transformation_behavior"
    /// </rule>
    /// <rule language="OCL">
    ///   An <see cref="ObjectFlow"/> may have a selection <see cref="Behavior"/> only if it has an <see cref="ObjectNode"/> as its source.
    ///   <![CDATA[
    ///     selection<>null implies source.oclIsKindOf(ObjectNode)
    ///   ]]>
    ///   xmi:id="ObjectFlow-selection_behavior"
    /// </rule>
    /// <rule language="">
    ///   ObjectNodes connected by an <see cref="ObjectFlow"/>, with optionally intervening ControlNodes, must have compatible types. In particular, the downstream <see cref="ObjectNode"/> type must be the same or a supertype of the upstream <see cref="ObjectNode"/> type.
    ///   xmi:id="ObjectFlow-compatible_types"
    /// </rule>
    /// <rule language="">
    ///   ObjectNodes connected by an <see cref="ObjectFlow"/>, with optionally intervening ControlNodes, must have the same upperBounds.
    ///   xmi:id="ObjectFlow-same_upper_bounds"
    /// </rule>
    /// <rule language="">
    ///   An <see cref="ObjectFlow"/> with a constant weight may not target an <see cref="ObjectNode"/>, with optionally intervening ControlNodes, that has an upper bound less than the weight.
    ///   xmi:id="ObjectFlow-target"
    /// </rule>
    /// <rule language="OCL">
    ///   isMulticast and isMultireceive cannot both be true.
    ///   <![CDATA[
    ///     not (isMulticast and isMultireceive)
    ///   ]]>
    ///   xmi:id="ObjectFlow-is_multicast_or_is_multireceive"
    /// </rule>
    /// xmi:id="ObjectFlow"
    public interface ObjectFlow : ActivityEdge
        {
        #region P:IsMulticast:Boolean
        /// <summary>
        /// Indicates whether the objects in the <see cref="ObjectFlow"/> are passed by multicasting.
        /// </summary>
        /// xmi:id="ObjectFlow-isMulticast"
        Boolean IsMulticast { get; }
        #endregion
        #region P:IsMultireceive:Boolean
        /// <summary>
        /// Indicates whether the objects in the <see cref="ObjectFlow"/> are gathered from respondents to multicasting.
        /// </summary>
        /// xmi:id="ObjectFlow-isMultireceive"
        Boolean IsMultireceive { get; }
        #endregion
        #region P:Selection:Behavior
        /// <summary>
        /// A <see cref="Behavior"/> used to select tokens from a <see cref="Source"/> <see cref="ObjectNode"/>.
        /// </summary>
        /// xmi:id="ObjectFlow-selection"
        /// xmi:association="A_selection_objectFlow"
        [Multiplicity("0..1")]
        Behavior Selection { get; }
        #endregion
        #region P:Transformation:Behavior
        /// <summary>
        /// A <see cref="Behavior"/> used to change or replace object tokens flowing along the <see cref="ObjectFlow"/>.
        /// </summary>
        /// xmi:id="ObjectFlow-transformation"
        /// xmi:association="A_transformation_objectFlow"
        [Multiplicity("0..1")]
        Behavior Transformation { get; }
        #endregion
        }
    }
