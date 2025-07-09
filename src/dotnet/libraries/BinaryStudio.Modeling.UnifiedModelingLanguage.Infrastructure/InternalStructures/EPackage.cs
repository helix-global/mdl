using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EPackage : ENamespace,Package
        {
        public Boolean isRoot { get; }
        public Boolean isLeaf { get; }
        public Boolean isAbstract { get; }
        public Generalization[] generalization { get; }
        public Generalization[] specialization { get; }
        public IList<ElementImport> elementImport { get; }
        }
    }