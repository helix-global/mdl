using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="InstanceSpecification"/> is a model element that represents an instance in a modeled system. An <see cref="InstanceSpecification"/> can act as a <see cref="DeploymentTarget"/> in a <see cref="Deployment"/> relationship, in the case that it represents an instance of a <see cref="Node"/>. It can also act as a <see cref="DeployedArtifact"/>, if it represents an instance of an <see cref="Artifact"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   An <see cref="InstanceSpecification"/> can act as a <see cref="DeployedArtifact"/> if it represents an instance of an <see cref="Artifact"/>.
    ///   <![CDATA[
    ///     deploymentForArtifact->notEmpty() implies classifier->exists(oclIsKindOf(Artifact))
    ///   ]]>
    ///   xmi:id="InstanceSpecification-deployment_artifact"
    /// </rule>
    /// <rule language="OCL">
    ///   No more than one slot in an <see cref="InstanceSpecification"/> may have the same definingFeature.
    ///   <![CDATA[
    ///     classifier->forAll(c | (c.allSlottableFeatures()->forAll(f | slot->select(s | s.definingFeature = f)->size() <= 1)))
    ///   ]]>
    ///   xmi:id="InstanceSpecification-structural_feature"
    /// </rule>
    /// <rule language="OCL">
    ///   The definingFeature of each slot is a <see cref="StructuralFeature"/> related to a classifier of the <see cref="InstanceSpecification"/>, including direct attributes, inherited attributes, private attributes in generalizations, and memberEnds of Associations, but excluding redefined StructuralFeatures.
    ///   <![CDATA[
    ///     slot->forAll(s | classifier->exists (c | c.allSlottableFeatures()->includes (s.definingFeature)))
    ///   ]]>
    ///   xmi:id="InstanceSpecification-defining_feature"
    /// </rule>
    /// <rule language="OCL">
    ///   An <see cref="InstanceSpecification"/> can act as a <see cref="DeploymentTarget"/> if it represents an instance of a <see cref="Node"/> and functions as a part in the internal structure of an encompassing <see cref="Node"/>.
    ///   <![CDATA[
    ///     deployment->notEmpty() implies classifier->exists(node | node.oclIsKindOf(Node) and Node.allInstances()->exists(n | n.part->exists(p | p.type = node)))
    ///   ]]>
    ///   xmi:id="InstanceSpecification-deployment_target"
    /// </rule>
    /// xmi:id="InstanceSpecification"
    public interface InstanceSpecification : PackageableElement,DeployedArtifact,DeploymentTarget
        {
        #region P:Classifier:Classifier[]
        /// <summary>
        /// The <see cref="Classifier"/> or Classifiers of the represented instance. If multiple Classifiers are specified, the instance is classified by all of them.
        /// </summary>
        /// xmi:id="InstanceSpecification-classifier"
        /// xmi:association="A_classifier_instanceSpecification"
        Classifier[] Classifier { get; }
        #endregion
        #region P:Slot:Slot[]
        /// <summary>
        /// A <see cref="Slot"/> giving the value or values of a <see cref="StructuralFeature"/> of the instance. An <see cref="InstanceSpecification"/> can have one <see cref="Slot"/> per <see cref="StructuralFeature"/> of its Classifiers, including inherited features. It is not necessary to model a <see cref="Slot"/> for every <see cref="StructuralFeature"/>, in which case the <see cref="InstanceSpecification"/> is a partial description.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="InstanceSpecification-slot"
        /// xmi:aggregation="composite"
        /// xmi:association="A_slot_owningInstance"
        Slot[] Slot { get; }
        #endregion
        #region P:Specification:ValueSpecification
        /// <summary>
        /// A <see cref="Specification"/> of how to compute, derive, or construct the instance.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="InstanceSpecification-specification"
        /// xmi:aggregation="composite"
        /// xmi:association="A_specification_owningInstanceSpec"
        [Multiplicity("0..1")]
        ValueSpecification Specification { get; }
        #endregion
        }
    }
