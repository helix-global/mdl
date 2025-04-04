﻿using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// An <see cref="InstanceValue"/> is a <see cref="ValueSpecification"/> that identifies an <see cref="Instance"/>.
    /// </summary>
    /// xmi:id="InstanceValue"
    public interface InstanceValue : ValueSpecification
        {
        #region P:Instance:InstanceSpecification
        /// <summary>
        /// The <see cref="InstanceSpecification"/> that represents the specified value.
        /// </summary>
        /// xmi:id="InstanceValue-instance"
        /// xmi:association="A_instance_instanceValue"
        InstanceSpecification Instance { get;set; }
        #endregion
        }
    }
