using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="OperationTemplateParameter"/> exposes an <see cref="Operation"/> as a formal parameter for a template.
    /// </summary>
    /// <rule language="OCL">
    ///   <![CDATA[
    ///     default->notEmpty() implies (default.oclIsKindOf(Operation) and (let defaultOp : Operation = default.oclAsType(Operation) in 
    ///         defaultOp.ownedParameter->size() = parameteredElement.ownedParameter->size() and
    ///         Sequence{1.. defaultOp.ownedParameter->size()}->forAll( ix | 
    ///             let p1: Parameter = defaultOp.ownedParameter->at(ix), p2 : Parameter = parameteredElement.ownedParameter->at(ix) in
    ///               p1.type = p2.type and p1.upper = p2.upper and p1.lower = p2.lower and p1.direction = p2.direction and p1.isOrdered = p2.isOrdered and p1.isUnique = p2.isUnique)))
    ///   ]]>
    ///   xmi:id="OperationTemplateParameter-match_default_signature"
    /// </rule>
    /// xmi:id="OperationTemplateParameter"
    public interface OperationTemplateParameter : TemplateParameter
        {
        #region P:ParameteredElement:Operation
        /// <summary>
        /// The <see cref="Operation"/> exposed by this <see cref="OperationTemplateParameter"/>.
        /// </summary>
        /// xmi:id="OperationTemplateParameter-parameteredElement"
        /// xmi:redefines="TemplateParameter-parameteredElement{<see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.TemplateParameter.ParameteredElement"/>}"
        Operation ParameteredElement { get; }
        #endregion
        }
    }
