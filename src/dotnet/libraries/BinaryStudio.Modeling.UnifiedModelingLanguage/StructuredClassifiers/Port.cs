using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Port"/> is a property of an <see cref="EncapsulatedClassifier"/> that specifies a distinct interaction point between that <see cref="EncapsulatedClassifier"/> and its environment or between the (behavior of the) <see cref="EncapsulatedClassifier"/> and its internal parts. Ports are connected to Properties of the <see cref="EncapsulatedClassifier"/> by Connectors through which requests can be made to invoke BehavioralFeatures. A <see cref="Port"/> may specify the services an <see cref="EncapsulatedClassifier"/> provides (offers) to its environment as well as the services that an <see cref="EncapsulatedClassifier"/> expects (requires) of its environment.  A <see cref="Port"/> may have an associated <see cref="ProtocolStateMachine"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   <see cref="Port"/>.aggregation must be composite.
    ///   <![CDATA[
    ///     aggregation = AggregationKind::composite
    ///   ]]>
    ///   xmi:id="Port-port_aggregation"
    /// </rule>
    /// <rule language="OCL">
    ///   A defaultValue for port cannot be specified when the type of the <see cref="Port"/> is an <see cref="Interface"/>.
    ///   <![CDATA[
    ///     type.oclIsKindOf(Interface) implies defaultValue->isEmpty()
    ///   ]]>
    ///   xmi:id="Port-default_value"
    /// </rule>
    /// <rule language="OCL">
    ///   All Ports are owned by an <see cref="EncapsulatedClassifier"/>.
    ///   <![CDATA[
    ///     owner = encapsulatedClassifier
    ///   ]]>
    ///   xmi:id="Port-encapsulated_owner"
    /// </rule>
    /// xmi:id="Port"
    public interface Port : Property
        {
        #region P:IsBehavior:Boolean
        /// <summary>
        /// Specifies whether requests arriving at this <see cref="Port"/> are sent to the classifier behavior of this <see cref="EncapsulatedClassifier"/>. Such a <see cref="Port"/> is referred to as a behavior <see cref="Port"/>. Any invocation of a <see cref="BehavioralFeature"/> targeted at a behavior <see cref="Port"/> will be handled by the instance of the owning <see cref="EncapsulatedClassifier"/> itself, rather than by any instances that it may contain.
        /// </summary>
        /// xmi:id="Port-isBehavior"
        Boolean IsBehavior { get;set; }
        #endregion
        #region P:IsConjugated:Boolean
        /// <summary>
        /// Specifies the way that the <see cref="Provided"/> and <see cref="Required"/> Interfaces are derived from the <see cref="Port"/>’s <see cref="Type"/>.
        /// </summary>
        /// xmi:id="Port-isConjugated"
        Boolean IsConjugated { get;set; }
        #endregion
        #region P:IsService:Boolean
        /// <summary>
        /// If true, indicates that this <see cref="Port"/> is used to provide the published functionality of an <see cref="EncapsulatedClassifier"/>.  If false, this <see cref="Port"/> is used to implement the <see cref="EncapsulatedClassifier"/> but is not part of the essential externally-visible functionality of the <see cref="EncapsulatedClassifier"/> and can, therefore, be altered or deleted along with the internal implementation of the <see cref="EncapsulatedClassifier"/> and other properties that are considered part of its implementation.
        /// </summary>
        /// xmi:id="Port-isService"
        Boolean IsService { get;set; }
        #endregion
        #region P:Protocol:ProtocolStateMachine
        /// <summary>
        /// An optional <see cref="ProtocolStateMachine"/> which describes valid interactions at this interaction point.
        /// </summary>
        /// xmi:id="Port-protocol"
        /// xmi:association="A_protocol_port"
        [Multiplicity("0..1")]
        ProtocolStateMachine Protocol { get;set; }
        #endregion
        #region P:Provided:IList<Interface>
        /// <summary>
        /// The Interfaces specifying the set of Operations and Receptions that the EncapsulatedCclassifier offers to its environment via this <see cref="Port"/>, and which it will handle either directly or by forwarding it to a part of its internal structure. This <see cref="Association"/> is derived according to the value of <see cref="IsConjugated"/>. If <see cref="IsConjugated"/> is false, <see cref="Provided"/> is derived as the union of the sets of Interfaces realized by the <see cref="Type"/> of the port and its supertypes, or directly from the <see cref="Type"/> of the <see cref="Port"/> if the <see cref="Port"/> is typed by an <see cref="Interface"/>. If <see cref="IsConjugated"/> is true, it is derived as the union of the sets of Interfaces used by the <see cref="Type"/> of the <see cref="Port"/> and its supertypes.
        /// </summary>
        /// xmi:id="Port-provided"
        /// xmi:association="A_provided_port"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        IList<Interface> Provided { get; }
        #endregion
        #region P:RedefinedPort:IList<Port>
        /// <summary>
        /// A <see cref="Port"/> may be redefined when its containing <see cref="EncapsulatedClassifier"/> is specialized. The redefining <see cref="Port"/> may have additional Interfaces to those that are associated with the redefined <see cref="Port"/> or it may replace an <see cref="Interface"/> by one of its subtypes.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Property.RedefinedProperty"/>"
        /// </summary>
        /// xmi:id="Port-redefinedPort"
        /// xmi:association="A_redefinedPort_port"
        IList<Port> RedefinedPort { get; }
        #endregion
        #region P:Required:IList<Interface>
        /// <summary>
        /// The Interfaces specifying the set of Operations and Receptions that the EncapsulatedCassifier expects its environment to handle via this port. This <see cref="Association"/> is derived according to the value of <see cref="IsConjugated"/>. If <see cref="IsConjugated"/> is false, <see cref="Required"/> is derived as the union of the sets of Interfaces used by the <see cref="Type"/> of the <see cref="Port"/> and its supertypes. If <see cref="IsConjugated"/> is true, it is derived as the union of the sets of Interfaces realized by the <see cref="Type"/> of the <see cref="Port"/> and its supertypes, or directly from the <see cref="Type"/> of the <see cref="Port"/> if the <see cref="Port"/> is typed by an <see cref="Interface"/>.
        /// </summary>
        /// xmi:id="Port-required"
        /// xmi:association="A_required_port"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        IList<Interface> Required { get; }
        #endregion

        #region M:basicProvided:Interface[]
        /// <summary>
        /// The union of the sets of Interfaces realized by the <see cref="Type"/> of the <see cref="Port"/> and its supertypes, or directly the <see cref="Type"/> of the <see cref="Port"/> if the <see cref="Port"/> is typed by an <see cref="Interface"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if type.oclIsKindOf(Interface) 
        ///     then type.oclAsType(Interface)->asSet() 
        ///     else type.oclAsType(Classifier).allRealizedInterfaces() 
        ///     endif)
        ///   ]]>
        ///   xmi:id="Port-basicProvided-spec"
        /// </rule>
        /// xmi:id="Port-basicProvided"
        /// xmi:is-query="true"
        Interface[] basicProvided();
        #endregion
        #region M:basicRequired:Interface[]
        /// <summary>
        /// The union of the sets of Interfaces used by the <see cref="Type"/> of the <see cref="Port"/> and its supertypes.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = ( type.oclAsType(Classifier).allUsedInterfaces() )
        ///   ]]>
        ///   xmi:id="Port-basicRequired-spec"
        /// </rule>
        /// xmi:id="Port-basicRequired"
        /// xmi:is-query="true"
        Interface[] basicRequired();
        #endregion
        #region M:provided:Interface[]
        /// <summary>
        /// Derivation for <see cref="Port"/>::/<see cref="Provided"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if isConjugated then basicRequired() else basicProvided() endif)
        ///   ]]>
        ///   xmi:id="Port-provided.1-spec"
        /// </rule>
        /// xmi:id="Port-provided.1"
        /// xmi:is-query="true"
        Interface[] provided();
        #endregion
        #region M:required:Interface[]
        /// <summary>
        /// Derivation for <see cref="Port"/>::/<see cref="Required"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if isConjugated then basicProvided() else basicRequired() endif)
        ///   ]]>
        ///   xmi:id="Port-required.1-spec"
        /// </rule>
        /// xmi:id="Port-required.1"
        /// xmi:is-query="true"
        Interface[] required();
        #endregion
        }
    }
