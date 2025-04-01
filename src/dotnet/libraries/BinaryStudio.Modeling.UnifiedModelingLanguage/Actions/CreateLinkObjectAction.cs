using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="CreateLinkObjectAction"/> is a <see cref="CreateLinkAction"/> for creating link objects (AssociationClasse instances).
    /// </summary>
    /// <rule language="OCL">
    ///   The multiplicity of the <see cref="OutputPin"/> is 1..1.
    ///   <![CDATA[
    ///     result.is(1,1)
    ///   ]]>
    ///   xmi:id="CreateLinkObjectAction-multiplicity"
    /// </rule>
    /// <rule language="OCL">
    ///   The type of the result <see cref="OutputPin"/> must be the same as the <see cref="Association"/> of the <see cref="CreateLinkObjectAction"/>.
    ///   <![CDATA[
    ///     result.type = association()
    ///   ]]>
    ///   xmi:id="CreateLinkObjectAction-type_of_result"
    /// </rule>
    /// <rule language="OCL">
    ///   The <see cref="Association"/> must be an <see cref="AssociationClass"/>.
    ///   <![CDATA[
    ///     self.association().oclIsKindOf(AssociationClass)
    ///   ]]>
    ///   xmi:id="CreateLinkObjectAction-association_class"
    /// </rule>
    /// xmi:id="CreateLinkObjectAction"
    public interface CreateLinkObjectAction : CreateLinkAction
        {
        #region P:Result:OutputPin
        /// <summary>
        /// The <see cref="Output"/> pin on which the newly created link object is placed.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Action.Output"/>"
        /// </summary>
        /// xmi:id="CreateLinkObjectAction-result"
        /// xmi:aggregation="composite"
        /// xmi:association="A_result_createLinkObjectAction"
        OutputPin Result { get;set; }
        #endregion
        }
    }
