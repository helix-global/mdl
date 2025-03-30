using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace pre
    {
    public class ModelElement : IXmlSerializable,IServiceProvider
        {
        public const String DefaultNamespace = "BinaryStudio.Modeling.UnifiedModelingLanguage";
        public const String uml = "http://www.omg.org/spec/UML/20131001";
        public const String xmi = "http://www.omg.org/spec/XMI/20131001";
        public const String mofext = "http://www.omg.org/spec/MOF/20131001";
        public virtual Model BaseModel { get { return Owner?.BaseModel; }}
        public virtual ModelElement Owner {get;}
        protected Boolean UpdateReferencesCompleted { get;set; }

        public ModelElement(ModelElement owner)
            {
            Owner = owner;
            }

        #region M:IXmlSerializable.GetSchema:XmlSchema
        /// <summary>This method is reserved and should not be used. When implementing the <see langword="IXmlSerializable" /> interface, you should return <see langword="null" /> (<see langword="Nothing" /> in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute" /> to the class.</summary>
        /// <returns>An <see cref="T:System.Xml.Schema.XmlSchema" /> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)" /> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)" /> method.</returns>
        XmlSchema IXmlSerializable.GetSchema()
            {
            throw new NotSupportedException();
            }
        #endregion
        #region M:IXmlSerializable.ReadXml(XmlReader)
        /// <summary>Generates an object from its XML representation.</summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public virtual void ReadXml(XmlReader reader)
            {
            }
        #endregion
        #region M:IXmlSerializable.WriteXml(XmlWriter)
        /// <summary>Converts an object into its XML representation.</summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
        void IXmlSerializable.WriteXml(XmlWriter writer)
            {
            throw new NotSupportedException();
            }
        #endregion
        #region M:WriteCSharp(TextWriter,String)
        public virtual void WriteCSharp(TextWriter writer,String prefix)
            {

            }
        #endregion
        #region M:WriteCSharp(FileStream)
        public void WriteCSharp(FileStream stream) {
            using (var writer = new StreamWriter(stream,Encoding.UTF8,-1,false)) {
                WriteCSharp(writer,String.Empty);
                }
            }
        #endregion
        #region M:UpdateReferences
        public virtual void UpdateReferences()
            {
            UpdateReferencesCompleted = true;
            }
        #endregion
        #region M:Equals(ValueSpecification,String):Boolean
        protected static Boolean Equals(ValueSpecification x,String y) {
            if ((x == null) && (String.IsNullOrWhiteSpace(y))) { return true; }
            return (x != null) && String.Equals(x.ToString(),y??String.Empty);
            }
        #endregion
        #region M:UpperFirstLetter(String):String
        protected static String UpperFirstLetter(String value) {
            if (String.IsNullOrEmpty(value)) { return value; }
            return value.Substring(0,1).ToUpperInvariant()+value.Substring(1);
            }
        #endregion
        #region M:GetService(Type):Object
        /// <summary>Gets the service object of the specified type.</summary>
        /// <param name="service">An object that specifies the type of service object to get.</param>
        /// <returns>A service object of type <paramref name="service"/>.-or- <see langword="null"/> if there is no service object of type <paramref name="service"/>.</returns>
        public virtual Object GetService(Type service)
            {
            if (service == GetType()) { return this; }
            return null;
            }
        #endregion
        #region M:UpdateCSharpKeyword(String):String
        protected static String UpdateCSharpKeyword(String value) {
            switch (value) {
                case "default" : return "@default";
                case "is"      : return "@is";
                }
            return value;
            }
        #endregion
        }
    }