using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="OpaqueBehavior"/> is a <see cref="Behavior"/> whose <see cref="Specification"/> is given in a textual <see cref="Language"/> other than UML.
    /// </summary>
    /// xmi:id="OpaqueBehavior"
    public interface OpaqueBehavior : Behavior
        {
        #region P:Body:String[]
        /// <summary>
        /// Specifies the behavior in one or more languages.
        /// </summary>
        /// xmi:id="OpaqueBehavior-body"
        [Ordered]
        String[] Body { get; }
        #endregion
        #region P:Language:String[]
        /// <summary>
        /// Languages the <see cref="Body"/> strings use in the same order as the <see cref="Body"/> strings.
        /// </summary>
        /// xmi:id="OpaqueBehavior-language"
        [Ordered]
        String[] Language { get; }
        #endregion
        }
    }
