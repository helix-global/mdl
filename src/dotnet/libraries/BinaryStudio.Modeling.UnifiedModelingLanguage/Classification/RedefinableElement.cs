using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="RedefinableElement"/> is an element that, when defined in the context of a <see cref="Classifier"/>, can be redefined more specifically or differently in the context of another <see cref="Classifier"/> that specializes (directly or indirectly) the context <see cref="Classifier"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   A redefining element must be consistent with each redefined element.
    ///   <![CDATA[
    ///     redefinedElement->forAll(re | re.isConsistentWith(self))
    ///   ]]>
    ///   xmi:id="RedefinableElement-redefinition_consistent"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="RedefinableElement"/> can only redefine non-leaf RedefinableElements.
    ///   <![CDATA[
    ///     redefinedElement->forAll(re | not re.isLeaf)
    ///   ]]>
    ///   xmi:id="RedefinableElement-non_leaf_redefinition"
    /// </rule>
    /// <rule language="OCL">
    ///   At least one of the redefinition contexts of the redefining element must be a specialization of at least one of the redefinition contexts for each redefined element.
    ///   <![CDATA[
    ///     redefinedElement->forAll(re | self.isRedefinitionContextValid(re))
    ///   ]]>
    ///   xmi:id="RedefinableElement-redefinition_context_valid"
    /// </rule>
    /// xmi:id="RedefinableElement"
    public interface RedefinableElement : NamedElement
        {
        #region P:IsLeaf:Boolean
        /// <summary>
        /// Indicates whether it is possible to further redefine a <see cref="RedefinableElement"/>. If the value is true, then it is not possible to further redefine the <see cref="RedefinableElement"/>.
        /// </summary>
        /// xmi:id="RedefinableElement-isLeaf"
        Boolean IsLeaf { get; }
        #endregion
        #region P:RedefinedElement:RedefinableElement[]
        /// <summary>
        /// The <see cref="RedefinableElement"/> that is being redefined by this element.
        /// </summary>
        /// xmi:id="RedefinableElement-redefinedElement"
        RedefinableElement[] RedefinedElement { get; }
        #endregion
        #region P:RedefinitionContext:Classifier[]
        /// <summary>
        /// The contexts that this element may be redefined from.
        /// </summary>
        /// xmi:id="RedefinableElement-redefinitionContext"
        Classifier[] RedefinitionContext { get; }
        #endregion

        #region M:isConsistentWith(RedefinableElement):Boolean
        /// <summary>
        /// The query <see cref="isConsistentWith"/> specifies, for any two RedefinableElements in a context in which redefinition is possible, whether redefinition would be logically consistent. By default, this is false; this operation must be overridden for subclasses of <see cref="RedefinableElement"/> to define the consistency conditions.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (false)
        ///   ]]>
        ///   xmi:id="RedefinableElement-isConsistentWith-spec"
        /// </rule>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     redefiningElement.isRedefinitionContextValid(self)
        ///   ]]>
        ///   xmi:id="RedefinableElement-isConsistentWith-pre"
        ///   xmi:is-postcondition="true"
        /// </rule>
        /// xmi:id="RedefinableElement-isConsistentWith"
        /// xmi:is-query="true"
        Boolean isConsistentWith(RedefinableElement redefiningElement);
        #endregion
        #region M:isRedefinitionContextValid(RedefinableElement):Boolean
        /// <summary>
        /// The query <see cref="isRedefinitionContextValid"/> specifies whether the redefinition contexts of this <see cref="RedefinableElement"/> are properly related to the redefinition contexts of the specified <see cref="RedefinableElement"/> to allow this element to redefine the other. By default at least one of the redefinition contexts of this element must be a specialization of at least one of the redefinition contexts of the specified element.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (redefinitionContext->exists(c | c.allParents()->includesAll(redefinedElement.redefinitionContext)))
        ///   ]]>
        ///   xmi:id="RedefinableElement-isRedefinitionContextValid-spec"
        /// </rule>
        /// xmi:id="RedefinableElement-isRedefinitionContextValid"
        /// xmi:is-query="true"
        Boolean isRedefinitionContextValid(RedefinableElement redefinedElement);
        #endregion
        }
    }
