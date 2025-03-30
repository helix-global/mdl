using System;
using System.Xml;

namespace pre
    {
    public class Generalization : ModelElement
        {
        public ObjectIdentifier General { get;private set; }
        public ObjectIdentifier Identifier { get;private set; }

        public Generalization(ModelElement owner)
            : base(owner)
            {
            }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return General.ToString();
            }

        /// <summary>Generates an object from its XML representation.</summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public override void ReadXml(XmlReader reader)
            {
            reader.MoveToContent();
            General = new ObjectIdentifier(reader.GetAttribute("general"));
            Identifier = new ObjectIdentifier(reader.GetAttribute("id",xmi));
            }

        #region M:GetService(Type):Object
        /// <summary>Gets the service object of the specified type.</summary>
        /// <param name="service">An object that specifies the type of service object to get.</param>
        /// <returns>A service object of type <paramref name="service"/>.-or- <see langword="null"/> if there is no service object of type <paramref name="service"/>.</returns>
        public override Object GetService(Type service) {
            if (service == typeof(Class)) {
                if (BaseModel.Classes.TryGetValue(General,out var r)) {
                    return r;
                    }
                }
            return base.GetService(service);
            }
        #endregion
        }
    }