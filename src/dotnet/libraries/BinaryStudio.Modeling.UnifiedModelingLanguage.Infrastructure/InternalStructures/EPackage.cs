using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EPackage : ENamespace,Package
        {
        public Boolean isRoot { get;set; }
        public Boolean isLeaf { get;set; }
        public Boolean isAbstract { get;set; }
        public IList<Generalization> generalization { get; }
        public IList<Generalization> specialization { get; }
        public IList<ElementImport> elementImport { get; }
        }
    }