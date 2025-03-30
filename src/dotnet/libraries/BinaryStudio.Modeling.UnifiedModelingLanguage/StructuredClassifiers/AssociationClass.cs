using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A model element that has both <see cref="Association"/> and <see cref="Class"/> properties. An <see cref="AssociationClass"/> can be seen as an <see cref="Association"/> that also has <see cref="Class"/> properties, or as a <see cref="Class"/> that also has <see cref="Association"/> properties. It not only connects a set of Classifiers but also defines a set of Features that belong to the <see cref="Association"/> itself and not to any of the associated Classifiers.
    /// </summary>
    /// <rule language="OCL">
    ///   An <see cref="AssociationClass"/> cannot be defined between itself and something else.
    ///   <![CDATA[
    ///     self.endType()->excludes(self) and self.endType()->collect(et|et.oclAsType(Classifier).allParents())->flatten()->excludes(self)
    ///   ]]>
    ///   xmi:id="AssociationClass-cannot_be_defined"
    /// </rule>
    /// <rule language="OCL">
    ///   The owned attributes and owned ends of an <see cref="AssociationClass"/> are disjoint.
    ///   <![CDATA[
    ///     ownedAttribute->intersection(ownedEnd)->isEmpty()
    ///   ]]>
    ///   xmi:id="AssociationClass-disjoint_attributes_ends"
    /// </rule>
    /// xmi:id="AssociationClass"
    public interface AssociationClass : Class,Association
        {
        }
    }
