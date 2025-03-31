using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ConnectorEnd"/> is an endpoint of a <see cref="Connector"/>, which attaches the <see cref="Connector"/> to a <see cref="ConnectableElement"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   If a <see cref="ConnectorEnd"/> references a partWithPort, then the role must be a <see cref="Port"/> that is defined or inherited by the type of the partWithPort.
    ///   <![CDATA[
    ///     partWithPort->notEmpty() implies 
    ///       (role.oclIsKindOf(Port) and partWithPort.type.oclAsType(Namespace).member->includes(role))
    ///   ]]>
    ///   xmi:id="ConnectorEnd-role_and_part_with_port"
    /// </rule>
    /// <rule language="OCL">
    ///   If a <see cref="ConnectorEnd"/> is attached to a <see cref="Port"/> of the containing <see cref="Classifier"/>, partWithPort will be empty.
    ///   <![CDATA[
    ///     (role.oclIsKindOf(Port) and role.owner = connector.owner) implies partWithPort->isEmpty()
    ///   ]]>
    ///   xmi:id="ConnectorEnd-part_with_port_empty"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the <see cref="ConnectorEnd"/> may not be more general than the multiplicity of the corresponding end of the <see cref="Association"/> typing the owning <see cref="Connector"/>, if any.
    ///   <![CDATA[
    ///     self.compatibleWith(definingEnd)
    ///   ]]>
    ///   xmi:id="ConnectorEnd-multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   The <see cref="Property"/> held in self.partWithPort must not be a <see cref="Port"/>.
    ///   <![CDATA[
    ///     partWithPort->notEmpty() implies not partWithPort.oclIsKindOf(Port)
    ///   ]]>
    ///   xmi:id="ConnectorEnd-self_part_with_port"
    /// </rule>
    /// xmi:id="ConnectorEnd"
    public interface ConnectorEnd : MultiplicityElement
        {
        #region P:DefiningEnd:Property
        /// <summary>
        /// A derived property referencing the corresponding end on the <see cref="Association"/> which types the <see cref="Connector"/> owing this <see cref="ConnectorEnd"/>, if any. It is derived by selecting the end at the same place in the ordering of <see cref="Association"/> ends as this <see cref="ConnectorEnd"/>.
        /// </summary>
        /// xmi:id="ConnectorEnd-definingEnd"
        /// xmi:association="A_definingEnd_connectorEnd"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        [Multiplicity("0..1")]
        Property DefiningEnd { get; }
        #endregion
        #region P:PartWithPort:Property
        /// <summary>
        /// Indicates the <see cref="Role"/> of the internal structure of a <see cref="Classifier"/> with the <see cref="Port"/> to which the <see cref="ConnectorEnd"/> is attached.
        /// </summary>
        /// xmi:id="ConnectorEnd-partWithPort"
        /// xmi:association="A_partWithPort_connectorEnd"
        [Multiplicity("0..1")]
        Property PartWithPort { get; }
        #endregion
        #region P:Role:ConnectableElement
        /// <summary>
        /// The <see cref="ConnectableElement"/> attached at this <see cref="ConnectorEnd"/>. When an instance of the containing <see cref="Classifier"/> is created, a link may (depending on the multiplicities) be created to an instance of the <see cref="Classifier"/> that types this <see cref="ConnectableElement"/>.
        /// </summary>
        /// xmi:id="ConnectorEnd-role"
        /// xmi:association="A_end_role"
        ConnectableElement Role { get; }
        #endregion

        #region M:definingEnd:Property
        /// <summary>
        /// Derivation for <see cref="ConnectorEnd"/>::/<see cref="DefiningEnd"/> : <see cref="Property"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if connector.type = null 
        ///     then
        ///       null 
        ///     else
        ///       let index : Integer = connector.end->indexOf(self) in
        ///         connector.type.memberEnd->at(index)
        ///     endif)
        ///   ]]>
        ///   xmi:id="ConnectorEnd-definingEnd.1-spec"
        /// </rule>
        /// xmi:id="ConnectorEnd-definingEnd.1"
        /// xmi:is-query="true"
        Property definingEnd();
        #endregion
        }
    }
