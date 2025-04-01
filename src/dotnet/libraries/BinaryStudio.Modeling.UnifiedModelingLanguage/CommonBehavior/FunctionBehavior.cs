using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="FunctionBehavior"/> is an <see cref="OpaqueBehavior"/> that does not access or modify any objects or other external data.
    /// </summary>
    /// <rule language="OCL">
    ///   A <see cref="FunctionBehavior"/> has at least one output <see cref="Parameter"/>.
    ///   <![CDATA[
    ///     self.ownedParameter->
    ///       select(p | p.direction = ParameterDirectionKind::out or p.direction= ParameterDirectionKind::inout or p.direction= ParameterDirectionKind::return)->size() >= 1
    ///   ]]>
    ///   xmi:id="FunctionBehavior-one_output_parameter"
    /// </rule>
    /// <rule language="OCL">
    ///   The types of the ownedParameters are all DataTypes, which may not nest anything but other DataTypes.
    ///   <![CDATA[
    ///     ownedParameter->forAll(p | p.type <> null and
    ///       p.type.oclIsTypeOf(DataType) and hasAllDataTypeAttributes(p.type.oclAsType(DataType)))
    ///   ]]>
    ///   xmi:id="FunctionBehavior-types_of_parameters"
    /// </rule>
    /// xmi:id="FunctionBehavior"
    public interface FunctionBehavior : OpaqueBehavior
        {

        #region M:hasAllDataTypeAttributes(DataType):Boolean
        /// <summary>
        /// The hasAllDataTypeAttributes query tests whether the types of the attributes of the given <see cref="DataType"/> are all DataTypes, and similarly for all those DataTypes.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (d.ownedAttribute->forAll(a |
        ///         a.type.oclIsKindOf(DataType) and
        ///           hasAllDataTypeAttributes(a.type.oclAsType(DataType))))
        ///   ]]>
        ///   xmi:id="FunctionBehavior-hasAllDataTypeAttributes-spec"
        /// </rule>
        /// xmi:id="FunctionBehavior-hasAllDataTypeAttributes"
        /// xmi:is-query="true"
        Boolean hasAllDataTypeAttributes(DataType d);
        #endregion
        }
    }
