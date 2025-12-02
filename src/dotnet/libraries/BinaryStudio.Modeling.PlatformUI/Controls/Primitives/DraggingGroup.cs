using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BinaryStudio.Modeling.PlatformUI.Controls.Primitives
    {
    internal class DraggingGroup : IDraggingObject
        {
        public IList<IDraggingObject> Children { get; }
        public Rect Bound { get; }

        #region ctor{IEnumerable<IDraggingObject>}
        public DraggingGroup(IEnumerable<IDraggingObject> children) {
            Children = children.AsReadOnly();
            var r = Rect.Empty;
            foreach (var o in Children) {
                r.Union(o.Bound);
                }
            Bound = r;
            }
        #endregion
        }
    }
