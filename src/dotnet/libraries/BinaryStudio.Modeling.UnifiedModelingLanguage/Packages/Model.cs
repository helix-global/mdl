using System;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// A model captures a view of a physical system. It is an abstraction of the physical system, with a certain purpose. This purpose determines what is to be included in the model and what is irrelevant. Thus the model completely describes those aspects of the physical system that are relevant to the purpose of the model, at the appropriate level of detail.
    /// </summary>
    /// xmi:id="Model"
    public interface Model : Package
        {
        #region P:Viewpoint:String
        /// <summary>
        /// The <see cref="Name"/> of the <see cref="Viewpoint"/> that is expressed by a model (this <see cref="Name"/> may refer to a profile definition).
        /// </summary>
        /// xmi:id="Model-viewpoint"
        [Multiplicity("0..1")]
        String Viewpoint { get; }
        #endregion
        }
    }
