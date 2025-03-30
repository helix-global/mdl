using System;

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
        Element[] AnnotatedElement { get; }
        #endregion
        #region P:Body:String
        /// <summary>
        /// Specifies a string that is the comment.
        /// </summary>
        /// xmi:id="Comment-body"
        String Body { get; }
        #endregion
        }
    }
