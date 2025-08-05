using System;
using System.Collections;
using BinaryStudio.Modeling.Petal.External;

namespace BinaryStudio.Modeling.Petal.Controls.Internal
    {
    public class EREIModel : NotifyPropertyChangedDispatcherObject<IREIModel>
        {
        public EREIModel(IREIModel source)
            :base(source)
            {
            }

        public IEnumerable NestedUnits { get {
            foreach (var unit in Source.NestedUnits) {
                Object o = null;
                switch (unit.IdentifyClass) {
                    case "Category" : 
                    default: throw new NotSupportedException();
                    }
                if (o != null) {
                    yield return o;
                    }
                }
            }}
        }
    }