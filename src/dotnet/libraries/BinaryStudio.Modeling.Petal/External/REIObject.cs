using System;
using RationalRose;

namespace BinaryStudio.Modeling.Petal.External
    {
    public class REIObject<T>
        where T: IREICOMObject
        {
        protected T Source { get; }
        public String IdentifyClass { get; }

        public REIObject(T source)
            {
            Source = source;
            IdentifyClass = source.IdentifyClass();
            }
        }
    }