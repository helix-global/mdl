using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="ActivityParameterNode"/> is an <see cref="ObjectNode"/> for accepting values from the input Parameters or providing values to the output Parameters of an <see cref="Activity"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   An <see cref="ActivityParameterNode"/> with no outgoing ActivityEdges and one or more incoming ActivityEdges must have a parameter with direction out, inout, or return.
    ///   <![CDATA[
    ///     (incoming->notEmpty() and outgoing->isEmpty()) implies 
    ///     	(parameter.direction = ParameterDirectionKind::out or 
    ///     	 parameter.direction = ParameterDirectionKind::inout or 
    ///     	 parameter.direction = ParameterDirectionKind::return)
    ///   ]]>
    ///   xmi:id="ActivityParameterNode-no_outgoing_edges"
    /// </rule>
    /// <rule language="OCL">
    ///   The parameter of an <see cref="ActivityParameterNode"/> must be from the containing <see cref="Activity"/>.
    ///   <![CDATA[
    ///     activity.ownedParameter->includes(parameter)
    ///   ]]>
    ///   xmi:id="ActivityParameterNode-has_parameters"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of an <see cref="ActivityParameterNode"/> is the same as the type of its parameter.
    ///   <![CDATA[
    ///     type = parameter.type
    ///   ]]>
    ///   xmi:id="ActivityParameterNode-same_type"
    /// </rule>
    /// <rule language="OCL">
    ///   An <see cref="ActivityParameterNode"/> with no incoming ActivityEdges and one or more outgoing ActivityEdges must have a parameter with direction in or inout.
    ///   <![CDATA[
    ///     (outgoing->notEmpty() and incoming->isEmpty()) implies 
    ///     	(parameter.direction = ParameterDirectionKind::_'in' or 
    ///     	 parameter.direction = ParameterDirectionKind::inout)
    ///   ]]>
    ///   xmi:id="ActivityParameterNode-no_incoming_edges"
    /// </rule>
    /// <rule language="OCL">
    ///   An <see cref="ActivityParameterNode"/> may have all incoming ActivityEdges or all outgoing ActivityEdges, but it must not have both incoming and outgoing ActivityEdges.
    ///   <![CDATA[
    ///     incoming->isEmpty() or outgoing->isEmpty()
    ///   ]]>
    ///   xmi:id="ActivityParameterNode-no_edges"
    /// </rule>
    /// xmi:id="ActivityParameterNode"
    public interface ActivityParameterNode : ObjectNode
        {
        #region P:Parameter:Parameter
        /// <summary>
        /// The <see cref="Parameter"/> for which the <see cref="ActivityParameterNode"/> will be accepting or providing values.
        /// </summary>
        /// xmi:id="ActivityParameterNode-parameter"
        /// xmi:association="A_parameter_activityParameterNode"
        Parameter Parameter { get;set; }
        #endregion
        }
    }
