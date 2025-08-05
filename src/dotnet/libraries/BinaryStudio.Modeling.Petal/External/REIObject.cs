using System;
using RationalRose;

namespace BinaryStudio.Modeling.Petal.External
    {
    public interface IREIObject
        {
        String IdentifyClass { get; }
        }

    public class REIObject<T> : IREIObject
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