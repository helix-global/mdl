using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ReadIsClassifiedObjectAction"/> is an <see cref="Action"/> that determines whether an <see cref="Object"/> is classified by a given <see cref="Classifier"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The object <see cref="InputPin"/> has no type.
    ///   <![CDATA[
    ///     object.type = null
    ///   ]]>
    ///   xmi:id="ReadIsClassifiedObjectAction-no_type"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the result <see cref="OutputPin"/> is 1..1.
    ///   <![CDATA[
    ///     result.is(1,1)
    ///   ]]>
    ///   xmi:id="ReadIsClassifiedObjectAction-multiplicity_of_output"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the result <see cref="OutputPin"/> is Boolean.
    ///   <![CDATA[
    ///     result.type = Boolean
    ///   ]]>
    ///   xmi:id="ReadIsClassifiedObjectAction-boolean_result"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the object <see cref="InputPin"/> is 1..1.
    ///   <![CDATA[
    ///     object.is(1,1)
    ///   ]]>
    ///   xmi:id="ReadIsClassifiedObjectAction-multiplicity_of_input"
    /// </rule>
    /// xmi:id="ReadIsClassifiedObjectAction"
    public interface ReadIsClassifiedObjectAction : Action
        {
        #region P:Classifier:Classifier
        /// <summary>
        /// The <see cref="Classifier"/> against which the classification of the <see cref="Input"/> <see cref="Object"/> is tested.
        /// </summary>
        /// xmi:id="ReadIsClassifiedObjectAction-classifier"
        Classifier Classifier { get; }
        #endregion
        #region P:IsDirect:Boolean
        /// <summary>
        /// Indicates whether the <see cref="Input"/> <see cref="Object"/> must be directly classified by the given <see cref="Classifier"/> or whether it may also be an instance of a specialization of the given <see cref="Classifier"/>.
        /// </summary>
        /// xmi:id="ReadIsClassifiedObjectAction-isDirect"
        Boolean IsDirect { get; }
        #endregion
        #region P:Object:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> that holds the <see cref="Object"/> whose classification is to be tested.
        /// </summary>
        /// xmi:id="ReadIsClassifiedObjectAction-object"
        /// xmi:aggregation="composite"
        InputPin Object { get; }
        #endregion
        #region P:Result:OutputPin
        /// <summary>
        /// The <see cref="OutputPin"/> that holds the Boolean <see cref="Result"/> of the test.
        /// </summary>
        /// xmi:id="ReadIsClassifiedObjectAction-result"
        /// xmi:aggregation="composite"
        OutputPin Result { get; }
        #endregion
        }
    }
