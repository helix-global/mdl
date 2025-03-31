using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="WriteLinkAction"/> is an abstract class for LinkActions that create and destroy links.
    /// </summary>
    /// <rule language="OCL">
    ///   The visibility of at least one end must allow access from the context <see cref="Classifier"/> of the <see cref="WriteLinkAction"/>.
    ///   <![CDATA[
    ///     endData.end->exists(end |
    ///       end.type=_'context' or
    ///       end.visibility=VisibilityKind::public or 
    ///       end.visibility=VisibilityKind::protected and
    ///       endData.end->exists(other | 
    ///         other<>end and _'context'.conformsTo(other.type.oclAsType(Classifier))))
    ///     
    ///   ]]>
    ///   xmi:id="WriteLinkAction-allow_access"
    /// </rule>
    /// xmi:id="WriteLinkAction"
    public interface WriteLinkAction : LinkAction
        {
        }
    }
