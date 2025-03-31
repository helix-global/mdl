using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// InformationFlows describe circulation of information through a system in a general manner. They do not specify the nature of the information, mechanisms by which it is <see cref="Conveyed"/>, sequences of exchange or any control conditions. During more detailed modeling, representation and <see cref="Realization"/> links may be added to specify which model elements implement an <see cref="InformationFlow"/> and to show how information is <see cref="Conveyed"/>.  InformationFlows require some kind of “information channel” for unidirectional transmission of information items from sources to targets.  They specify the information channel’s realizations, if any, and identify the information that flows along them.  Information moving along the information channel may be represented by abstract InformationItems and by concrete Classifiers.
    /// </summary>
    /// <rule language="">
    ///   The sources and targets of the information flow must conform to the sources and targets or conversely the targets and sources of the realization relationships.
    ///   xmi:id="InformationFlow-must_conform"
    /// </rule>
    /// <rule language="OCL">
    ///   The sources and targets of the information flow can only be one of the following kind: <see cref="Actor"/>, <see cref="Node"/>, <see cref="UseCase"/>, <see cref="Artifact"/>, <see cref="Class"/>, <see cref="Component"/>, <see cref="Port"/>, <see cref="Property"/>, <see cref="Interface"/>, <see cref="Package"/>, <see cref="ActivityNode"/>, <see cref="ActivityPartition"/>,
    ///   <see cref="Behavior"/> and <see cref="InstanceSpecification"/> except when its classifier is a relationship (i.e. it represents a link).
    ///   <![CDATA[
    ///     (self.informationSource->forAll( sis |
    ///       oclIsKindOf(Actor) or oclIsKindOf(Node) or oclIsKindOf(UseCase) or oclIsKindOf(Artifact) or 
    ///       oclIsKindOf(Class) or oclIsKindOf(Component) or oclIsKindOf(Port) or oclIsKindOf(Property) or 
    ///       oclIsKindOf(Interface) or oclIsKindOf(Package) or oclIsKindOf(ActivityNode) or oclIsKindOf(ActivityPartition) or 
    ///       (oclIsKindOf(InstanceSpecification) and not sis.oclAsType(InstanceSpecification).classifier->exists(oclIsKindOf(Relationship))))) 
    ///     
    ///     and
    ///     
    ///     (self.informationTarget->forAll( sit | 
    ///       oclIsKindOf(Actor) or oclIsKindOf(Node) or oclIsKindOf(UseCase) or oclIsKindOf(Artifact) or 
    ///       oclIsKindOf(Class) or oclIsKindOf(Component) or oclIsKindOf(Port) or oclIsKindOf(Property) or 
    ///       oclIsKindOf(Interface) or oclIsKindOf(Package) or oclIsKindOf(ActivityNode) or oclIsKindOf(ActivityPartition) or 
    ///     (oclIsKindOf(InstanceSpecification) and not sit.oclAsType(InstanceSpecification).classifier->exists(oclIsKindOf(Relationship)))))
    ///   ]]>
    ///   xmi:id="InformationFlow-sources_and_targets_kind"
    /// </rule>
    /// <rule language="OCL">
    ///   An information flow can only convey classifiers that are allowed to represent an information item.
    ///   <![CDATA[
    ///     self.conveyed->forAll(oclIsKindOf(Class) or oclIsKindOf(Interface)
    ///       or oclIsKindOf(InformationItem) or oclIsKindOf(Signal) or oclIsKindOf(Component))
    ///   ]]>
    ///   xmi:id="InformationFlow-convey_classifiers"
    /// </rule>
    /// xmi:id="InformationFlow"
    public interface InformationFlow : DirectedRelationship,PackageableElement
        {
        #region P:Conveyed:Classifier[]
        /// <summary>
        /// Specifies the information items that may circulate on this information flow.
        /// </summary>
        /// xmi:id="InformationFlow-conveyed"
        /// xmi:association="A_conveyed_conveyingFlow"
        [Multiplicity("1..*")]
        Classifier[] Conveyed { get; }
        #endregion
        #region P:InformationSource:NamedElement[]
        /// <summary>
        /// Defines from which <see cref="Source"/> the <see cref="Conveyed"/> InformationItems are initiated.
        /// </summary>
        /// xmi:id="InformationFlow-informationSource"
        /// xmi:association="A_informationSource_informationFlow"
        /// xmi:subsets="DirectedRelationship-source"
        [Multiplicity("1..*")]
        NamedElement[] InformationSource { get; }
        #endregion
        #region P:InformationTarget:NamedElement[]
        /// <summary>
        /// Defines to which <see cref="Target"/> the <see cref="Conveyed"/> InformationItems are directed.
        /// </summary>
        /// xmi:id="InformationFlow-informationTarget"
        /// xmi:association="A_informationTarget_informationFlow"
        /// xmi:subsets="DirectedRelationship-target"
        [Multiplicity("1..*")]
        NamedElement[] InformationTarget { get; }
        #endregion
        #region P:Realization:Relationship[]
        /// <summary>
        /// Determines which <see cref="Relationship"/> will realize the specified flow.
        /// </summary>
        /// xmi:id="InformationFlow-realization"
        /// xmi:association="A_realization_abstraction_flow"
        Relationship[] Realization { get; }
        #endregion
        #region P:RealizingActivityEdge:ActivityEdge[]
        /// <summary>
        /// Determines which ActivityEdges will realize the specified flow.
        /// </summary>
        /// xmi:id="InformationFlow-realizingActivityEdge"
        /// xmi:association="A_realizingActivityEdge_informationFlow"
        ActivityEdge[] RealizingActivityEdge { get; }
        #endregion
        #region P:RealizingConnector:Connector[]
        /// <summary>
        /// Determines which Connectors will realize the specified flow.
        /// </summary>
        /// xmi:id="InformationFlow-realizingConnector"
        /// xmi:association="A_realizingConnector_informationFlow"
        Connector[] RealizingConnector { get; }
        #endregion
        #region P:RealizingMessage:Message[]
        /// <summary>
        /// Determines which Messages will realize the specified flow.
        /// </summary>
        /// xmi:id="InformationFlow-realizingMessage"
        /// xmi:association="A_realizingMessage_informationFlow"
        Message[] RealizingMessage { get; }
        #endregion
        }
    }
