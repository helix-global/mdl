using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="Actor"/> specifies a role played by a user or any other system that interacts with the subject.
    /// </summary>
    /// <rule language="OCL">
    ///   An <see cref="Actor"/> can only have Associations to UseCases, Components, and Classes. Furthermore these Associations must be binary.
    ///   <![CDATA[
    ///     Association.allInstances()->forAll( a |
    ///       a.memberEnd->collect(type)->includes(self) implies
    ///       (
    ///         a.memberEnd->size() = 2 and
    ///         let actorEnd : Property = a.memberEnd->any(type = self) in
    ///           actorEnd.opposite.class.oclIsKindOf(UseCase) or
    ///           ( actorEnd.opposite.class.oclIsKindOf(Class) and not
    ///              actorEnd.opposite.class.oclIsKindOf(Behavior))
    ///           )
    ///       )
    ///   ]]>
    ///   xmi:id="Actor-associations"
    /// </rule>
    /// <rule language="OCL">
    ///   An <see cref="Actor"/> must have a name.
    ///   <![CDATA[
    ///     name->notEmpty()
    ///   ]]>
    ///   xmi:id="Actor-must_have_name"
    /// </rule>
    /// xmi:id="Actor"
    public interface Actor : BehavioredClassifier
        {
        }
    }
