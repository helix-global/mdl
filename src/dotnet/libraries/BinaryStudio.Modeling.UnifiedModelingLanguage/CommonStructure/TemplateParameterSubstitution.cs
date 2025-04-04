﻿using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="TemplateParameterSubstitution"/> relates the <see cref="Actual"/> parameter to a <see cref="Formal"/> <see cref="TemplateParameter"/> as part of a template binding.
    /// </summary>
    /// <rule language="OCL">
    ///   The actual <see cref="ParameterableElement"/> must be compatible with the formal <see cref="TemplateParameter"/>, e.g., the actual <see cref="ParameterableElement"/> for a <see cref="Class"/> <see cref="TemplateParameter"/> must be a <see cref="Class"/>.
    ///   <![CDATA[
    ///     actual->forAll(a | a.isCompatibleWith(formal.parameteredElement))
    ///   ]]>
    ///   xmi:id="TemplateParameterSubstitution-must_be_compatible"
    /// </rule>
    /// xmi:id="TemplateParameterSubstitution"
    public interface TemplateParameterSubstitution : Element
        {
        #region P:Actual:ParameterableElement
        /// <summary>
        /// The <see cref="ParameterableElement"/> that is the <see cref="Actual"/> parameter for this <see cref="TemplateParameterSubstitution"/>.
        /// </summary>
        /// xmi:id="TemplateParameterSubstitution-actual"
        /// xmi:association="A_actual_templateParameterSubstitution"
        ParameterableElement Actual { get;set; }
        #endregion
        #region P:Formal:TemplateParameter
        /// <summary>
        /// The <see cref="Formal"/> <see cref="TemplateParameter"/> that is associated with this <see cref="TemplateParameterSubstitution"/>.
        /// </summary>
        /// xmi:id="TemplateParameterSubstitution-formal"
        /// xmi:association="A_formal_templateParameterSubstitution"
        TemplateParameter Formal { get;set; }
        #endregion
        #region P:OwnedActual:ParameterableElement
        /// <summary>
        /// The <see cref="ParameterableElement"/> that is owned by this <see cref="TemplateParameterSubstitution"/> as its <see cref="Actual"/> parameter.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.TemplateParameterSubstitution.Actual"/>"
        /// </summary>
        /// xmi:id="TemplateParameterSubstitution-ownedActual"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedActual_owningTemplateParameterSubstitution"
        [Multiplicity("0..1")]
        ParameterableElement OwnedActual { get;set; }
        #endregion
        #region P:TemplateBinding:TemplateBinding
        /// <summary>
        /// The <see cref="TemplateBinding"/> that owns this <see cref="TemplateParameterSubstitution"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.Owner"/>"
        /// </summary>
        /// xmi:id="TemplateParameterSubstitution-templateBinding"
        /// xmi:association="A_parameterSubstitution_templateBinding"
        TemplateBinding TemplateBinding { get;set; }
        #endregion
        }
    }
