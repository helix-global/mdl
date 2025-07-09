using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    /// <summary>
    /// <p>An association defines a semantic relationship between classifiers. The instances of an association are a set of tuples relating instances of the classifiers. Each tuple value may appear at most once.</p>
    /// <p>In the metamodel, an Association is a declaration of a semantic relationship between Classifiers, such as Classes. An Association has at least two AssociationEnds. Each end is connected to a Classifier - the same Classifier may be connected to more than one AssociationEnd in the same Association. The Association represents a set of connections among instances of the Classifiers. An instance of an Association is a Link, which is a tuple of Instances drawn from the corresponding Classifiers.</p>
    /// <p>
    ///   <b>Stereotypes:</b>
    ///   <table>
    ///    <tr>
    ///     <td>"implicit"</td>
    ///     <td>The «implicit» stereotype is applied to an association, specifying that the association is not manifest, but rather is only conceptual.</td>
    ///    </tr>
    ///   </table>
    ///   <b>Standard Constraints:</b>
    ///   <table>
    ///    <tr>
    ///     <td>xor</td>
    ///     <td>Association</td>
    ///     <td>The {xor} constraint is applied to a set of associations, specifying that over that set, exactly one is manifest for each associated instance. Xor is an exclusive or (not inclusive or) constraint.</td>
    ///    </tr>
    ///   </table>
    ///   <b>Tagged Values:</b>
    ///   <table>
    ///    <tr>
    ///     <td>persistence</td>
    ///     <td>Association</td>
    ///     <td>Persistence denotes the permanence of the state of the association, marking it as transitory (its state is destroyed when the instance is destroyed) or persistent (its state is not destroyed when the instance is destroyed).</td>
    ///    </tr>
    ///   </table>
    /// </p>
    /// </summary>
    public interface Association : GeneralizableElement,Relationship
        {
        /// <summary>
        /// The name of the Association which, in combination with its associated Classifiers, must be unique within the enclosing namespace (usually a Package).
        /// </summary>
        String name { get; }
        AssociationRole[] associationRole { get; }
        /// <summary>
        /// An Association consists of at least two AssociationEnds, each of which represents a connection of the association to a Classifier. Each AssociationEnd specifies a set of properties that must be fulfilled for the relationship to be valid. The bulk of the structure of an Association is defined by its AssociationEnds. The classifiers belonging to the association are related to the AssociationEnds by the participant rolename association.
        /// </summary>
        [Multiplicity("2..*")] AssociationEnd[] connection { get; }
        Link[] link { get; }
        }
    }
