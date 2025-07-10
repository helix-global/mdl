using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using BinaryStudio.DirectoryServices;

namespace BinaryStudio.Modeling.Petal
    {
    public class PetalDocument : PetalNode
        {
        public IList<PetalNode> Nodes { get; }

        private PetalDocument()
            {
            Nodes = new List<PetalNode>();
            }

        #region M:ReadFrom(Uri,PetalReaderOptions,{out}PetalDocument):Boolean
        public static Boolean ReadFrom(Uri uri,PetalReaderOptions options,out PetalDocument o) {
            if (uri == null) { throw new ArgumentNullException(nameof(uri)); }
            o = default;
            switch (uri.Scheme) {
                case "file":
                    {
                    if (uri.LocalPath.Contains("*")) { throw new ArgumentOutOfRangeException(nameof(uri)); }
                    if (uri.LocalPath.Contains("?")) { throw new ArgumentOutOfRangeException(nameof(uri)); }
                    DirectoryService.GetService(uri,out IFile file);
                    if (file == null) { throw new FileNotFoundException(); }
                    return ReadFrom(file,options,out o);
                    }
                }
            return false;
            }
        #endregion
        #region M:ReadFrom(IFileService,PetalReaderOptions,{out}PetalDocument):Boolean
        public static Boolean ReadFrom(IFile service,PetalReaderOptions options,out PetalDocument o) {
            if (service == null) { throw new ArgumentNullException(nameof(service)); }
            o = default;
            using (var stream = service.OpenRead()) {
                using (var reader = new StreamReader(stream,Encoding.UTF8)) {
                    return ReadFrom(reader,options,out o);
                    }
                }
            }
        #endregion
        #region M:ReadFrom(TextReader,PetalReaderOptions,{out}PetalDocument):Boolean
        public static Boolean ReadFrom(TextReader reader,PetalReaderOptions options,out PetalDocument o) {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            o = default;
            using (var r = new PetalTokenReader(reader)) {
                return ReadFrom(r,options,out o);
                }
            }
        #endregion
        #region M:ReadFrom(PetalTokenReader,PetalReaderOptions,{out}PetalDocument):Boolean
        private static Boolean ReadFrom(PetalTokenReader reader,PetalReaderOptions options,out PetalDocument o) {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            o = new PetalDocument();
            if (reader.Read()) {
                PetalNode r;
                while ((r = NextNOD(reader,options)) != null)
                    {
                    o.Nodes.Add(r);
                    }
                return true;
                }
            o = default;
            return false;
            }
        #endregion
        #region M:NextNOD(PetalTokenReader,PetalReaderOptions):PetalNode
        private static PetalNode NextNOD(PetalTokenReader reader,PetalReaderOptions options) {
            if (reader == null) { throw new ArgumentNullException(nameof(reader)); }
            switch ((Int32)reader.TokenType) {
                case '(': { return NextC(reader,options); }
                case 'n': { return NextN(reader); }
                case 'f': { return NextF(reader); }
                case 's': { return NextS(reader); }
                case 'b': { return NextB(reader); }
                case '@': { return NextR(reader); }
                case 'e': { return null; }
                }
            throw new NotSupportedException();
            }
        #endregion
        #region M:NextOBJ(PetalTokenReader,PetalReaderOptions,PetalObject):PetalObject
        private static PetalObject NextOBJ(PetalTokenReader reader,PetalReaderOptions options,PetalObject o) {
            o.Name = ProbeI(reader);
            String S;
            while ((S = ProbeS(reader)) != null) {
                o.PetalStrings.Add(S);
                }
            o.Reference = ProbeR(reader);
            for (;;) {
                var identifier = ProbeI(reader);
                if (String.IsNullOrWhiteSpace(identifier)) { break; }
                o.Properties.Add(new PetalProperty(identifier,NextNOD(reader,options)));
                }
            Validate(reader,')');
            return MoveNext(o,reader);
            }
        #endregion
        #region M:NextLST(PetalTokenReader,PetalReaderOptions,PetalList):PetalList
        private static PetalList NextLST(PetalTokenReader reader,PetalReaderOptions options,PetalList o) {
            o.Name = ProbeI(reader);
            while (true) {
                if (reader.TokenType == PetalTokenType.CloseBracket) {
                    reader.Read();
                    break;
                    }
                o.Nodes.Add(NextNOD(reader,options));
                }
            return o;
            }
        #endregion
        #region M:NextVAL(PetalTokenReader,PetalReaderOptions,PetalValue):PetalValue
        private static PetalValue NextVAL(PetalTokenReader reader,PetalReaderOptions options,PetalValue o) {
            o.Name = ProbeI(reader);
            o.PetalString = ProbeS(reader);
            if (reader.TokenType == PetalTokenType.CloseBracket)
                {
                reader.Read();
                return o;
                }
            return o;
            }
        #endregion
        #region M:ProbeR(PetalTokenReader):PetalReference
        private static PetalReference ProbeR(PetalTokenReader reader) {
            return (reader.TokenType == PetalTokenType.Reference)
                ? NextR(reader)
                : null;
            }
        #endregion
        #region M:ProbeS(PetalTokenReader):String
        private static String ProbeS(PetalTokenReader reader) {
            return (reader.TokenType == PetalTokenType.String)
                ? MoveNext((String)reader.TokenValue,reader)
                : null;
            }
        #endregion
        #region M:ProbeI(PetalTokenReader):String
        private static String ProbeI(PetalTokenReader reader) {
            return (reader.TokenType == PetalTokenType.Identifer)
                ? MoveNext((String)reader.TokenValue,reader)
                : null;
            }
        #endregion
        #region M:MoveNext(PetalTokenReader):PetalTokenReader
        private static PetalTokenReader MoveNext(PetalTokenReader reader)
            {
            reader.Read();
            return reader;
            }
        #endregion
        #region M:MoveNext<T>(T,PetalTokenReader):T
        private static T MoveNext<T>(T r,PetalTokenReader reader)
            {
            reader.Read();
            return r;
            }
        #endregion
        #region M:NextN(PetalTokenReader):PetalIntegerLiteral
        private static PetalIntegerLiteral NextN(PetalTokenReader reader) {
            Validate(reader,'n');
            return MoveNext(new PetalIntegerLiteral((Int64)reader.TokenValue),reader);
            }
        #endregion
        #region M:NextF(PetalTokenReader):PetalFloatLiteral
        private static PetalFloatLiteral NextF(PetalTokenReader reader) {
            Validate(reader,'f');
            return MoveNext(new PetalFloatLiteral((Double)reader.TokenValue),reader);
            }
        #endregion
        #region M:NextB(PetalTokenReader):PetalBooleanLiteral
        private static PetalBooleanLiteral NextB(PetalTokenReader reader) {
            Validate(reader,'b');
            return MoveNext(new PetalBooleanLiteral((Boolean)reader.TokenValue),reader);
            }
        #endregion
        #region M:NextS(PetalTokenReader):PetalStringLiteral
        private static PetalStringLiteral NextS(PetalTokenReader reader) {
            Validate(reader,'s');
            return MoveNext(new PetalStringLiteral((String)reader.TokenValue),reader);
            }
        #endregion
        #region M:NextR(PetalTokenReader):PetalReference
        private static PetalReference NextR(PetalTokenReader reader) {
            Validate(reader,'@');
            return MoveNext(new PetalReference((Int64)reader.TokenValue),reader);
            }
        #endregion
        #region M:NextT(PetalTokenReader):PetalTuple
        [SuppressMessage("ReSharper", "PossibleInvalidCastException")]
        private static PetalTuple NextT(PetalTokenReader reader) {
            Validate(reader,'s');
            var r = new PetalTuple{
                S = (String)reader.TokenValue,
                };
            Validate(MoveNext(reader),'n');
            r.I = (Int64)reader.TokenValue;
            Validate(MoveNext(reader),')');
            return MoveNext(r,reader);
            }
        #endregion
        #region M:NextL(PetalTokenReader):PetalLocation
        private static PetalLocation NextL(PetalTokenReader reader) {
            Validate(reader,'n');
            var r = new PetalLocation{
                X = (Int64)reader.TokenValue,
                };
            Validate(MoveNext(reader),',');
            Validate(MoveNext(reader),'n');
            r.Y = (Int64)reader.TokenValue;
            Validate(MoveNext(reader),')');
            return MoveNext(r,reader);
            }
        #endregion
        #region M:NextC(PetalTokenReader,PetalReaderOptions):PetalNode
        private static PetalNode NextC(PetalTokenReader reader,PetalReaderOptions options) {
            if (reader.Read()) {
                switch((Int32)reader.TokenType) {
                    case 'i':
                        {
                        switch (reader.TokenValue.ToString()) {
                            case "object": return NextOBJ(MoveNext(reader),options,new PetalObject());
                            case "list"  : return NextLST(MoveNext(reader),options,new PetalList());
                            case "value" : return NextVAL(MoveNext(reader),options,new PetalValue());
                            default: throw new NotSupportedException();
                            }
                        }
                    case 'n': { return NextL(reader); }
                    case 's': { return NextT(reader); }
                    }
                }
            throw new InvalidDataException();
            }
        #endregion
        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString()
            {
            return $"PetalDocument,Count={Nodes.Count}";
            }
        #endregion

        [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local")]
        private static void Validate(PetalTokenReader reader,Int32 e) {
            if ((Int32)reader.TokenType != e)
                {
                throw new InvalidDataException();
                }
            }
        }
    }
