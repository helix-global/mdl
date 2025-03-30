using System;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// <see cref="ParameterDirectionKind"/> is an <see cref="Enumeration"/> that defines literals used to specify direction of parameters.
    /// </summary>
    /// xmi:id="ParameterDirectionKind"
    public enum ParameterDirectionKind
        {
        /// <summary>
        /// Indicates that <see cref="Parameter"/> values are passed in by the caller. 
        /// </summary>
        /// xmi:id="ParameterDirectionKind-in"
        In,
        /// <summary>
        /// Indicates that <see cref="Parameter"/> values are passed in by the caller and (possibly different) values passed out to the caller.
        /// </summary>
        /// xmi:id="ParameterDirectionKind-inout"
        Inout,
        /// <summary>
        /// Indicates that <see cref="Parameter"/> values are passed out to the caller.
        /// </summary>
        /// xmi:id="ParameterDirectionKind-out"
        Out,
        /// <summary>
        /// Indicates that <see cref="Parameter"/> values are passed as return values back to the caller.
        /// </summary>
        /// xmi:id="ParameterDirectionKind-return"
        Return
        }
    }
