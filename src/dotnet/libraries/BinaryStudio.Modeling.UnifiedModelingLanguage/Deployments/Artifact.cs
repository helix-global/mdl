using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An artifact is the specification of a physical piece of information that is used or produced by a software development process, or by deployment and operation of a system. Examples of artifacts include model files, source files, scripts, and binary executable files, a table in a database system, a development deliverable, or a word-processing document, a mail message.
    /// An artifact is the source of a deployment to a node.
    /// </summary>
    /// xmi:id="Artifact"
    public interface Artifact : Classifier,DeployedArtifact
        {
        #region P:FileName:String
        /// <summary>
        /// A concrete <see cref="Name"/> that is used to refer to the <see cref="Artifact"/> in a physical context. Example: file system <see cref="Name"/>, universal resource locator.
        /// </summary>
        /// xmi:id="Artifact-fileName"
        [Multiplicity("0..1")]
        String FileName { get; }
        #endregion
        #region P:Manifestation:Manifestation[]
        /// <summary>
        /// The set of model elements that are manifested in the <see cref="Artifact"/>. That is, these model elements are utilized in the construction (or generation) of the artifact.
        /// </summary>
        /// xmi:id="Artifact-manifestation"
        /// xmi:aggregation="composite"
        /// xmi:association="A_manifestation_artifact"
        /// xmi:subsets="Element-ownedElement"
        /// xmi:subsets="NamedElement-clientDependency"
        Manifestation[] Manifestation { get; }
        #endregion
        #region P:NestedArtifact:Artifact[]
        /// <summary>
        /// The Artifacts that are defined (nested) within the <see cref="Artifact"/>. The association is a specialization of the <see cref="OwnedMember"/> association from <see cref="Namespace"/> to <see cref="NamedElement"/>.
        /// </summary>
        /// xmi:id="Artifact-nestedArtifact"
        /// xmi:aggregation="composite"
        /// xmi:association="A_nestedArtifact_artifact"
        /// xmi:subsets="Namespace-ownedMember"
        Artifact[] NestedArtifact { get; }
        #endregion
        #region P:OwnedAttribute:Property[]
        /// <summary>
        /// The attributes or association ends defined for the <see cref="Artifact"/>. The association is a specialization of the <see cref="OwnedMember"/> association.
        /// </summary>
        /// xmi:id="Artifact-ownedAttribute"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedAttribute_artifact"
        /// xmi:subsets="Classifier-attribute"
        /// xmi:subsets="Namespace-ownedMember"
        [Ordered]
        Property[] OwnedAttribute { get; }
        #endregion
        #region P:OwnedOperation:Operation[]
        /// <summary>
        /// The Operations defined for the <see cref="Artifact"/>. The association is a specialization of the <see cref="OwnedMember"/> association.
        /// </summary>
        /// xmi:id="Artifact-ownedOperation"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedOperation_artifact"
        /// xmi:subsets="A_redefinitionContext_redefinableElement-redefinableElement"
        /// xmi:subsets="Classifier-feature"
        /// xmi:subsets="Namespace-ownedMember"
        [Ordered]
        Operation[] OwnedOperation { get; }
        #endregion
        }
    }
