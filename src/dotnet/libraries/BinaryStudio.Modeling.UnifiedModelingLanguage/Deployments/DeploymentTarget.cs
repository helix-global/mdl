using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Deployment"/> target is the location for a deployed artifact.
    /// </summary>
    /// xmi:id="DeploymentTarget"
    public interface DeploymentTarget : NamedElement
        {
        #region P:DeployedElement:PackageableElement[]
        /// <summary>
        /// The set of elements that are manifested in an <see cref="Artifact"/> that is involved in <see cref="Deployment"/> to a <see cref="DeploymentTarget"/>.
        /// </summary>
        /// xmi:id="DeploymentTarget-deployedElement"
        PackageableElement[] DeployedElement { get; }
        #endregion
        #region P:Deployment:Deployment[]
        /// <summary>
        /// The set of Deployments for a <see cref="DeploymentTarget"/>.
        /// </summary>
        /// xmi:id="DeploymentTarget-deployment"
        /// xmi:aggregation="composite"
        Deployment[] Deployment { get; }
        #endregion

        #region M:deployedElement:PackageableElement[]
        /// <summary>
        /// Derivation for <see cref="DeploymentTarget"/>::/<see cref="DeployedElement"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (deployment.deployedArtifact->select(oclIsKindOf(Artifact))->collect(oclAsType(Artifact).manifestation)->collect(utilizedElement)->asSet())
        ///   ]]>
        ///   xmi:id="DeploymentTarget-deployedElement.1-spec"
        /// </rule>
        /// xmi:id="DeploymentTarget-deployedElement.1"
        /// xmi:is-query="true"
        PackageableElement[] deployedElement();
        #endregion
        }
    }
