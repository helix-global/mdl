using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A communication path is an association between two deployment targets, through which they are able to exchange signals and messages.
    /// </summary>
    /// <rule language="OCL">
    ///   The association ends of a <see cref="CommunicationPath"/> are typed by DeploymentTargets.
    ///   <![CDATA[
    ///     endType->forAll (oclIsKindOf(DeploymentTarget))
    ///   ]]>
    ///   xmi:id="CommunicationPath-association_ends"
    /// </rule>
    /// xmi:id="CommunicationPath"
    public interface CommunicationPath : Association
        {
        }
    }
