using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// InformationItems represent many kinds of information that can flow from sources to targets in very abstract ways.  They represent the kinds of information that may move within a system, but do not elaborate details of the transferred information.  Details of transferred information are the province of other Classifiers that may ultimately define InformationItems.  Consequently, InformationItems cannot be instantiated and do not themselves have features, generalizations, or associations. An important use of InformationItems is to represent information during early design stages, possibly before the detailed modeling decisions that will ultimately define them have been made. Another purpose of InformationItems is to abstract portions of complex models in less precise, but perhaps more <see cref="General"/> and communicable, ways. 
    /// </summary>
    /// <rule language="OCL">
    ///   The sources and targets of an information item (its related information flows) must designate subsets of the sources and targets of the representation information item, if any. The Classifiers that can realize an information item can only be of the following kind: <see cref="Class"/>, <see cref="Interface"/>, <see cref="InformationItem"/>, <see cref="Signal"/>, <see cref="Component"/>.
    ///   <![CDATA[
    ///     (self.represented->select(oclIsKindOf(InformationItem))->forAll(p |
    ///       p.conveyingFlow.source->forAll(q | self.conveyingFlow.source->includes(q)) and
    ///         p.conveyingFlow.target->forAll(q | self.conveyingFlow.target->includes(q)))) and
    ///           (self.represented->forAll(oclIsKindOf(Class) or oclIsKindOf(Interface) or
    ///             oclIsKindOf(InformationItem) or oclIsKindOf(Signal) or oclIsKindOf(Component)))
    ///   ]]>
    ///   xmi:id="InformationItem-sources_and_targets"
    /// </rule>
    /// <rule language="OCL">
    ///   An informationItem has no feature, no generalization, and no associations.
    ///   <![CDATA[
    ///     self.generalization->isEmpty() and self.feature->isEmpty()
    ///   ]]>
    ///   xmi:id="InformationItem-has_no"
    /// </rule>
    /// <rule language="OCL">
    ///   It is not instantiable.
    ///   <![CDATA[
    ///     isAbstract
    ///   ]]>
    ///   xmi:id="InformationItem-not_instantiable"
    /// </rule>
    /// xmi:id="InformationItem"
    public interface InformationItem : Classifier
        {
        #region P:Represented:IList<Classifier>
        /// <summary>
        /// Determines the classifiers that will specify the structure and nature of the information. An information item represents all its <see cref="Represented"/> classifiers.
        /// </summary>
        /// xmi:id="InformationItem-represented"
        /// xmi:association="A_represented_representation"
        IList<Classifier> Represented { get; }
        #endregion
        }
    }
