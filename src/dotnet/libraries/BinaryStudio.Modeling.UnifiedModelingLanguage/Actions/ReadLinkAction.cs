using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ReadLinkAction"/> is a <see cref="LinkAction"/> that navigates across an <see cref="Association"/> to retrieve the objects on one end.
    /// </summary>
    /// <rule language="OCL">
    ///   The type and ordering of the result <see cref="OutputPin"/> are same as the type and ordering of the open <see cref="Association"/> end.
    ///   <![CDATA[
    ///     self.openEnd()->forAll(type=result.type and isOrdered=result.isOrdered)
    ///     
    ///   ]]>
    ///   xmi:id="ReadLinkAction-type_and_ordering"
    /// </rule>
    /// <rule language="OCL">
    ///   The multiplicity of the open <see cref="Association"/> end must be compatible with the multiplicity of the result <see cref="OutputPin"/>.
    ///   <![CDATA[
    ///     self.openEnd()->first().compatibleWith(result)
    ///     
    ///   ]]>
    ///   xmi:id="ReadLinkAction-compatible_multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   Visibility of the open end must allow access from the object performing the action.
    ///   <![CDATA[
    ///     let openEnd : Property = self.openEnd()->first() in
    ///       openEnd.visibility = VisibilityKind::public or 
    ///       endData->exists(oed | 
    ///         oed.end<>openEnd and 
    ///         (_'context' = oed.end.type or 
    ///           (openEnd.visibility = VisibilityKind::protected and 
    ///             _'context'.conformsTo(oed.end.type.oclAsType(Classifier)))))
    ///     
    ///   ]]>
    ///   xmi:id="ReadLinkAction-visibility"
    /// </rule>
    /// <rule language="OCL">
    ///   Exactly one linkEndData specification (corresponding to the "open" end) must not have an value <see cref="InputPin"/>.
    ///   <![CDATA[
    ///     self.openEnd()->size() = 1
    ///   ]]>
    ///   xmi:id="ReadLinkAction-one_open_end"
    /// </rule>
    /// <rule language="OCL">
    ///   The open end must be navigable.
    ///   <![CDATA[
    ///     self.openEnd()->first().isNavigable()
    ///     
    ///   ]]>
    ///   xmi:id="ReadLinkAction-navigable_open_end"
    /// </rule>
    /// xmi:id="ReadLinkAction"
    public interface ReadLinkAction : LinkAction
        {
        #region P:Result:OutputPin
        /// <summary>
        /// The <see cref="OutputPin"/> on which the objects retrieved from the "open" end of those links whose values on other ends are given by the <see cref="EndData"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Output"/>"
        /// </summary>
        /// xmi:id="ReadLinkAction-result"
        /// xmi:aggregation="composite"
        /// xmi:association="A_result_readLinkAction"
        OutputPin Result { get; }
        #endregion

        #region M:openEnd:Property[]
        /// <summary>
        /// Returns the ends corresponding to <see cref="EndData"/> with no value <see cref="InputPin"/>. (A well-formed <see cref="ReadLinkAction"/> is constrained to have only one of these.)
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (endData->select(value=null).end->asOrderedSet())
        ///   ]]>
        ///   xmi:id="ReadLinkAction-openEnd-spec"
        /// </rule>
        /// xmi:id="ReadLinkAction-openEnd"
        /// xmi:is-query="true"
        Property[] openEnd();
        #endregion
        }
    }
