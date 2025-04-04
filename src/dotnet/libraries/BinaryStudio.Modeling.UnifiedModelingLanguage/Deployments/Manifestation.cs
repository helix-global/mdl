﻿using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A manifestation is the concrete physical rendering of one or more model elements by an artifact.
    /// </summary>
    /// xmi:id="Manifestation"
    public interface Manifestation : Abstraction
        {
        #region P:UtilizedElement:PackageableElement
        /// <summary>
        /// The model element that is utilized in the manifestation in an <see cref="Artifact"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Dependency.Supplier"/>"
        /// </summary>
        /// xmi:id="Manifestation-utilizedElement"
        /// xmi:association="A_utilizedElement_manifestation"
        PackageableElement UtilizedElement { get;set; }
        #endregion
        }
    }
