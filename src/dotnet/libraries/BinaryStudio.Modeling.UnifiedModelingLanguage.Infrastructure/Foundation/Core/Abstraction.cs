namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    /// <summary>
    /// <p>An abstraction is a <see cref="Dependency"/> relationship that relates two elements or sets of elements that represent the same concept at different levels of abstraction or from different viewpoints.</p>
    /// <p>In the metamodel, an <see cref="Abstraction"/> is a <see cref="Dependency"/> in which there is a mapping between the supplier and the client. Depending on the specific stereotype of <see cref="Abstraction"/>, the mapping may be formal or informal, and it may be unidirectional or bidirectional.</p>
    /// <p>If an <see cref="Abstraction"/> element has more than one client element, the supplier element maps into the set of client elements as a group. For example, an analysis-level class might be split into several design-level classes. The situation is similar if there is more than one supplier element.</p>
    /// <p>The UML standard stereotyped classes of <see cref="Abstraction"/> are Derivation, Realization, Refinement, and Trace. (These are the names for the Abstraction class with the stereotypes "derive", "realize", "refine", and "trace", respectively.)</p>
    /// <p>
    ///   <b>Stereotypes:</b>
    ///   <table>
    ///    <tr>
    ///     <td>"derive"</td>
    ///     <td>Class</td>
    ///     <td>(Name for the stereotyped class is Derivation.) Specifies a derivation relationship among model elements that are usually, but not necessarily, of the same type. A derived dependency specifies that the client may be computed from the supplier. The mapping specifies the computation. The client may be implemented for design reasons, such as efficiency, even though it is logically redundant.</td>
    ///    </tr>
    ///    <tr>
    ///     <td>"realize"</td>
    ///     <td>Class</td>
    ///     <td>(Name for the stereotyped class is Realization.) Specifies a realization relationship between a specification model element or elements (the supplier) and a model element or elements that implement it (the client). The implementation model element is required to support all of the operations or received signals that the specification model element declares. The implementation model element must make or inherit its own declarations of the operations and signal receptions. The mapping specifies the relationship between the two. The mapping may or may not be computable. Realization can be used to model stepwise refinement, optimizations, transformations, templates, model synthesis, framework composition, etc.</td>
    ///    </tr>
    ///    <tr>
    ///     <td>"refine"</td>
    ///     <td>Class</td>
    ///     <td>(Name for the stereotyped class is Refinement.) Specifies refinement relationship between model elements at different semantic levels, such as analysis and design. The mapping specifies the relationship between the two elements or sets of elements. The mapping may or may not be computable, and it may be unidirectional or bidirectional. Refinement can be used to model transformations from analysis to design and other such changes.</td>
    ///    </tr>
    ///    <tr>
    ///     <td>"trace"</td>
    ///     <td>Class</td>
    ///     <td>(Name for the stereotyped class is Trace.) Specifies a trace relationship between model elements or sets of model elements that represent the same concept in different models. Traces are mainly used for tracking requirements and changes across models. Since model changes can occur in both directions, the directionality of the dependency can often be ignored. The mapping specifies the relationship between the two, but it is rarely computable and is usually informal.</td>
    ///    </tr>
    ///   </table>
    /// </p>
    /// </summary>
    public interface Abstraction : Dependency
        {
        /// <summary>
        /// A <see cref="MappingExpression"/> that states the abstraction relationship between the supplier and the client. In some cases, such as Derivation, it is usually formal and unidirectional; in other cases, such as Trace, it is usually informal and bidirectional. The mapping attribute is optional and may be omitted if the precise relationship between the elements is not specified.
        /// </summary>
        MappingExpression mapping { get; }
        }
    }
