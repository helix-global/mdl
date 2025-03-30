using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="ControlFlow"/> is an <see cref="ActivityEdge"/> traversed by control tokens or object tokens of control type, which are use to control the execution of ExecutableNodes.
    /// </summary>
    /// <rule language="OCL">
    ///   ControlFlows may not have ObjectNodes at either end, except for ObjectNodes with control type.
    ///   <![CDATA[
    ///     (source.oclIsKindOf(ObjectNode) implies source.oclAsType(ObjectNode).isControlType) and 
    ///     (target.oclIsKindOf(ObjectNode) implies target.oclAsType(ObjectNode).isControlType)
    ///   ]]>
    ///   xmi:id="ControlFlow-object_nodes"
    /// </rule>
    /// xmi:id="ControlFlow"
    public interface ControlFlow : ActivityEdge
        {
        }
    }
