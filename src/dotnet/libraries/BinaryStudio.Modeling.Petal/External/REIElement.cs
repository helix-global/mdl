using System;
using RationalRose;

namespace BinaryStudio.Modeling.Petal.External
    {
    public class REIElement<T> : REIObject<T>
        where T: IREICOMElement
        {
        public String Name { get { return Source.Name; }}
        public REIElement(T source)
            : base(source)
            {
            }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return Name;
            }
        }
    }