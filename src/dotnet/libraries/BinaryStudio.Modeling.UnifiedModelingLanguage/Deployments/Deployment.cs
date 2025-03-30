using System;

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
        /// </summary>
        /// xmi:id="Deployment-configuration"
        /// xmi:aggregation="composite"
        DeploymentSpecification[] Configuration { get; }
        #endregion
        #region P:DeployedArtifact:DeployedArtifact[]
        /// <summary>
        /// The Artifacts that are deployed onto a <see cref="Node"/>. This association specializes the <see cref="Supplier"/> association.
        /// </summary>
        /// xmi:id="Deployment-deployedArtifact"
        DeployedArtifact[] DeployedArtifact { get; }
        #endregion
        #region P:Location:DeploymentTarget
        /// <summary>
        /// The DeployedTarget which is the <see cref="Target"/> of a <see cref="Deployment"/>.
        /// </summary>
        /// xmi:id="Deployment-location"
        DeploymentTarget Location { get; }
        #endregion
        }
    }
