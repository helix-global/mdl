using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Deployment"/> specification specifies a set of properties that determine execution parameters of a component artifact that is deployed on a node. A <see cref="Deployment"/> specification can be aimed at a specific type of container. An artifact that reifies or implements <see cref="Deployment"/> specification properties is a <see cref="Deployment"/> descriptor.
    /// </summary>
    /// <rule language="OCL">
    ///   The <see cref="DeploymentTarget"/> of a <see cref="DeploymentSpecification"/> is a kind of <see cref="ExecutionEnvironment"/>.
    ///   <![CDATA[
    ///     deployment->forAll (location.oclIsKindOf(ExecutionEnvironment))
    ///   ]]>
    ///   xmi:id="DeploymentSpecification-deployment_target"
    /// </rule>
    /// <rule language="OCL">
    ///   The deployedElements of a <see cref="DeploymentTarget"/> that are involved in a <see cref="Deployment"/> that has an associated <see cref="Deployment"/>-Specification is a kind of <see cref="Component"/> (i.e., the configured components).
    ///   <![CDATA[
    ///     deployment->forAll (location.deployedElement->forAll (oclIsKindOf(Component)))
    ///   ]]>
    ///   xmi:id="DeploymentSpecification-deployed_elements"
    /// </rule>
    /// xmi:id="DeploymentSpecification"
    public interface DeploymentSpecification : Artifact
        {
        #region P:Deployment:Deployment
        /// <summary>
        /// The <see cref="Deployment"/> with which the <see cref="DeploymentSpecification"/> is associated.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.Owner"/>"
        /// </summary>
        /// xmi:id="DeploymentSpecification-deployment"
        /// xmi:association="A_configuration_deployment"
        [Multiplicity("0..1")]
        Deployment Deployment { get; }
        #endregion
        #region P:DeploymentLocation:String
        /// <summary>
        /// The location where an <see cref="Artifact"/> is deployed onto a <see cref="Node"/>. This is typically a 'directory' or 'memory address.'
        /// </summary>
        /// xmi:id="DeploymentSpecification-deploymentLocation"
        [Multiplicity("0..1")]
        String DeploymentLocation { get; }
        #endregion
        #region P:ExecutionLocation:String
        /// <summary>
        /// The location where a component <see cref="Artifact"/> executes. This may be a local or remote location.
        /// </summary>
        /// xmi:id="DeploymentSpecification-executionLocation"
        [Multiplicity("0..1")]
        String ExecutionLocation { get; }
        #endregion
        }
    }
