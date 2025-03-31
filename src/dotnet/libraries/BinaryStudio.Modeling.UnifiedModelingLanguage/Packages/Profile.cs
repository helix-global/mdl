using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A profile defines limited extensions to a reference metamodel with the purpose of adapting the metamodel to a specific platform or domain.
    /// </summary>
    /// <rule language="OCL">
    ///   An element imported as a metaclassReference is not specialized or generalized in a <see cref="Profile"/>.
    ///   <![CDATA[
    ///     metaclassReference.importedElement->
    ///     	select(c | c.oclIsKindOf(Classifier) and
    ///     		(c.oclAsType(Classifier).allParents()->collect(namespace)->includes(self)))->isEmpty()
    ///     and 
    ///     packagedElement->
    ///         select(oclIsKindOf(Classifier))->collect(oclAsType(Classifier).allParents())->
    ///            intersection(metaclassReference.importedElement->select(oclIsKindOf(Classifier))->collect(oclAsType(Classifier)))->isEmpty()
    ///   ]]>
    ///   xmi:id="Profile-metaclass_reference_not_specialized"
    /// </rule>
    /// <rule language="OCL">
    ///   All elements imported either as metaclassReferences or through metamodelReferences are members of the same base reference metamodel.
    ///   <![CDATA[
    ///     metamodelReference.importedPackage.elementImport.importedElement.allOwningPackages()->
    ///       union(metaclassReference.importedElement.allOwningPackages() )->notEmpty()
    ///   ]]>
    ///   xmi:id="Profile-references_same_metamodel"
    /// </rule>
    /// xmi:id="Profile"
    public interface Profile : Package
        {
        #region P:MetaclassReference:ElementImport[]
        /// <summary>
        /// References a metaclass that may be extended.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.ElementImport"/>"
        /// </summary>
        /// xmi:id="Profile-metaclassReference"
        /// xmi:aggregation="composite"
        /// xmi:association="A_metaclassReference_profile"
        ElementImport[] MetaclassReference { get; }
        #endregion
        #region P:MetamodelReference:PackageImport[]
        /// <summary>
        /// References a package containing (directly or indirectly) metaclasses that may be extended.
        /// Subsets:
        ///   <see cref="P:BinaryStudio.Modeling.UnifiedModelingLanguage.Namespace.PackageImport"/>"
        /// </summary>
        /// xmi:id="Profile-metamodelReference"
        /// xmi:aggregation="composite"
        /// xmi:association="A_metamodelReference_profile"
        PackageImport[] MetamodelReference { get; }
        #endregion
        }
    }
