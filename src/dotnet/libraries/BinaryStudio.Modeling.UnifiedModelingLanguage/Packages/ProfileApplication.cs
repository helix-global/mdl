using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A profile application is used to show which profiles have been applied to a package.
    /// </summary>
    /// xmi:id="ProfileApplication"
    public interface ProfileApplication : DirectedRelationship
        {
        #region P:AppliedProfile:Profile
        /// <summary>
        /// References the Profiles that are applied to a <see cref="Package"/> through this <see cref="ProfileApplication"/>.
        /// </summary>
        /// xmi:id="ProfileApplication-appliedProfile"
        Profile AppliedProfile { get; }
        #endregion
        #region P:ApplyingPackage:Package
        /// <summary>
        /// The package that owns the profile application.
        /// </summary>
        /// xmi:id="ProfileApplication-applyingPackage"
        Package ApplyingPackage { get; }
        #endregion
        #region P:IsStrict:Boolean
        /// <summary>
        /// Specifies that the <see cref="Profile"/> filtering rules for the metaclasses of the referenced metamodel shall be strictly applied.
        /// </summary>
        /// xmi:id="ProfileApplication-isStrict"
        Boolean IsStrict { get; }
        #endregion
        }
    }
