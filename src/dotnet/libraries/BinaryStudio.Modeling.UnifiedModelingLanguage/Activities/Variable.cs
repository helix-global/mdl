using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Variable"/> is a <see cref="ConnectableElement"/> that may store values during the execution of an <see cref="Activity"/>. Reading and writing the values of a <see cref="Variable"/> provides an alternative means for passing data than the use of ObjectFlows. A <see cref="Variable"/> may be owned directly by an <see cref="Activity"/>, in which case it is accessible from anywhere within that activity, or it may be owned by a <see cref="StructuredActivityNode"/>, in which case it is only accessible within that node.
    /// </summary>
    /// xmi:id="Variable"
    public interface Variable : ConnectableElement,MultiplicityElement
        {
        #region P:ActivityScope:Activity
        /// <summary>
        /// An <see cref="Activity"/> that owns the <see cref="Variable"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        /// </summary>
        /// xmi:id="Variable-activityScope"
        /// xmi:association="A_variable_activityScope"
        [Multiplicity("0..1")]
        Activity ActivityScope { get; }
        #endregion
        #region P:Scope:StructuredActivityNode
        /// <summary>
        /// A <see cref="StructuredActivityNode"/> that owns the <see cref="Variable"/>.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.Namespace"/>"
        /// </summary>
        /// xmi:id="Variable-scope"
        /// xmi:association="A_variable_scope"
        [Multiplicity("0..1")]
        StructuredActivityNode Scope { get; }
        #endregion

        #region M:isAccessibleBy(Action):Boolean
        /// <summary>
        /// A <see cref="Variable"/> is accessible by Actions within its <see cref="Scope"/> (the <see cref="Activity"/> or <see cref="StructuredActivityNode"/> that owns it).
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if scope<>null then scope.allOwnedNodes()->includes(a)
        ///     else a.containingActivity()=activityScope
        ///     endif)
        ///   ]]>
        ///   xmi:id="Variable-isAccessibleBy-spec"
        /// </rule>
        /// xmi:id="Variable-isAccessibleBy"
        /// xmi:is-query="true"
        Boolean isAccessibleBy(Action a);
        #endregion
        }
    }
