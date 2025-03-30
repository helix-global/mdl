using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="Action"/> is the fundamental unit of executable functionality. The execution of an <see cref="Action"/> represents some transformation or processing in the modeled system. Actions provide the ExecutableNodes within Activities and may also be used within Interactions.
    /// </summary>
    /// xmi:id="Action"
    public interface Action : ExecutableNode
        {
        #region P:Context:Classifier
        /// <summary>
        /// The <see cref="Context"/> <see cref="Classifier"/> of the <see cref="Behavior"/> that contains this <see cref="Action"/>, or the <see cref="Behavior"/> itself if it has no <see cref="Context"/>.
        /// </summary>
        /// xmi:id="Action-context"
        Classifier Context { get; }
        #endregion
        #region P:Input:InputPin[]
        /// <summary>
        /// The ordered set of InputPins representing the inputs to the <see cref="Action"/>.
        /// </summary>
        /// xmi:id="Action-input"
        /// xmi:aggregation="composite"
        InputPin[] Input { get; }
        #endregion
        #region P:IsLocallyReentrant:Boolean
        /// <summary>
        /// If true, the <see cref="Action"/> can begin a new, concurrent execution, even if there is already another execution of the <see cref="Action"/> ongoing. If false, the <see cref="Action"/> cannot begin a new execution until any previous execution has completed.
        /// </summary>
        /// xmi:id="Action-isLocallyReentrant"
        Boolean IsLocallyReentrant { get; }
        #endregion
        #region P:LocalPostcondition:Constraint[]
        /// <summary>
        /// A <see cref="Constraint"/> that must be satisfied when execution of the <see cref="Action"/> is completed.
        /// </summary>
        /// xmi:id="Action-localPostcondition"
        /// xmi:aggregation="composite"
        Constraint[] LocalPostcondition { get; }
        #endregion
        #region P:LocalPrecondition:Constraint[]
        /// <summary>
        /// A <see cref="Constraint"/> that must be satisfied when execution of the <see cref="Action"/> is started.
        /// </summary>
        /// xmi:id="Action-localPrecondition"
        /// xmi:aggregation="composite"
        Constraint[] LocalPrecondition { get; }
        #endregion
        #region P:Output:OutputPin[]
        /// <summary>
        /// The ordered set of OutputPins representing outputs from the <see cref="Action"/>.
        /// </summary>
        /// xmi:id="Action-output"
        /// xmi:aggregation="composite"
        OutputPin[] Output { get; }
        #endregion

        #region M:context:Classifier
        /// <summary>
        /// The derivation for the <see cref="Context"/> property.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (let behavior: Behavior = self.containingBehavior() in
        ///     if behavior=null then null
        ///     else if behavior._'context' = null then behavior
        ///     else behavior._'context'
        ///     endif
        ///     endif)
        ///   ]]>
        ///   xmi:id="Action-context.1-spec"
        /// </rule>
        /// xmi:id="Action-context.1"
        /// xmi:is-query="true"
        Classifier context();
        #endregion
        #region M:allActions:Action[]
        /// <summary>
        /// Return this <see cref="Action"/> and all Actions contained directly or indirectly in it. By default only the <see cref="Action"/> itself is returned, but the operation is overridden for StructuredActivityNodes.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (self->asSet())
        ///   ]]>
        ///   xmi:id="Action-allActions-spec"
        /// </rule>
        /// xmi:id="Action-allActions"
        /// xmi:is-query="true"
        Action[] allActions();
        #endregion
        #region M:allOwnedNodes:ActivityNode[]
        /// <summary>
        /// Returns all the ActivityNodes directly or indirectly owned by this <see cref="Action"/>. This includes at least all the Pins of the <see cref="Action"/>.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (input.oclAsType(Pin)->asSet()->union(output->asSet()))
        ///   ]]>
        ///   xmi:id="Action-allOwnedNodes-spec"
        /// </rule>
        /// xmi:id="Action-allOwnedNodes"
        /// xmi:is-query="true"
        ActivityNode[] allOwnedNodes();
        #endregion
        #region M:containingBehavior:Behavior
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (if inStructuredNode<>null then inStructuredNode.containingBehavior() 
        ///     else if activity<>null then activity
        ///     else interaction 
        ///     endif
        ///     endif
        ///     )
        ///   ]]>
        ///   xmi:id="Action-containingBehavior-spec"
        /// </rule>
        /// xmi:id="Action-containingBehavior"
        /// xmi:is-query="true"
        Behavior containingBehavior();
        #endregion
        }
    }
