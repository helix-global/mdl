using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="Reception"/> is a declaration stating that a <see cref="Classifier"/> is prepared to react to the receipt of a <see cref="Signal"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   A <see cref="Reception"/> has the same name as its signal
    ///   <![CDATA[
    ///     name = signal.name
    ///   ]]>
    ///   xmi:id="Reception-same_name_as_signal"
    /// </rule>
    /// <rule language="OCL">
    ///   A <see cref="Reception"/>'s parameters match the ownedAttributes of its signal by name, type, and multiplicity
    ///   <![CDATA[
    ///     signal.ownedAttribute->size() = ownedParameter->size() and
    ///     Sequence{1..signal.ownedAttribute->size()}->forAll( i | 
    ///         ownedParameter->at(i).direction = ParameterDirectionKind::_'in' and 
    ///         ownedParameter->at(i).name = signal.ownedAttribute->at(i).name and
    ///         ownedParameter->at(i).type = signal.ownedAttribute->at(i).type and
    ///         ownedParameter->at(i).lowerBound() = signal.ownedAttribute->at(i).lowerBound() and
    ///         ownedParameter->at(i).upperBound() = signal.ownedAttribute->at(i).upperBound()
    ///     )
    ///   ]]>
    ///   xmi:id="Reception-same_structure_as_signal"
    /// </rule>
    /// xmi:id="Reception"
    public interface Reception : BehavioralFeature
        {
        #region P:Signal:Signal
        /// <summary>
        /// The <see cref="Signal"/> that this <see cref="Reception"/> handles.
        /// </summary>
        /// xmi:id="Reception-signal"
        /// xmi:association="A_signal_reception"
        Signal Signal { get; }
        #endregion
        }
    }
