using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ReadExtentAction"/> is an <see cref="Action"/> that retrieves the current instances of a <see cref="Classifier"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The type of the result <see cref="OutputPin"/> is the classifier.
    ///   <![CDATA[
    ///     result.type = classifier
    ///   ]]>
    ///   xmi:id="ReadExtentAction-type_is_classifier"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the result <see cref="OutputPin"/> is 0..*.
    ///   <![CDATA[
    ///     result.is(0,*)
    ///   ]]>
    ///   xmi:id="ReadExtentAction-multiplicity_of_result"
    /// </rule>
    /// xmi:id="ReadExtentAction"
    public interface ReadExtentAction : Action
        {
        #region P:Classifier:Classifier
        /// <summary>
        /// The <see cref="Classifier"/> whose instances are to be retrieved.
        /// </summary>
        /// xmi:id="ReadExtentAction-classifier"
        Classifier Classifier { get; }
        #endregion
        #region P:Result:OutputPin
        /// <summary>
        /// The <see cref="OutputPin"/> on which the <see cref="Classifier"/> instances are placed.
        /// </summary>
        /// xmi:id="ReadExtentAction-result"
        /// xmi:aggregation="composite"
        OutputPin Result { get; }
        #endregion
        }
    }
