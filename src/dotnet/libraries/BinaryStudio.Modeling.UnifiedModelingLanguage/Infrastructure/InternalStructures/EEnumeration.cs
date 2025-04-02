using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EEnumeration : EDataType,Enumeration
        {
        public IList<EnumerationLiteral> OwnedLiteral { get; }

        public EEnumeration()
            {
            OwnedLiteral = new List<EnumerationLiteral>();
            }
        }
    }