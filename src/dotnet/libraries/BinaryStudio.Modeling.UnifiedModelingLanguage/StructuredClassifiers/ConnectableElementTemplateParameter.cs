using System;

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
        /// </summary>
        /// xmi:id="ConnectableElementTemplateParameter-parameteredElement"
        /// xmi:redefines="TemplateParameter-parameteredElement{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.TemplateParameter.ParameteredElement"/>}"
        ConnectableElement ParameteredElement { get; }
        #endregion
        }
    }
