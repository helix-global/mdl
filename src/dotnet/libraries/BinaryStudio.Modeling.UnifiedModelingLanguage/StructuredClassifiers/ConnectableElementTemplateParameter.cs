using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ConnectableElementTemplateParameter"/> exposes a <see cref="ConnectableElement"/> as a formal parameter for a template.
    /// </summary>
    /// xmi:id="ConnectableElementTemplateParameter"
    public interface ConnectableElementTemplateParameter : TemplateParameter
        {
        #region P:ParameteredElement:ConnectableElement
        /// <summary>
        /// The <see cref="ConnectableElement"/> for this <see cref="ConnectableElementTemplateParameter"/>.
        /// Redefines:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.TemplateParameter.ParameteredElement"/>"
        /// </summary>
        /// xmi:id="ConnectableElementTemplateParameter-parameteredElement"
        /// xmi:association="A_connectableElement_templateParameter_parameteredElement"
        ConnectableElement ParameteredElement { get;set; }
        #endregion
        }
    }
