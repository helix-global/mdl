using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Generalization"/> is a taxonomic relationship between a more <see cref="General"/> <see cref="Classifier"/> and a more <see cref="Specific"/> <see cref="Classifier"/>. Each instance of the <see cref="Specific"/> <see cref="Classifier"/> is also an instance of the <see cref="General"/> <see cref="Classifier"/>. The <see cref="Specific"/> <see cref="Classifier"/> inherits the features of the more <see cref="General"/> <see cref="Classifier"/>. A <see cref="Generalization"/> is owned by the <see cref="Specific"/> <see cref="Classifier"/>.
    /// </summary>
    /// xmi:id="Generalization"
    public interface Generalization : DirectedRelationship
        {
        #region P:General:Classifier
        /// <summary>
        /// The <see cref="General"/> classifier in the <see cref="Generalization"/> relationship.
        /// </summary>
        /// xmi:id="Generalization-general"
        Classifier General { get; }
        #endregion
        #region P:GeneralizationSet:GeneralizationSet[]
        /// <summary>
        /// Represents a set of instances of <see cref="Generalization"/>.  A <see cref="Generalization"/> may appear in many GeneralizationSets.
        /// </summary>
        /// xmi:id="Generalization-generalizationSet"
        GeneralizationSet[] GeneralizationSet { get; }
        #endregion
        #region P:IsSubstitutable:Boolean
        /// <summary>
        /// Indicates whether the <see cref="Specific"/> <see cref="Classifier"/> can be used wherever the <see cref="General"/> <see cref="Classifier"/> can be used. If true, the execution traces of the <see cref="Specific"/> <see cref="Classifier"/> shall be a superset of the execution traces of the <see cref="General"/> <see cref="Classifier"/>. If false, there is no such constraint on execution traces. If unset, the modeler has not stated whether there is such a constraint or not.
        /// </summary>
        /// xmi:id="Generalization-isSubstitutable"
        Boolean IsSubstitutable { get; }
        #endregion
        #region P:Specific:Classifier
        /// <summary>
        /// The specializing <see cref="Classifier"/> in the <see cref="Generalization"/> relationship.
        /// </summary>
        /// xmi:id="Generalization-specific"
        Classifier Specific { get; }
        #endregion
        }
    }
