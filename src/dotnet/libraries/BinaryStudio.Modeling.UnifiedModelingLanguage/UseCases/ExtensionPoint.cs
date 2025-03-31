using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="ExtensionPoint"/> identifies a point in the behavior of a <see cref="UseCase"/> where that behavior can be extended by the behavior of some other (extending) <see cref="UseCase"/>, as specified by an <see cref="Extend"/> relationship.
    /// </summary>
    /// <rule language="OCL">
    ///   An <see cref="ExtensionPoint"/> must have a name.
    ///   <![CDATA[
    ///     name->notEmpty ()
    ///   ]]>
    ///   xmi:id="ExtensionPoint-must_have_name"
    /// </rule>
    /// xmi:id="ExtensionPoint"
    public interface ExtensionPoint : RedefinableElement
        {
        #region P:UseCase:UseCase
        /// <summary>
        /// The <see cref="UseCase"/> that owns this <see cref="ExtensionPoint"/>.
        /// </summary>
        /// xmi:id="ExtensionPoint-useCase"
        /// xmi:association="A_extensionPoint_useCase"
        /// xmi:subsets="NamedElement-namespace"
        UseCase UseCase { get; }
        #endregion
        }
    }
