using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.UnifiedModelingLanguage.Attributes;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage
    {
    /// <summary>
    /// Physical definition of a graphical image.
    /// </summary>
    /// xmi:id="Image"
    public interface Image : Element
        {
        #region P:Content:String
        /// <summary>
        /// This contains the serialization of the image according to the <see cref="Format"/>. The value could represent a bitmap, image such as a GIF file, or drawing 'instructions' using a standard such as Scalable Vector Graphic (SVG) (which is XML based).
        /// </summary>
        /// xmi:id="Image-content"
        [Multiplicity("0..1")]
        String Content { get;set; }
        #endregion
        #region P:Format:String
        /// <summary>
        /// This indicates the <see cref="Format"/> of the <see cref="Content"/>, which is how the string <see cref="Content"/> should be interpreted. The following values are reserved: SVG, GIF, PNG, JPG, WMF, EMF, BMP. In addition the prefix 'MIME: ' is also reserved. This option can be used as an alternative to express the reserved values above, for example "SVG" could instead be expressed as "MIME: image/svg+xml".
        /// </summary>
        /// xmi:id="Image-format"
        [Multiplicity("0..1")]
        String Format { get;set; }
        #endregion
        #region P:Location:String
        /// <summary>
        /// This contains a <see cref="Location"/> that can be used by a tool to locate the image as an alternative to embedding it in the stereotype.
        /// </summary>
        /// xmi:id="Image-location"
        [Multiplicity("0..1")]
        String Location { get;set; }
        #endregion
        }
    }
