namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    /// <summary>
    /// An association class is an association that is also a class. It not only connects a set of classifiers but also defines a set of features that belong to the relationship itself and not any of the classifiers.
    /// <p>
    ///   <b>Inherited Features</b>
    /// </p>
    /// </summary>
    public interface AssociationClass : Association,Class
        {
        }
    }
