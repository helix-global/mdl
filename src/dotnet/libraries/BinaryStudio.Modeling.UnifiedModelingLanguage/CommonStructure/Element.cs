using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="Element"/> is a constituent of a model. As such, it has the capability of owning other Elements.
    /// </summary>
    /// <rule language="OCL">
    ///   Elements that must be owned must have an owner.
    ///   <![CDATA[
    ///     mustBeOwned() implies owner->notEmpty()
    ///   ]]>
    ///   xmi:id="Element-has_owner"
    /// </rule>
    /// <rule language="OCL">
    ///   An element may not directly or indirectly own itself.
    ///   <![CDATA[
    ///     not allOwnedElements()->includes(self)
    ///   ]]>
    ///   xmi:id="Element-not_own_self"
    /// </rule>
    /// xmi:id="Element"
    public interface Element
        {
        #region P:OwnedComment:Comment[]
        /// <summary>
        /// The Comments owned by this <see cref="Element"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Element.OwnedElement"/>"
        /// </summary>
        /// xmi:id="Element-ownedComment"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedComment_owningElement"
        Comment[] OwnedComment { get; }
        #endregion
        #region P:OwnedElement:Element[]
        /// <summary>
        /// The Elements owned by this <see cref="Element"/>.
        /// </summary>
        /// xmi:id="Element-ownedElement"
        /// xmi:aggregation="composite"
        /// xmi:association="A_ownedElement_owner"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        [Union]
        Element[] OwnedElement { get; }
        #endregion
        #region P:Owner:Element
        /// <summary>
        /// The <see cref="Element"/> that owns this <see cref="Element"/>.
        /// </summary>
        /// xmi:id="Element-owner"
        /// xmi:association="A_ownedElement_owner"
        /// xmi:is-derived="true"
        /// xmi:is-readonly="true"
        [Multiplicity("0..1")][Union]
        Element Owner { get; }
        #endregion

        #region M:allOwnedElements:Element[]
        /// <summary>
        /// The query <see cref="allOwnedElements"/> gives all of the direct and indirect ownedElements of an <see cref="Element"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (ownedElement->union(ownedElement->collect(e | e.allOwnedElements()))->asSet())
        ///   ]]>
        ///   xmi:id="Element-allOwnedElements-spec"
        /// </rule>
        /// xmi:id="Element-allOwnedElements"
        /// xmi:is-query="true"
        Element[] allOwnedElements();
        #endregion
        #region M:mustBeOwned:Boolean
        /// <summary>
        /// The query <see cref="mustBeOwned"/> indicates whether Elements of this type must have an <see cref="Owner"/>. Subclasses of <see cref="Element"/> that do not require an <see cref="Owner"/> must override this operation.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (true)
        ///   ]]>
        ///   xmi:id="Element-mustBeOwned-spec"
        /// </rule>
        /// xmi:id="Element-mustBeOwned"
        /// xmi:is-query="true"
        Boolean mustBeOwned();
        #endregion
        }
    }
