using System;
using System.IO;
using System.Text;

namespace BinaryStudio.Modeling.Petal
    {
    public class PetalReader
        {
        #region M:ReadFrom(Uri,PetalReaderOptions,{out}PetalObject):Boolean
        public static Boolean ReadFrom(Uri uri,PetalReaderOptions options,out PetalObject o) {
            o = default;
            switch (uri.Scheme) {
                case "file":
                    {
                    using (var reader = new StreamReader(uri.LocalPath,Encoding.UTF8)) {
                        return ReadFrom(reader,options,out o);
                        }
                    }
                }
            return false;
            }
        #endregion
        #region M:ReadFrom(TextReader,PetalReaderOptions,{out}PetalObject):Boolean
        public static Boolean ReadFrom(TextReader reader,PetalReaderOptions options,out PetalObject o) {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            o = default;
            PetalNode r;
            while ((r = ReadNextNode(reader,options)) != null)
                {
                }
            return false;
            }
        #endregion
        #region M:ReadNextNode(TextReader,PetalReaderOptions):PetalNode
        private static PetalNode ReadNextNode(TextReader reader,PetalReaderOptions options) {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            SkipWhiteSpaces(reader);
            var c = reader.Peek();
            if (c == '(') {
                reader.Read();
                var identifier = ReadNextIdentifer(reader);
                switch (identifier) {
                    case "object": return ReadNextObject(reader,options,new PetalObject());
                    case "list"  : return ReadNextList(reader,options,new PetalList());
                    case "value" : return ReadNextValue(reader,options,new PetalValue());
                    default: throw new NotSupportedException();
                    }
                }
            if (IsDigit(c)) { return new PetalIntegerLiteral(ReadNextInteger(reader)); }
            if (c == '"') { return new PetalStringLiteral(ReadNextString(reader));}
            throw new NotSupportedException();
            }
        #endregion
        #region M:ReadNextObject(TextReader,PetalReaderOptions,PetalObject):PetalObject
        private static PetalObject ReadNextObject(TextReader reader,PetalReaderOptions options,PetalObject o) {
            SkipWhiteSpaces(reader);
            o.Name = ReadNextIdentifer(reader);
            String S;
            while ((S = ReadNextString(reader)) != null) {
                o.PetalStrings.Add(S);
                }
            o.Tag = ReadNextTag(reader);
            for (;;) {
                var identifier = ReadNextIdentifer(reader);
                if (String.IsNullOrWhiteSpace(identifier)) { break; }
                o.Properties.Add(new PetalProperty(identifier,ReadNextNode(reader,options)));
                }
            return o;
            }
        #endregion
        #region M:ReadNextList(TextReader,PetalReaderOptions,PetalList):PetalList
        private static PetalList ReadNextList(TextReader reader,PetalReaderOptions options,PetalList o) {
            return o;
            }
        #endregion
        #region M:ReadNextValue(TextReader,PetalReaderOptions,PetalValue):PetalValue
        private static PetalValue ReadNextValue(TextReader reader,PetalReaderOptions options,PetalValue o) {
            return o;
            }
        #endregion
        #region M:ReadNextTag(TextReader):PetalTag
        private static PetalTag ReadNextTag(TextReader reader) {
            SkipWhiteSpaces(reader);
            var c = reader.Peek();
            if (c == '@') {
                var r = new StringBuilder();
                reader.Read();
                c = reader.Peek();
                while (IsDigit(c)) {
                    reader.Read();
                    r.Append((Char)c);
                    c = reader.Peek();
                    }
                return new PetalTag(Int64.Parse(r.ToString()));
                }
            return null;
            }
        #endregion
        #region M:SkipWhiteSpaces(TextReader)
        private static void SkipWhiteSpaces(TextReader reader) {
            var c = reader.Peek();
            if (c == -1) { return; }
            while (Char.IsWhiteSpace((Char)c) && (c != -1)) {
                reader.Read();
                c = reader.Peek();
                }
            }
        #endregion
        #region M:ReadNextIdentifer(TextReader):String
        private static String ReadNextIdentifer(TextReader reader) {
            SkipWhiteSpaces(reader);
            var r = new StringBuilder();
            var c = reader.Peek();
            if (!IsLetter((Char)c)) { return null; }
            while (IsLetterOrDigit((char)c) && (c != -1)) {
                reader.Read();
                r.Append((char)c);
                c = reader.Peek();
                }
            return r.ToString();
            }
        #endregion
        #region M:ReadNextString(TextReader):String
        private static String ReadNextString(TextReader reader) {
            var r = new StringBuilder();
            SkipWhiteSpaces(reader);
            var c = reader.Peek();
            if (c == '"') {
                reader.Read();
                c = reader.Peek();
                while (((char)c != '"') && (c != -1)) {
                    reader.Read();
                    r.Append((char)c);
                    c = reader.Peek();
                    }
                if (c == '"') { return r.ToString(); }
                throw new InvalidDataException();
                }
            return null;
            }
        #endregion
        #region M:ReadNextInteger(TextReader):Integer
        private static Int64 ReadNextInteger(TextReader reader) {
            var r = new StringBuilder();
            var c = reader.Peek();
            while (IsDigit(c) && (c != -1)) {
                reader.Read();
                r.Append((Char)c);
                c = reader.Peek();
                }
            return Int64.Parse(r.ToString());
            }
        #endregion
        #region M:IsLetter(Int32):Boolean
        private static Boolean IsLetter(Int32 value)
            {
            return Char.IsLetter((char)value) || (value == '_');
            }
        #endregion
        #region M:IsLetterOrDigit(Int32):Boolean
        private static Boolean IsLetterOrDigit(Int32 value)
            {
            return Char.IsLetterOrDigit((char)value) || (value == '_');
            }
        #endregion
        #region M:IsDigit(Int32):Boolean
        private static Boolean IsDigit(Int32 value)
            {
            return Char.IsDigit((char)value);
            }
        #endregion
        }
    }
