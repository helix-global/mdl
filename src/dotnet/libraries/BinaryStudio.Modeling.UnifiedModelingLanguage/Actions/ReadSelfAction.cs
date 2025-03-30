using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ReadSelfAction"/> is an <see cref="Action"/> that retrieves the <see cref="Context"/> object of the <see cref="Behavior"/> execution within which the <see cref="ReadSelfAction"/> execution is taking place.
    /// </summary>
    /// <rule language="OCL">
    ///   A <see cref="ReadSelfAction"/> must have a context <see cref="Classifier"/>.
    ///   <![CDATA[
    ///     _'context' <> null
    ///   ]]>
    ///   xmi:id="ReadSelfAction-contained"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the result <see cref="OutputPin"/> is 1..1.
    ///   <![CDATA[
    ///     result.is(1,1)
    ///   ]]>
    ///   xmi:id="ReadSelfAction-multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   If the <see cref="ReadSelfAction"/> is contained in an <see cref="Behavior"/> that is acting as a method, then the <see cref="Operation"/> of the method must not be static.
    ///   <![CDATA[
    ///     let behavior: Behavior = self.containingBehavior() in
    ///     behavior.specification<>null implies not behavior.specification.isStatic
    ///   ]]>
    ///   xmi:id="ReadSelfAction-not_static"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the result <see cref="OutputPin"/> is the context <see cref="Classifier"/>.
    ///   <![CDATA[
    ///     result.type = _'context'
    ///   ]]>
    ///   xmi:id="ReadSelfAction-type"
    /// </rule>
    /// xmi:id="ReadSelfAction"
    public interface ReadSelfAction : Action
        {
        #region P:Result:OutputPin
        /// <summary>
        /// The <see cref="OutputPin"/> on which the <see cref="Context"/> object is placed.
        /// </summary>
        /// xmi:id="ReadSelfAction-result"
        /// xmi:aggregation="composite"
        OutputPin Result { get; }
        #endregion
        }
    }
