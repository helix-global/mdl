using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Comment"/> is a textual annotation that can be attached to a set of Elements.
    /// </summary>
    /// xmi:id="Comment"
    public interface Comment : Element
        {
        #region P:AnnotatedElement:Element[]
        /// <summary>
        /// References the <see cref="Element"/>(s) being commented.
        /// </summary>
        /// xmi:id="Comment-annotatedElement"
        /// xmi:association="A_annotatedElement_comment"
        Element[] AnnotatedElement { get; }
        #endregion
        #region P:Body:String
        /// <summary>
        /// Specifies a string that is the comment.
        /// </summary>
        /// xmi:id="Comment-body"
        [Multiplicity("0..1")]
        String Body { get; }
        #endregion
        }
    }
