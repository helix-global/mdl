using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="FinalNode"/> is an abstract <see cref="ControlNode"/> at which a flow in an <see cref="Activity"/> stops.
    /// </summary>
    /// <rule language="OCL">
    ///   A <see cref="FinalNode"/> has no outgoing ActivityEdges.
    ///   <![CDATA[
    ///     outgoing->isEmpty()
    ///   ]]>
    ///   xmi:id="FinalNode-no_outgoing_edges"
    /// </rule>
    /// xmi:id="FinalNode"
    public interface FinalNode : ControlNode
        {
        }
    }
