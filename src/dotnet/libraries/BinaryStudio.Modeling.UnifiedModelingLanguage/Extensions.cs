using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    internal static class Extensions
        {
        #region M:AsReadOnly<T>({this}IEnumerable<T>):IList<T>
        public static IList<T> AsReadOnly<T>(this IEnumerable<T> source)
            {
            return new ReadOnlyCollection<T>(source.ToArray());
            }
        #endregion
        }
    }