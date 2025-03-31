using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="ConnectableElement"/> is an abstract metaclass representing a set of instances that play roles of a <see cref="StructuredClassifier"/>. ConnectableElements may be joined by attached Connectors and specify configurations of linked instances to be created within an instance of the containing <see cref="StructuredClassifier"/>.
    /// </summary>
    /// xmi:id="ConnectableElement"
    public interface ConnectableElement : ParameterableElement,TypedElement
        {
        #region P:End:ConnectorEnd[]
        /// <summary>
        /// A set of ConnectorEnds that attach to this <see cref="ConnectableElement"/>.
        /// </summary>
        /// xmi:id="ConnectableElement-end"
        /// xmi:association="A_end_role"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        ConnectorEnd[] End { get; }
        #endregion
        #region P:TemplateParameter:ConnectableElementTemplateParameter
        /// <summary>
        /// The <see cref="ConnectableElementTemplateParameter"/> for this <see cref="ConnectableElement"/> parameter.
        /// </summary>
        /// xmi:id="ConnectableElement-templateParameter"
        /// xmi:association="A_connectableElement_templateParameter_parameteredElement"
        /// xmi:redefines="ParameterableElement-templateParameter{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.ParameterableElement.TemplateParameter"/>}"
        [Multiplicity("0..1")]
        ConnectableElementTemplateParameter TemplateParameter { get; }
        #endregion

        #region M:end:ConnectorEnd[]
        /// <summary>
        /// Derivation for <see cref="ConnectableElement"/>::/<see cref="End"/> : <see cref="ConnectorEnd"/>
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (ConnectorEnd.allInstances()->select(role = self))
        ///   ]]>
        ///   xmi:id="ConnectableElement-end.1-spec"
        /// </rule>
        /// xmi:id="ConnectableElement-end.1"
        /// xmi:is-query="true"
        ConnectorEnd[] end();
        #endregion
        }
    }
