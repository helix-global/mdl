using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An extension is used to indicate that the properties of a <see cref="Metaclass"/> are extended through a stereotype, and gives the ability to flexibly add (and later remove) stereotypes to classes.
    /// </summary>
    /// <rule language="OCL">
    ///   The non-owned end of an <see cref="Extension"/> is typed by a <see cref="Class"/>.
    ///   <![CDATA[
    ///     metaclassEnd()->notEmpty() and metaclassEnd().type.oclIsKindOf(Class)
    ///   ]]>
    ///   xmi:id="Extension-non_owned_end"
    /// </rule>
    /// <rule language="OCL">
    ///   An <see cref="Extension"/> is binary, i.e., it has only two memberEnds.
    ///   <![CDATA[
    ///     memberEnd->size() = 2
    ///   ]]>
    ///   xmi:id="Extension-is_binary"
    /// </rule>
    /// xmi:id="Extension"
    public interface Extension : Association
        {
        #region P:IsRequired:Boolean
        /// <summary>
        /// Indicates whether an instance of the extending stereotype must be created when an instance of the extended class is created. The <see cref="Attribute"/> value is derived from the value of the lower property of the <see cref="ExtensionEnd"/> referenced by <see cref="Extension"/>::<see cref="OwnedEnd"/>; a lower value of 1 means that <see cref="IsRequired"/> is true, but otherwise it is false. Since the default value of <see cref="ExtensionEnd"/>::lower is 0, the default value of <see cref="IsRequired"/> is false.
        /// </summary>
        /// xmi:id="Extension-isRequired"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        Boolean IsRequired { get; }
        #endregion
        #region P:Metaclass:Class
        /// <summary>
        /// References the <see cref="Class"/> that is extended through an <see cref="Extension"/>. The property is derived from the type of the <see cref="MemberEnd"/> that is not the <see cref="OwnedEnd"/>.
        /// </summary>
        /// xmi:id="Extension-metaclass"
        /// xmi:association="A_extension_metaclass"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        Class Metaclass { get; }
        #endregion
        #region P:OwnedEnd:ExtensionEnd
        /// <summary>
        /// References the end of the extension that is typed by a <see cref="Stereotype"/>.
        /// </summary>
        /// xmi:id="Extension-ownedEnd"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedEnd_extension"
        /// xmi:redefines="Association-ownedEnd{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Association.OwnedEnd"/>}"
        ExtensionEnd OwnedEnd { get; }
        #endregion

        #region M:isRequired:Boolean
        /// <summary>
        /// The query <see cref="IsRequired"/>() is true if the owned end has a multiplicity with the lower bound of 1.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (ownedEnd.lowerBound() = 1)
        ///   ]]>
        ///   xmi:id="Extension-isRequired.1-spec"
        /// </rule>
        /// xmi:id="Extension-isRequired.1"
        /// xmi:is-query="true"
        Boolean isRequired();
        #endregion
        #region M:metaclass:Class
        /// <summary>
        /// The query <see cref="Metaclass"/>() returns the <see cref="Metaclass"/> that is being extended (as opposed to the extending stereotype).
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (metaclassEnd().type.oclAsType(Class))
        ///   ]]>
        ///   xmi:id="Extension-metaclass.1-spec"
        /// </rule>
        /// xmi:id="Extension-metaclass.1"
        /// xmi:is-query="true"
        Class metaclass();
        #endregion
        #region M:metaclassEnd:Property
        /// <summary>
        /// The query <see cref="metaclassEnd"/> returns the <see cref="Property"/> that is typed by a <see cref="Metaclass"/> (as opposed to a stereotype).
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (memberEnd->reject(p | ownedEnd->includes(p.oclAsType(ExtensionEnd)))->any(true))
        ///   ]]>
        ///   xmi:id="Extension-metaclassEnd-spec"
        /// </rule>
        /// xmi:id="Extension-metaclassEnd"
        /// xmi:is-query="true"
        Property metaclassEnd();
        #endregion
        }
    }
