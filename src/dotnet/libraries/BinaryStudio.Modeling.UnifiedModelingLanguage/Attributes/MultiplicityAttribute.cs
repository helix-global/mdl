using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes
    {
    public class MultiplicityAttribute : Attribute
        {
        public String Multiplicity { get; }
        public MultiplicityAttribute(String multiplicity)
            {
            Multiplicity = multiplicity;
            }
        }
    }