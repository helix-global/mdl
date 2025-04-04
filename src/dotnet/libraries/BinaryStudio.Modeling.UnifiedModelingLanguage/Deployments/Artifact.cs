﻿using System;
using System.Collections.Generic;
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
        String FileName { get;set; }
        #endregion
        #region P:Manifestation:IList<Manifestation>
        /// <summary>
        /// The set of model elements that are manifested in the <see cref="Artifact"/>. That is, these model elements are utilized in the construction (or generation) of the artifact.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.ClientDependency"/>"
        /// </summary>
        /// xmi:id="Artifact-manifestation"
        /// xmi:aggregation="composite"
        /// xmi:association="A_manifestation_artifact"
        IList<Manifestation> Manifestation { get; }
        #endregion
        #region P:NestedArtifact:IList<Artifact>
        /// <summary>
        /// The Artifacts that are defined (nested) within the <see cref="Artifact"/>. The association is a specialization of the <see cref="OwnedMember"/> association from <see cref="Namespace"/> to <see cref="NamedElement"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Artifact-nestedArtifact"
        /// xmi:aggregation="composite"
        /// xmi:association="A_nestedArtifact_artifact"
        IList<Artifact> NestedArtifact { get; }
        #endregion
        #region P:OwnedAttribute:IList<Property>
        /// <summary>
        /// The attributes or association ends defined for the <see cref="Artifact"/>. The association is a specialization of the <see cref="OwnedMember"/> association.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.Attribute"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Artifact-ownedAttribute"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedAttribute_artifact"
        [Ordered]
        IList<Property> OwnedAttribute { get; }
        #endregion
        #region P:OwnedOperation:IList<Operation>
        /// <summary>
        /// The Operations defined for the <see cref="Artifact"/>. The association is a specialization of the <see cref="OwnedMember"/> association.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Classifier.Feature"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.OwnedMember"/>"
        /// </summary>
        /// xmi:id="Artifact-ownedOperation"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedOperation_artifact"
        /// xmi:subsets="A_redefinitionContext_redefinableElement-redefinableElement"
        [Ordered]
        IList<Operation> OwnedOperation { get; }
        #endregion
        }
    }
