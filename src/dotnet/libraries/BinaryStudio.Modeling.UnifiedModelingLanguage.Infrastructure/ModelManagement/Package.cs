using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    /// <summary>
    /// 
    /// </summary>
    public interface Package : Namespace,GeneralizableElement
        {
        IList<ElementImport> elementImport { get; }
        }
    }
