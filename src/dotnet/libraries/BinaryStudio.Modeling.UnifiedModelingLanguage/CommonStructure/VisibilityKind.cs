using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="VisibilityKind"/> is an enumeration type that defines literals to determine the visibility of Elements in a model.
    /// </summary>
    /// xmi:id="VisibilityKind"
    public enum VisibilityKind
        {
        /// <summary>
        /// A Named <see cref="Element"/> with public visibility is visible to all elements that can access the contents of the <see cref="Namespace"/> that owns it.
        /// </summary>
        /// xmi:id="VisibilityKind-public"
        Public,
        /// <summary>
        /// A <see cref="NamedElement"/> with private visibility is only visible inside the <see cref="Namespace"/> that owns it.
        /// </summary>
        /// xmi:id="VisibilityKind-private"
        Private,
        /// <summary>
        /// A <see cref="NamedElement"/> with protected visibility is visible to Elements that have a generalization relationship to the <see cref="Namespace"/> that owns it.
        /// </summary>
        /// xmi:id="VisibilityKind-protected"
        Protected,
        /// <summary>
        /// A <see cref="NamedElement"/> with package visibility is visible to all Elements within the nearest enclosing <see cref="Package"/> (given that other owning Elements have proper visibility). Outside the nearest enclosing <see cref="Package"/>, a <see cref="NamedElement"/> marked as having package visibility is not visible.  Only NamedElements that are not owned by Packages can be marked as having package visibility. 
        /// </summary>
        /// xmi:id="VisibilityKind-package"
        Package
        }
    }
