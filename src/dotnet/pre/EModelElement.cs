using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace pre
    {
    internal class ModelElement : IXmlSerializable,IServiceProvider,IModelElement
        {
        public const String DefaultNamespace = "BinaryStudio.Modeling.UnifiedModelingLanguage";
        public const String uml = "http://www.omg.org/spec/UML/20131001";
        public const String xmi = "http://www.omg.org/spec/XMI/20131001";
        public const String mofext = "http://www.omg.org/spec/MOF/20131001";
        public virtual Model BaseModel { get { return Owner?.BaseModel; }}
        public virtual ModelElement Owner {get;}

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
        #region M:OnAfterLoadModel
        public virtual void OnAfterLoadModel()
            {
            }
        #endregion
        #region M:Equals(ValueSpecification,String):Boolean
        protected static Boolean Equals(ValueSpecification x,String y) {
            if ((x == null) && (y == null)) { return true; }
            if (x == null) { return false; }
            if (y == null) { return false; }
            return String.Equals(x.ToString(),y);
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
        #region M:FindModelElement(String):ModelElement
        public virtual ModelElement FindModelElement(String idref) {
            if (String.IsNullOrWhiteSpace(idref)) { throw new ArgumentOutOfRangeException(nameof(idref)); }
            return null;
            }
        #endregion
        #region M:GetValueAsBoolean(Object):Boolean?
        protected static Boolean? GetValueAsBoolean(Object value) {
            if ((value == null) || (value is DBNull)) { return null; }
            if (value is Boolean B)  { return B; }
            if (value is Int32 SI4)  { return SI4 != 0; }
            if (value is Int64 SI8)  { return SI8 != 0; }
            if (value is SByte SI1)  { return SI1 != 0; }
            if (value is Int16 SI2)  { return SI2 != 0; }
            if (value is Byte  UI1)  { return UI1 != 0; }
            if (value is UInt16 UI2) { return UI2 != 0; }
            if (value is UInt32 UI4) { return UI4 != 0; }
            if (value is UInt64 UI8) { return UI8 != 0; }
            var S = (value.ToString()).Trim();
            if (String.IsNullOrEmpty(S)) { return null; }
            Boolean r;
            if (!Boolean.TryParse(S, out r)) {
                var si8 = GetValueAsInt64(S);
                if (si8 != null) { return si8.Value != 0; }
                return null;
                }
            return r;
            }
        #endregion
        #region M:GetValueAsBoolean(Object,Boolean):Boolean
        protected static Boolean GetValueAsBoolean(Object value, Boolean defaultValue)
            {
            return GetValueAsBoolean(value).GetValueOrDefault(defaultValue);
            }
        #endregion
        #region M:GetValueAsInt32(Object):Int32?
        protected static Int32? GetValueAsInt32(Object value) {
            if ((value == null) || (value is DBNull)) { return null; }
            if (value is Int32 SI4)  { return SI4; }
            if (value is Int64 SI8)  { return (Int32)SI8; }
            if (value is SByte SI1)  { return SI1; }
            if (value is Int16 SI2)  { return SI2; }
            if (value is Boolean B)  { return B ? 1 : 0; }
            var S = (value.ToString()).Trim();
            if (String.IsNullOrEmpty(S)) { return null; }
            Int32 r;
            if (!Int32.TryParse(S, out r))
                {
                return null;
                }
            return r;
            }
        #endregion
        #region M:GetValueAsInt32(Object,Int32):Int32
        protected static Int32 GetValueAsInt32(Object value, Int32 defaultValue)
            {
            return GetValueAsInt32(value).GetValueOrDefault(defaultValue);
            }
        #endregion
        #region M:GetValueAsInt64(Object):Int64?
        protected static Int64? GetValueAsInt64(Object value) {
            if ((value == null) || (value is DBNull)) { return null; }
            if (value is Int32 SI4)  { return SI4; }
            if (value is Int64 SI8)  { return SI8; }
            if (value is SByte SI1)  { return SI1; }
            if (value is Int16 SI2)  { return SI2; }
            if (value is Boolean B)  { return B ? 1 : 0; }
            var S = (value.ToString()).Trim();
            if (String.IsNullOrEmpty(S)) { return null; }
            Int64 r;
            if (!Int64.TryParse(S, out r))
                {
                return null;
                }
            return r;
            }
        #endregion
        #region M:GetValueAsInt64(Object,Int64):Int64
        protected static Int64 GetValueAsInt64(Object value, Int64 defaultValue)
            {
            return GetValueAsInt64(value).GetValueOrDefault(defaultValue);
            }
        #endregion
        #region M:MultiplicityToString(ValueSpecification,ValueSpecification):String
        protected static String MultiplicityToString(ValueSpecification LowerValue,ValueSpecification UpperValue) {
            if (Equals(LowerValue,null) && Equals(UpperValue,null)) { return "1..1"; }
            if (Equals(LowerValue,"0")  && Equals(UpperValue,null)) { return "0..1"; }
            if (Equals(LowerValue,"0")  && Equals(UpperValue,"*"))  { return "0..*"; }
            if (Equals(LowerValue,"2")  && Equals(UpperValue,"*"))  { return "2..*"; }
            if (Equals(LowerValue,null) && Equals(UpperValue,"*"))  { return "1..*"; }
            if (Equals(LowerValue,"0")  && Equals(UpperValue,"2"))  { return "0..2"; }
            if (Equals(LowerValue,null) && Equals(UpperValue,"2"))  { return "1..2"; }
            return "???";
            }
        #endregion
        }
    }