using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A stereotype defines how an existing metaclass may be extended, and enables the use of platform or domain specific terminology or notation in place of, or in addition to, the ones used for the extended metaclass.
    /// </summary>
    /// <rule language="OCL">
    ///   Stereotypes may only participate in binary associations.
    ///   <![CDATA[
    ///     ownedAttribute.association->forAll(memberEnd->size()=2)
    ///   ]]>
    ///   xmi:id="Stereotype-binaryAssociationsOnly"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="Stereotype"/> may only generalize or specialize another <see cref="Stereotype"/>.
    ///   <![CDATA[
    ///     allParents()->forAll(oclIsKindOf(Stereotype)) 
    ///     and Classifier.allInstances()->forAll(c | c.allParents()->exists(oclIsKindOf(Stereotype)) implies c.oclIsKindOf(Stereotype))
    ///     
    ///   ]]>
    ///   xmi:id="Stereotype-generalize"
    /// </rule>
    /// <rule language="">
    ///   <see cref="Stereotype"/> names should not clash with keyword names for the extended model element.
    ///   xmi:id="Stereotype-name_not_clash"
    /// </rule>
    /// <rule language="OCL">
    ///   Where a stereotype’s property is an association end for an association other than a kind of extension, and the other end is not a stereotype, the other end must be owned by the association itself.
    ///   <![CDATA[
    ///     ownedAttribute
    ///     ->select(association->notEmpty() and not association.oclIsKindOf(Extension) and not type.oclIsKindOf(Stereotype))
    ///     ->forAll(opposite.owner = association)
    ///   ]]>
    ///   xmi:id="Stereotype-associationEndOwnership"
    /// </rule>
    /// <rule language="">
    ///   The upper bound of base-properties is exactly 1.
    ///   xmi:id="Stereotype-base_property_upper_bound"
    /// </rule>
    /// <rule language="">
    ///   If a <see cref="Stereotype"/> extends only one metaclass, the multiplicity of the corresponding base-property shall be 1..1.
    ///   xmi:id="Stereotype-base_property_multiplicity_single_extension"
    /// </rule>
    /// <rule language="">
    ///   If a <see cref="Stereotype"/> extends more than one metaclass, the multiplicity of the corresponding base-properties shall be [0..1]. At any point in time, only one of these base-properties can contain a metaclass instance during runtime.
    ///   xmi:id="Stereotype-base_property_multiplicity_multiple_extension"
    /// </rule>
    /// xmi:id="Stereotype"
    public interface Stereotype : Class
        {
        #region P:Icon:Image[]
        /// <summary>
        /// <see cref="Stereotype"/> can change the graphical appearance of the extended model element by using attached icons. When this association is not null, it references the location of the <see cref="Icon"/> content to be displayed within diagrams presenting the extended model elements.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Stereotype-icon"
        /// xmi:aggregation="composite"
        /// xmi:association="A_icon_stereotype"
        Image[] Icon { get; }
        #endregion
        #region P:Profile:Profile
        /// <summary>
        /// The <see cref="Profile"/> that directly or indirectly contains this stereotype.
        /// </summary>
        /// xmi:id="Stereotype-profile"
        /// xmi:association="A_profile_stereotype"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        Profile Profile { get; }
        #endregion

        #region M:containingProfile:Profile
        /// <summary>
        /// The query containingProfile returns the closest <see cref="Profile"/> directly or indirectly containing this stereotype.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.namespace.oclAsType(Package).containingProfile())
        ///   ]]>
        ///   xmi:id="Stereotype-containingProfile-spec"
        /// </rule>
        /// xmi:id="Stereotype-containingProfile"
        /// xmi:is-query="true"
        Profile containingProfile();
        #endregion
        #region M:profile:Profile
        /// <summary>
        /// A stereotype must be contained, directly or indirectly, in a <see cref="Profile"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self.containingProfile())
        ///   ]]>
        ///   xmi:id="Stereotype-profile.1-spec"
        /// </rule>
        /// xmi:id="Stereotype-profile.1"
        /// xmi:is-query="true"
        Profile profile();
        #endregion
        }
    }
