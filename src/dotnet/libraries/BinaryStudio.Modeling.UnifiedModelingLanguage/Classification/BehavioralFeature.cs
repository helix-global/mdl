using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A <see cref="BehavioralFeature"/> is a feature of a <see cref="Classifier"/> that specifies an aspect of the behavior of its instances.  A <see cref="BehavioralFeature"/> is implemented (realized) by a <see cref="Behavior"/>. A <see cref="BehavioralFeature"/> specifies that a <see cref="Classifier"/> will respond to a designated request by invoking its implementing <see cref="Method"/>.
    /// </summary>
    /// <rule language="OCL">
    ///   When isAbstract is true there are no methods.
    ///   <![CDATA[
    ///     isAbstract implies method->isEmpty()
    ///   ]]>
    ///   xmi:id="BehavioralFeature-abstract_no_method"
    /// </rule>
    /// xmi:id="BehavioralFeature"
    public interface BehavioralFeature : Feature,Namespace
        {
        #region P:Concurrency:CallConcurrencyKind
        /// <summary>
        /// Specifies the semantics of concurrent calls to the same passive instance (i.e., an instance originating from a <see cref="Class"/> with isActive being false). Active instances control access to their own BehavioralFeatures.
        /// </summary>
        /// xmi:id="BehavioralFeature-concurrency"
        CallConcurrencyKind Concurrency { get; }
        #endregion
        #region P:IsAbstract:Boolean
        /// <summary>
        /// If true, then the <see cref="BehavioralFeature"/> does not have an implementation, and one must be supplied by a more specific <see cref="Classifier"/>. If false, the <see cref="BehavioralFeature"/> must have an implementation in the <see cref="Classifier"/> or one must be inherited.
        /// </summary>
        /// xmi:id="BehavioralFeature-isAbstract"
        Boolean IsAbstract { get; }
        #endregion
        #region P:Method:Behavior[]
        /// <summary>
        /// A <see cref="Behavior"/> that implements the <see cref="BehavioralFeature"/>. There may be at most one <see cref="Behavior"/> for a particular pairing of a <see cref="Classifier"/> (as <see cref="Owner"/> of the <see cref="Behavior"/>) and a <see cref="BehavioralFeature"/> (as specification of the <see cref="Behavior"/>).
        /// </summary>
        /// xmi:id="BehavioralFeature-method"
        Behavior[] Method { get; }
        #endregion
        #region P:OwnedParameter:Parameter[]
        /// <summary>
        /// The ordered set of formal Parameters of this <see cref="BehavioralFeature"/>.
        /// </summary>
        /// xmi:id="BehavioralFeature-ownedParameter"
        /// xmi:aggregation="composite"
        Parameter[] OwnedParameter { get; }
        #endregion
        #region P:OwnedParameterSet:ParameterSet[]
        /// <summary>
        /// The ParameterSets owned by this <see cref="BehavioralFeature"/>.
        /// </summary>
        /// xmi:id="BehavioralFeature-ownedParameterSet"
        /// xmi:aggregation="composite"
        ParameterSet[] OwnedParameterSet { get; }
        #endregion
        #region P:RaisedException:Type[]
        /// <summary>
        /// The Types representing exceptions that may be raised during an invocation of this <see cref="BehavioralFeature"/>.
        /// </summary>
        /// xmi:id="BehavioralFeature-raisedException"
        Type[] RaisedException { get; }
        #endregion

        #region M:isDistinguishableFrom(NamedElement,Namespace):Boolean
        /// <summary>
        /// The query <see cref="isDistinguishableFrom"/> determines whether two BehavioralFeatures may coexist in the same <see cref="Namespace"/>. It specifies that they must have different signatures.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = ((n.oclIsKindOf(BehavioralFeature) and ns.getNamesOfMember(self)->intersection(ns.getNamesOfMember(n))->notEmpty()) implies
        ///       Set{self}->including(n.oclAsType(BehavioralFeature))->isUnique(ownedParameter->collect(p|
        ///       Tuple { name=p.name, type=p.type,effect=p.effect,direction=p.direction,isException=p.isException,
        ///                   isStream=p.isStream,isOrdered=p.isOrdered,isUnique=p.isUnique,lower=p.lower, upper=p.upper }))
        ///       )
        ///   ]]>
        ///   xmi:id="BehavioralFeature-isDistinguishableFrom-spec"
        /// </rule>
        /// xmi:id="BehavioralFeature-isDistinguishableFrom"
        /// xmi:is-query="true"
        /// xmi:redefines="NamedElement-isDistinguishableFrom{<see cref="M:BinaryStudio.Modeling.UnifiedModelingLanguage.NamedElement.isDistinguishableFrom"/>}"
        Boolean isDistinguishableFrom(NamedElement n,Namespace ns);
        #endregion
        #region M:inputParameters:Parameter[]
        /// <summary>
        /// The ownedParameters with direction in and inout.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (ownedParameter->select(direction=ParameterDirectionKind::_'in' or direction=ParameterDirectionKind::inout))
        ///   ]]>
        ///   xmi:id="BehavioralFeature-inputParameters-spec"
        /// </rule>
        /// xmi:id="BehavioralFeature-inputParameters"
        /// xmi:is-query="true"
        Parameter[] inputParameters();
        #endregion
        #region M:outputParameters:Parameter[]
        /// <summary>
        /// The ownedParameters with direction out, inout, or return.
        /// </summary>
        /// <rule language="OCL">
        ///   <![CDATA[
        ///     result = (ownedParameter->select(direction=ParameterDirectionKind::out or direction=ParameterDirectionKind::inout or direction=ParameterDirectionKind::return))
        ///   ]]>
        ///   xmi:id="BehavioralFeature-outputParameters-spec"
        /// </rule>
        /// xmi:id="BehavioralFeature-outputParameters"
        /// xmi:is-query="true"
        Parameter[] outputParameters();
        #endregion
        }
    }
