using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A relationship from an extending <see cref="UseCase"/> to an extended <see cref="UseCase"/> that specifies how and when the behavior defined in the extending <see cref="UseCase"/> can be inserted into the behavior defined in the extended <see cref="UseCase"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   The ExtensionPoints referenced by the <see cref="Extend"/> relationship must belong to the <see cref="UseCase"/> that is being extended.
    ///   <![CDATA[
    ///     extensionLocation->forAll (xp | extendedCase.extensionPoint->includes(xp))
    ///   ]]>
    ///   xmi:id="Extend-extension_points"
    /// </rule>
    /// xmi:id="Extend"
    public interface Extend : NamedElement,DirectedRelationship
        {
        #region P:Condition:Constraint
        /// <summary>
        /// References the <see cref="Condition"/> that must hold when the first <see cref="ExtensionPoint"/> is reached for the <see cref="Extension"/> to take place. If no constraint is associated with the <see cref="Extend"/> relationship, the <see cref="Extension"/> is unconditional.
        /// </summary>
        /// xmi:id="Extend-condition"
        /// xmi:aggregation="composite"
        Constraint Condition { get; }
        #endregion
        #region P:ExtendedCase:UseCase
        /// <summary>
        /// The <see cref="UseCase"/> that is being extended.
        /// </summary>
        /// xmi:id="Extend-extendedCase"
        UseCase ExtendedCase { get; }
        #endregion
        #region P:Extension:UseCase
        /// <summary>
        /// The <see cref="UseCase"/> that represents the <see cref="Extension"/> and owns the <see cref="Extend"/> relationship.
        /// </summary>
        /// xmi:id="Extend-extension"
        UseCase Extension { get; }
        #endregion
        #region P:ExtensionLocation:ExtensionPoint[]
        /// <summary>
        /// An ordered list of ExtensionPoints belonging to the extended <see cref="UseCase"/>, specifying where the respective behavioral fragments of the extending <see cref="UseCase"/> are to be inserted. The first fragment in the extending <see cref="UseCase"/> is associated with the first <see cref="Extension"/> point in the list, the second fragment with the second point, and so on. Note that, in most practical cases, the extending <see cref="UseCase"/> has just a single behavior fragment, so that the list of ExtensionPoints is trivial.
        /// </summary>
        /// xmi:id="Extend-extensionLocation"
        ExtensionPoint[] ExtensionLocation { get; }
        #endregion
        }
    }
