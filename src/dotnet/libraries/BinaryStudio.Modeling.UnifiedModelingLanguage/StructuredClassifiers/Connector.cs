using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Connector"/> specifies links that enables communication between two or more instances. In contrast to Associations, which specify links between any instance of the associated Classifiers, Connectors specify links between instances playing the connected parts only.
    /// </summary>
    /// <rule language="OCL">
    ///   The types of the ConnectableElements that the ends of a <see cref="Connector"/> are attached to must conform to the types of the ends of the <see cref="Association"/> that types the <see cref="Connector"/>, if any.
    ///   <![CDATA[
    ///     type<>null implies 
    ///       let noOfEnds : Integer = end->size() in 
    ///       (type.memberEnd->size() = noOfEnds) and Sequence{1..noOfEnds}->forAll(i | end->at(i).role.type.conformsTo(type.memberEnd->at(i).type))
    ///   ]]>
    ///   xmi:id="Connector-types"
    /// </rule>
    /// <rule language="OCL">
    ///   The ConnectableElements attached as roles to each <see cref="ConnectorEnd"/> owned by a <see cref="Connector"/> must be owned or inherited roles of the <see cref="Classifier"/> that owned the <see cref="Connector"/>, or they must be Ports of such roles.
    ///   <![CDATA[
    ///     structuredClassifier <> null
    ///     and
    ///       end->forAll( e | structuredClassifier.allRoles()->includes(e.role)
    ///     or
    ///       e.role.oclIsKindOf(Port) and structuredClassifier.allRoles()->includes(e.partWithPort))
    ///   ]]>
    ///   xmi:id="Connector-roles"
    /// </rule>
    /// xmi:id="Connector"
    public interface Connector : Feature
        {
        #region P:Contract:IList<Behavior>
        /// <summary>
        /// The set of Behaviors that specify the valid interaction patterns across the <see cref="Connector"/>.
        /// </summary>
        /// xmi:id="Connector-contract"
        /// xmi:association="A_contract_connector"
        IList<Behavior> Contract { get; }
        #endregion
        #region P:End:IList<ConnectorEnd>
        /// <summary>
        /// A <see cref="Connector"/> has at least two ConnectorEnds, each representing the participation of instances of the Classifiers typing the ConnectableElements attached to the <see cref="End"/>. The set of ConnectorEnds is ordered.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Connector-end"
        /// xmi:aggregation="composite"
        /// xmi:association="A_end_connector"
        [Multiplicity("2..*")][Ordered]
        IList<ConnectorEnd> End { get; }
        #endregion
        #region P:Kind:ConnectorKind
        /// <summary>
        /// Indicates the <see cref="Kind"/> of <see cref="Connector"/>. This is derived: a <see cref="Connector"/> with one or more ends connected to a <see cref="Port"/> which is not on a Part and which is not a behavior port is a delegation; otherwise it is an assembly.
        /// </summary>
        /// xmi:id="Connector-kind"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        ConnectorKind Kind { get; }
        #endregion
        #region P:RedefinedConnector:IList<Connector>
        /// <summary>
        /// A <see cref="Connector"/> may be redefined when its containing <see cref="Classifier"/> is specialized. The redefining <see cref="Connector"/> may have a <see cref="Type"/> that specializes the <see cref="Type"/> of the redefined <see cref="Connector"/>. The types of the ConnectorEnds of the redefining <see cref="Connector"/> may specialize the types of the ConnectorEnds of the redefined <see cref="Connector"/>. The properties of the ConnectorEnds of the redefining <see cref="Connector"/> may be replaced.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.RedefinableElement.RedefinedElement"/>"
        /// </summary>
        /// xmi:id="Connector-redefinedConnector"
        /// xmi:association="A_redefinedConnector_connector"
        IList<Connector> RedefinedConnector { get; }
        #endregion
        #region P:Type:Association
        /// <summary>
        /// An optional <see cref="Association"/> that classifies links corresponding to this <see cref="Connector"/>.
        /// </summary>
        /// xmi:id="Connector-type"
        /// xmi:association="A_type_connector"
        [Multiplicity("0..1")]
        Association Type { get;set; }
        #endregion

        #region M:kind:ConnectorKind
        /// <summary>
        /// Derivation for <see cref="Connector"/>::/<see cref="Kind"/> : <see cref="ConnectorKind"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if end->exists(
        ///     		role.oclIsKindOf(Port) 
        ///     		and partWithPort->isEmpty()
        ///     		and not role.oclAsType(Port).isBehavior)
        ///     then ConnectorKind::delegation 
        ///     else ConnectorKind::assembly 
        ///     endif)
        ///   ]]>
        ///   xmi:id="Connector-kind.1-spec"
        /// </rule>
        /// xmi:id="Connector-kind.1"
        /// xmi:is-query="true"
        ConnectorKind kind();
        #endregion
        }
    }
