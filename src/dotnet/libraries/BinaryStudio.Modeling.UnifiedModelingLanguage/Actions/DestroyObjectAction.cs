using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="DestroyObjectAction"/> is an <see cref="Action"/> that destroys objects.
    /// </summary>
    /// <rule language="OCL">
    ///   The multiplicity of the targe IinputPin is 1..1.
    ///   <![CDATA[
    ///     target.is(1,1)
    ///   ]]>
    ///   xmi:id="DestroyObjectAction-multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   The target <see cref="InputPin"/> has no type.
    ///   <![CDATA[
    ///     target.type= null
    ///   ]]>
    ///   xmi:id="DestroyObjectAction-no_type"
    /// </rule>
    /// xmi:id="DestroyObjectAction"
    public interface DestroyObjectAction : Action
        {
        #region P:IsDestroyLinks:Boolean
        /// <summary>
        /// Specifies whether links in which the object participates are destroyed along with the object.
        /// </summary>
        /// xmi:id="DestroyObjectAction-isDestroyLinks"
        Boolean IsDestroyLinks { get; }
        #endregion
        #region P:IsDestroyOwnedObjects:Boolean
        /// <summary>
        /// Specifies whether objects owned by the object (via composition) are destroyed along with the object.
        /// </summary>
        /// xmi:id="DestroyObjectAction-isDestroyOwnedObjects"
        Boolean IsDestroyOwnedObjects { get; }
        #endregion
        #region P:Target:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> providing the object to be destroyed.
        /// </summary>
        /// xmi:id="DestroyObjectAction-target"
        /// xmi:aggregation="composite"
        /// xmi:association="A_target_destroyObjectAction"
        /// xmi:subsets="Action-input"
        InputPin Target { get; }
        #endregion
        }
    }
