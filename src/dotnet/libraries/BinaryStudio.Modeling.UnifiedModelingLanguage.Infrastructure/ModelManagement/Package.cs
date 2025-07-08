using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public interface Package : Namespace,GeneralizableElement
        {
        IList<ElementImport> elementImport { get; }
        }
    }
