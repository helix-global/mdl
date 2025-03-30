using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="ParameterEffectKind"/> is an <see cref="Enumeration"/> that indicates the effect of a <see cref="Behavior"/> on values passed in or out of its parameters.
    /// </summary>
    /// xmi:id="ParameterEffectKind"
    public enum ParameterEffectKind
        {
        /// <summary>
        /// Indicates that the behavior creates values.
        /// </summary>
        /// xmi:id="ParameterEffectKind-create"
        Create,
        /// <summary>
        /// Indicates objects that are values of the parameter have values of their properties, or links in which they participate, or their classifiers retrieved during executions of the behavior.
        /// </summary>
        /// xmi:id="ParameterEffectKind-read"
        Read,
        /// <summary>
        /// Indicates objects that are values of the parameter have values of their properties, or links in which they participate, or their classification changed during executions of the behavior.
        /// </summary>
        /// xmi:id="ParameterEffectKind-update"
        Update,
        /// <summary>
        /// Indicates objects that are values of the parameter do not exist after executions of the behavior are finished.
        /// </summary>
        /// xmi:id="ParameterEffectKind-delete"
        Delete
        }
    }
