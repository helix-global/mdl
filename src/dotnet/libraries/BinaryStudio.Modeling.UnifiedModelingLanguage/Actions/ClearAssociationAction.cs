using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ClearAssociationAction"/> is an <see cref="Action"/> that destroys all links of an <see cref="Association"/> in which a particular <see cref="Object"/> participates.
    /// </summary>
    /// <rule language="OCL">
    ///   The multiplicity of the object <see cref="InputPin"/> is 1..1.
    ///   <![CDATA[
    ///     object.is(1,1)
    ///   ]]>
    ///   xmi:id="ClearAssociationAction-multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the <see cref="InputPin"/> must conform to the type of at least one of the memberEnds of the association.
    ///   <![CDATA[
    ///     association.memberEnd->exists(self.object.type.conformsTo(type))
    ///   ]]>
    ///   xmi:id="ClearAssociationAction-same_type"
    /// </rule>
    /// xmi:id="ClearAssociationAction"
    public interface ClearAssociationAction : Action
        {
        #region P:Association:Association
        /// <summary>
        /// The <see cref="Association"/> to be cleared.
        /// </summary>
        /// xmi:id="ClearAssociationAction-association"
        /// xmi:association="A_association_clearAssociationAction"
        Association Association { get; }
        #endregion
        #region P:Object:InputPin
        /// <summary>
        /// The <see cref="InputPin"/> that gives the <see cref="Object"/> whose participation in the <see cref="Association"/> is to be cleared.
        /// </summary>
        /// xmi:id="ClearAssociationAction-object"
        /// xmi:aggregation="composite"
        /// xmi:association="A_object_clearAssociationAction"
        /// xmi:subsets="Action-input"
        InputPin Object { get; }
        #endregion
        }
    }
