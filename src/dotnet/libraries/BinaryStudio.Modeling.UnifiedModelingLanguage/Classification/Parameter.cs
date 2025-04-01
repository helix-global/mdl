using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Parameter"/> is a specification of an argument used to pass information into or out of an invocation of a <see cref="BehavioralFeature"/>.  Parameters can be treated as ConnectableElements within Collaborations.
    /// </summary>
    /// <rule language="OCL">
    ///   Only in and inout Parameters may have a delete effect. Only out, inout, and return Parameters may have a create effect.
    ///   <![CDATA[
    ///     (effect = ParameterEffectKind::delete implies (direction = ParameterDirectionKind::_'in' or direction = ParameterDirectionKind::inout))
    ///     and
    ///     (effect = ParameterEffectKind::create implies (direction = ParameterDirectionKind::out or direction = ParameterDirectionKind::inout or direction = ParameterDirectionKind::return))
    ///   ]]>
    ///   xmi:id="Parameter-in_and_out"
    /// </rule>
    /// <rule language="OCL">
    ///   An input <see cref="Parameter"/> cannot be an exception.
    ///   <![CDATA[
    ///     isException implies (direction <> ParameterDirectionKind::_'in' and direction <> ParameterDirectionKind::inout)
    ///   ]]>
    ///   xmi:id="Parameter-not_exception"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="Parameter"/> may only be associated with a <see cref="Connector"/> end within the context of a <see cref="Collaboration"/>.
    ///   <![CDATA[
    ///     end->notEmpty() implies collaboration->notEmpty()
    ///   ]]>
    ///   xmi:id="Parameter-connector_end"
    /// </rule>
    /// <rule language="OCL">
    ///   Reentrant behaviors cannot have stream Parameters.
    ///   <![CDATA[
    ///     (isStream and behavior <> null) implies not behavior.isReentrant
    ///   ]]>
    ///   xmi:id="Parameter-reentrant_behaviors"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="Parameter"/> cannot be a stream and exception at the same time.
    ///   <![CDATA[
    ///     not (isException and isStream)
    ///   ]]>
    ///   xmi:id="Parameter-stream_and_exception"
    /// </rule>
    /// <rule language="OCL">
    ///   Parameters typed by DataTypes cannot have an effect.
    ///   <![CDATA[
    ///     (type.oclIsKindOf(DataType)) implies (effect = null)
    ///   ]]>
    ///   xmi:id="Parameter-object_effect"
    /// </rule>
    /// xmi:id="Parameter"
    public interface Parameter : MultiplicityElement,ConnectableElement
        {
        #region P:Default:String
        /// <summary>
        /// A String that represents a value to be used when no argument is supplied for the <see cref="Parameter"/>.
        /// </summary>
        /// xmi:id="Parameter-default"
        /// xmi:is-derived="true"
        [Multiplicity("0..1")]
        String Default { get;set; }
        #endregion
        #region P:DefaultValue:ValueSpecification
        /// <summary>
        /// Specifies a <see cref="ValueSpecification"/> that represents a value to be used when no argument is supplied for the <see cref="Parameter"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Parameter-defaultValue"
        /// xmi:aggregation="composite"
        /// xmi:association="A_defaultValue_owningParameter"
        [Multiplicity("0..1")]
        ValueSpecification DefaultValue { get;set; }
        #endregion
        #region P:Direction:ParameterDirectionKind
        /// <summary>
        /// Indicates whether a parameter is being sent into or out of a behavioral element.
        /// </summary>
        /// xmi:id="Parameter-direction"
        ParameterDirectionKind Direction { get;set; }
        #endregion
        #region P:Effect:ParameterEffectKind?
        /// <summary>
        /// Specifies the <see cref="Effect"/> that executions of the <see cref="Owner"/> of the <see cref="Parameter"/> have on objects passed in or out of the parameter.
        /// </summary>
        /// xmi:id="Parameter-effect"
        ParameterEffectKind? Effect { get;set; }
        #endregion
        #region P:IsException:Boolean
        /// <summary>
        /// Tells whether an output parameter may emit a value to the exclusion of the other outputs.
        /// </summary>
        /// xmi:id="Parameter-isException"
        Boolean IsException { get;set; }
        #endregion
        #region P:IsStream:Boolean
        /// <summary>
        /// Tells whether an input parameter may accept values while its behavior is executing, or whether an output parameter may post values while the behavior is executing.
        /// </summary>
        /// xmi:id="Parameter-isStream"
        Boolean IsStream { get;set; }
        #endregion
        #region P:Operation:Operation
        /// <summary>
        /// The <see cref="Operation"/> owning this parameter.
        /// Subsets:
        /// </summary>
        /// xmi:id="Parameter-operation"
        /// xmi:association="A_ownedParameter_operation"
        /// xmi:subsets="A_ownedParameter_ownerFormalParam-ownerFormalParam"
        [Multiplicity("0..1")]
        Operation Operation { get;set; }
        #endregion
        #region P:ParameterSet:IList<ParameterSet>
        /// <summary>
        /// The ParameterSets containing the parameter. See <see cref="ParameterSet"/>.
        /// </summary>
        /// xmi:id="Parameter-parameterSet"
        /// xmi:association="A_parameterSet_parameter"
        IList<ParameterSet> ParameterSet { get; }
        #endregion

        #region M:default:String
        /// <summary>
        /// Derivation for <see cref="Parameter"/>::/<see cref="Default"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if self.type = String then defaultValue.stringValue() else null endif)
        ///   ]]>
        ///   xmi:id="Parameter-default.1-spec"
        /// </rule>
        /// xmi:id="Parameter-default.1"
        /// xmi:is-query="true"
        [return: Multiplicity("0..1")]
        String @default();
        #endregion
        }
    }
