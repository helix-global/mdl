using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            using (var r = new PetalTokenReader(reader)) {
                return ReadFrom(r,options,out o);
                }
            }
        #endregion
        #region M:ReadFrom(PetalTokenReader,PetalReaderOptions,{out}PetalObject):Boolean
        private static Boolean ReadFrom(PetalTokenReader reader,PetalReaderOptions options,out PetalObject o) {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            o = default;
            var list = new List<PetalNode>();
            PetalNode r;
            if (reader.Read()) {
                while ((r = ReadNextNode(reader,options)) != null)
                    {
                    list.Add(r);
                    }
                }
            return false;
            }
        #endregion
        #region M:ReadNextNode(PetalTokenReader,PetalReaderOptions):PetalNode
        private static PetalNode ReadNextNode(PetalTokenReader reader,PetalReaderOptions options) {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            SkipWhiteSpaces(reader);
            switch (reader.TokenType) {
                #region OpenBracket
                case PetalTokenType.OpenBracket:
                    {
                    return ReadNextCompositeObject(reader,options);
                    }
                #endregion
                #region Integer
                case PetalTokenType.Integer:
                    {
                    var r = new PetalIntegerLiteral((Int64)reader.TokenValue);
                    reader.Read();
                    return r;
                    }
                #endregion
                #region Float
                case PetalTokenType.Float:
                    {
                    var r = new PetalFloatLiteral((Double)reader.TokenValue);
                    reader.Read();
                    return r;
                    }
                #endregion
                #region String
                case PetalTokenType.String:
                    {
                    var r = new PetalStringLiteral((String)reader.TokenValue);
                    reader.Read();
                    return r;
                    }
                #endregion
                #region Boolean
                case PetalTokenType.Boolean:
                    {
                    var r = new PetalBooleanLiteral((Boolean)reader.TokenValue);
                    reader.Read();
                    return r;
                    }
                #endregion
                }
            throw new NotSupportedException();
            }
        #endregion
        private static PetalNode ReadNextCompositeObject(PetalTokenReader reader,PetalReaderOptions options) {
            if (reader.Read()) {
                switch(reader.TokenType) {
                    case PetalTokenType.Identifer:
                        {
                        switch (reader.TokenValue.ToString()) {
                            case "object": return ReadNextObject(MoveNextToken(reader),options,new PetalObject());
                            case "list"  : return ReadNextList(MoveNextToken(reader),options,new PetalList());
                            case "value" : return ReadNextValue(MoveNextToken(reader),options,new PetalValue());
                            default: throw new NotSupportedException();
                            }
                        }
                    case PetalTokenType.Integer:
                        {
                        var o = new PetalLocation();
                        o.X = (Int64)reader.TokenValue;
                        reader.Read();
                        SkipWhiteSpaces(reader);
                        reader.Read();
                        SkipWhiteSpaces(reader);
                        o.Y = (Int64)reader.TokenValue;
                        reader.Read();
                        SkipWhiteSpaces(reader);
                        reader.Read();
                        return o;
                        }
                    }
                }
            throw new InvalidDataException();
            }
        #region M:ReadNextObject(PetalTokenReader,PetalReaderOptions,PetalObject):PetalObject
        private static PetalObject ReadNextObject(PetalTokenReader reader,PetalReaderOptions options,PetalObject o) {
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
            if (reader.TokenType == PetalTokenType.CloseBracket)
                {
                reader.Read();
                return o;
                }
            return o;
            }
        #endregion
        #region M:ReadNextList(PetalTokenReader,PetalReaderOptions,PetalList):PetalList
        private static PetalList ReadNextList(PetalTokenReader reader,PetalReaderOptions options,PetalList o) {
            o.Name = ReadNextIdentifer(reader);
            PetalNode r;
            while (true) {
                SkipWhiteSpaces(reader);
                if (reader.TokenType == PetalTokenType.CloseBracket) {
                    reader.Read();
                    break;
                    }
                o.Nodes.Add(ReadNextNode(reader,options));
                }
            return o;
            }
        #endregion
        #region M:ReadNextValue(PetalTokenReader,PetalReaderOptions,PetalValue):PetalValue
        private static PetalValue ReadNextValue(PetalTokenReader reader,PetalReaderOptions options,PetalValue o) {
            o.Name = ReadNextIdentifer(reader);
            o.PetalString = ReadNextString(reader);
            if (reader.TokenType == PetalTokenType.CloseBracket)
                {
                reader.Read();
                return o;
                }
            return o;
            }
        #endregion
        #region M:ReadNextTag(PetalTokenReader):PetalTag
        private static PetalTag ReadNextTag(PetalTokenReader reader) {
            SkipWhiteSpaces(reader);
            if (reader.TokenType == PetalTokenType.Reference) {
                var r = (Int64)reader.TokenValue;
                reader.Read();
                return new PetalTag(r);
                }
            return null;
            }
        #endregion
        #region M:SkipWhiteSpaces(PetalTokenReader)
        private static void SkipWhiteSpaces(PetalTokenReader reader) {
            while (reader.TokenType == PetalTokenType.WhiteSpace) {
                reader.Read();
                }
            }
        #endregion
        #region M:ReadNextIdentifer(PetalTokenReader):String
        private static String ReadNextIdentifer(PetalTokenReader reader) {
            SkipWhiteSpaces(reader);
            if (reader.TokenType == PetalTokenType.Identifer) {
                var r = (String)reader.TokenValue;
                reader.Read();
                return r;
                }
            return null;
            }
        #endregion
        #region M:ReadNextString(PetalTokenReader):String
        private static String ReadNextString(PetalTokenReader reader) {
            SkipWhiteSpaces(reader);
            if (reader.TokenType == PetalTokenType.String) {
                var r = (String)reader.TokenValue;
                reader.Read();
                return r;
                }
            return null;
            }
        #endregion
        #region M:MoveNextToken(PetalTokenReader):PetalTokenReader
        private static PetalTokenReader MoveNextToken(PetalTokenReader reader)
            {
            reader.Read();
            return reader;
            }
        #endregion
        }
    }
