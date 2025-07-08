namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    /// <summary>
    /// <p>An Artifact represents a physical piece of information that is used or produced by a software development process. Examples of Artifacts include models, source files, scripts, and binary executable files. An Artifact may constitute the implementation of a deployable component.</p>
    /// <p>In the metamodel, an Artifact is a Classifier with an optional aggregation association to one or more Components. As a Classifier, Artifacts may have Features that represent properties of the Artifact (e.g., a “read-only” attribute or a “check in” operation).</p>
    /// <p>It should be noted that sometimes Artifacts may need to be linked to Classifiers directly, without introducing a ‘Component.’ For instance, in the context of code generation, the resulting Artifacts (source code files) are never deployed as Components. In that case, a «derive» Dependency can be used between the Classifier(s) and the generated Artifact.</p>
    /// <p>The standard stereotypes of Artifact are «file», the subclasses of «file» («executable», «source», «library», and «document»), and «table». These stereotypes can be further subclassed into implementation and platform specific stereotypes (e.g., «jarFile» for Java archives).</p>
    /// <p>
    ///   <b>Stereotypes:</b>
    ///   <table>
    ///    <tr>
    ///     <td>"document"</td>
    ///     <td>Class</td>
    ///     <td>Denotes a generic file that is not a «source» file or «executable». Subclass of «file».</td>
    ///    </tr>
    ///    <tr>
    ///     <td>"executable"</td>
    ///     <td>Class</td>
    ///     <td>Denotes a program file that can be executed on a computer system. Subclass of «file».</td>
    ///    </tr>
    ///    <tr>
    ///     <td>"file"</td>
    ///     <td>Class</td>
    ///     <td>Denotes a physical file in the context of the system developed.</td>
    ///    </tr>
    ///    <tr>
    ///     <td>"library"</td>
    ///     <td>Class</td>
    ///     <td>Denotes a static or dynamic library file. Subclass of «file».</td>
    ///    </tr>
    ///    <tr>
    ///     <td>"source"</td>
    ///     <td>Class</td>
    ///     <td>Denotes a source file that can be compiled into an executable file. Subclass of «file».</td>
    ///    </tr>
    ///    <tr>
    ///     <td>"table"</td>
    ///     <td>Class</td>
    ///     <td> Denotes a database table.</td>
    ///    </tr>
    ///   </table>
    /// </p>
    /// </summary>
    public interface Artifact : Classifier
        {
        /// <summary>
        /// The deployable Component(s) that are implemented by this Artifact.
        /// </summary>
        Component[] implementationLocation { get; }
        }
    }
