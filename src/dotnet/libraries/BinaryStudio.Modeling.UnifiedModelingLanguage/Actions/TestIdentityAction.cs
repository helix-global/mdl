using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="TestIdentityAction"/> is an <see cref="Action"/> that tests if two values are identical objects.
    /// </summary>
    /// <rule language="OCL">
    ///   The multiplicity of the InputPins is 1..1.
    ///   <![CDATA[
    ///     first.is(1,1) and second.is(1,1)
    ///     
    ///   ]]>
    ///   xmi:id="TestIdentityAction-multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   The InputPins have no type.
    ///   <![CDATA[
    ///     first.type= null and second.type = null
    ///     
    ///   ]]>
    ///   xmi:id="TestIdentityAction-no_type"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the result <see cref="OutputPin"/> is Boolean. 
    ///   <![CDATA[
    ///     result.type=Boolean
    ///   ]]>
    ///   xmi:id="TestIdentityAction-result_is_boolean"
    /// </rule>
    /// xmi:id="TestIdentityAction"
    public interface TestIdentityAction : Action
        {
        #region P:First:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> on which the <see cref="First"/> <see cref="Input"/> object is placed.
        /// </summary>
        /// xmi:id="TestIdentityAction-first"
        /// xmi:aggregation="composite"
        InputPin First { get; }
        #endregion
        #region P:Result:OutputPin
        /// <summary>
        /// The <see cref="OutputPin"/> whose Boolean value indicates whether the two <see cref="Input"/> objects are identical.
        /// </summary>
        /// xmi:id="TestIdentityAction-result"
        /// xmi:aggregation="composite"
        OutputPin Result { get; }
        #endregion
        #region P:Second:InputPin
        /// <summary>
        /// The <see cref="OutputPin"/> on which the <see cref="Second"/> <see cref="Input"/> object is placed.
        /// </summary>
        /// xmi:id="TestIdentityAction-second"
        /// xmi:aggregation="composite"
        InputPin Second { get; }
        #endregion
        }
    }
