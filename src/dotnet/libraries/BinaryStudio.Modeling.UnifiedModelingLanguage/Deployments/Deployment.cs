using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A deployment is the allocation of an artifact or artifact instance to a deployment <see cref="Target"/>.
    /// A component deployment is the deployment of one or more artifacts or artifact instances to a deployment <see cref="Target"/>, optionally parameterized by a deployment specification. Examples are executables and <see cref="Configuration"/> files.
    /// </summary>
    /// xmi:id="Deployment"
    public interface Deployment : Dependency
        {
        #region P:Configuration:DeploymentSpecification[]
        /// <summary>
        /// The specification of properties that parameterize the deployment and execution of one or more Artifacts.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Deployment-configuration"
        /// xmi:aggregation="composite"
        /// xmi:association="A_configuration_deployment"
        DeploymentSpecification[] Configuration { get; }
        #endregion
        #region P:DeployedArtifact:DeployedArtifact[]
        /// <summary>
        /// The Artifacts that are deployed onto a <see cref="Node"/>. This association specializes the <see cref="Supplier"/> association.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Dependency.Supplier"/>"
        /// </summary>
        /// xmi:id="Deployment-deployedArtifact"
        /// xmi:association="A_deployedArtifact_deploymentForArtifact"
        DeployedArtifact[] DeployedArtifact { get; }
        #endregion
        #region P:Location:DeploymentTarget
        /// <summary>
        /// The DeployedTarget which is the <see cref="Target"/> of a <see cref="Deployment"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Dependency.Client"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.Owner"/>"
        /// </summary>
        /// xmi:id="Deployment-location"
        /// xmi:association="A_deployment_location"
        DeploymentTarget Location { get; }
        #endregion
        }
    }
