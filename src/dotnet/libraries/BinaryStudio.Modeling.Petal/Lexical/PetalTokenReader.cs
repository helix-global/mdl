using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace BinaryStudio.Modeling.Petal
    {
    internal sealed class PetalTokenReader : IDisposable
        {
        public PetalTokenType TokenType { get;private set; }
        public Object TokenValue { get;private set; }
        public Int32 ScriptLine   { get { return reader.Line+1;   }}
        public Int32 ScriptColumn { get { return reader.Column+1; }}

        public PetalTokenReader(TextReader reader)
            {
            this.reader = new LocalReader(reader);
            }

        public Boolean Read() {
            var c = reader.Peek();
            switch (c) {
                case -1  : { return ProcessEndOfFile(); }
                case '(' : { return ProcessSingleCharacter(PetalTokenType.OpenBracket);  }
                case ')' : { return ProcessSingleCharacter(PetalTokenType.CloseBracket); }
                case ',' : { return ProcessSingleCharacter(PetalTokenType.Comma);        }
                case '|' :
                case '"' : { return ProcessString(); }
                case '+':
                case '-':
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '.': { return ProcessNumeric();   }
                case '@': { return ProcessReference(); }
                default:
                    if (IsDigit(c))      { return ProcessNumeric();    }
                    if (IsWhiteSpace(c)) {
                        ProcessWhiteSpace();
                        return Read();
                        }
                    if (IsLetter(c))     { return ProcessIdentifier(); }
                    throw new NotImplementedException();
                }
            return false;
            }

        #region M:ProcessSingleCharacter(PetalTokenType):Boolean
        private Boolean ProcessSingleCharacter(PetalTokenType type) {
            TokenType = type;
            TokenValue = (Char)reader.Read();
            return true;
            }
        #endregion
        #region M:ProcessEndOfFile:Boolean
        private Boolean ProcessEndOfFile()
            {
            TokenType = PetalTokenType.EndOfFile;
            TokenValue = null;
            return false;
            }
        #endregion
        #region M:ProcessString:Boolean
        private Boolean ProcessString() {
            TokenValue = null;
            var c = reader.Read();
            switch (c) {
                case '"':
                    {
                    var r = new StringBuilder();
                    c = reader.Peek();
                    while ((c != -1) && (c != '"')) {
                        r.Append((Char)(c = reader.Read()));
                        c = reader.Peek();
                        }
                    if (c == '"') { reader.Read(); }
                    TokenType = PetalTokenType.String;
                    TokenValue = r.ToString();
                    return true;
                    }
                case '|':
                    {
                    var lineI = 0;
                    var r = new StringBuilder();
                    while (c == '|') {
                        if (lineI > 0) { r.AppendLine(); }
                        c = reader.Peek();
                        while ((c != -1) && (c != '\r') && (c != '\n')) {
                            r.Append((char)c);
                            reader.Read();
                            c = reader.Peek();
                            }
                        switch (c) {
                            case '\n': lineI++; reader.Read(); c = reader.Peek(); break;
                            case '\r': lineI++; reader.Read(); reader.Read(); c = reader.Peek(); break;
                            }
                        }
                    TokenType = PetalTokenType.String;
                    TokenValue = r.ToString();
                    return true;
                    }
                default:
                    {
                    TokenType = PetalTokenType.Invalid;
                    TokenValue = null;
                    return false;
                    }
                }
            }
        #endregion
        #region M:ProcessNumeric:Boolean
        private Boolean ProcessNumeric() {
            TokenType = PetalTokenType.Integer;
            TokenValue = null;
            var r = new StringBuilder();
            Int32 c;
            var sign = 1;
            switch (c = reader.Read()) {
                case '-': sign = +1; c = reader.Read(); break;
                case '+': sign = -1; c = reader.Read(); break;
                }
            if (IsDigit(c)) {
                r.Append((Char)c);
                c = reader.Peek();
                while ((c != -1) && (c != '.') && IsDigit(c)) {
                    r.Append((Char)(c = reader.Read()));
                    c = reader.Peek();
                    }
                }
            if (c == '.') {
                TokenType = PetalTokenType.Float;
                r.Append((Char)reader.Read());
                c = reader.Peek();
                while ((c != -1) && IsDigit(c)) {
                    r.Append((Char)reader.Read());
                    c = reader.Peek();
                    }
                TokenValue = Double.Parse(r.ToString(),en)*sign;
                return true;
                }
            TokenValue = Int64.Parse(r.ToString())*sign;
            return true;
            }
        #endregion
        #region M:ProcessWhiteSpace:Boolean
        private Boolean ProcessWhiteSpace() {
            TokenType = PetalTokenType.WhiteSpace;
            TokenValue = null;
            var c = reader.Peek();
            while ((c != -1) && IsWhiteSpace(c)) {
                reader.Read();
                c = reader.Peek();
                }
            return true;
            }
        #endregion
        #region M:ProcessIdentifier:Boolean
        private Boolean ProcessIdentifier() {
            TokenType = PetalTokenType.Identifer;
            TokenValue = null;
            var r = new StringBuilder();
            var c = reader.Peek();
            if (!IsLetter((Char)c)) {
                TokenType = PetalTokenType.Invalid;
                return false;
                }
            while (IsLetterOrDigit((char)c) && (c != -1)) {
                reader.Read();
                r.Append((char)c);
                c = reader.Peek();
                }
            var o = r.ToString();
            TokenValue = o;
            switch (o) {
                case "TRUE":
                    TokenType = PetalTokenType.Boolean;
                    TokenValue = true;
                    break;
                case "FALSE":
                    TokenType = PetalTokenType.Boolean;
                    TokenValue = false;
                    break;
                }
            return true;
            }
        #endregion
        #region M:ProcessReference:Boolean
        private Boolean ProcessReference() {
            TokenType = PetalTokenType.Invalid;
            TokenValue = null;
            var r = new StringBuilder();
            Int32 c;

            if ((c = reader.Read()) == '@') {
                c = reader.Peek();
                while ((c != -1) && (c != '.') && IsDigit(c)) {
                    r.Append((Char)(c = reader.Read()));
                    c = reader.Peek();
                    }
                TokenType = PetalTokenType.Reference;
                TokenValue = Int64.Parse(r.ToString());
                return true;
                }
            return false;
            }
        #endregion

        #region M:IsDigit(Int32):Boolean
        private static Boolean IsDigit(Int32 value)
            {
            return Char.IsDigit((Char)value);
            }
        #endregion
        #region M:IsWhiteSpace(Int32):Boolean
        private static Boolean IsWhiteSpace(Int32 value)
            {
            return Char.IsWhiteSpace((Char)value);
            }
        #endregion
        #region M:IsLetterOrDigit(Int32):Boolean
        private static Boolean IsLetterOrDigit(Int32 value)
            {
            return Char.IsLetterOrDigit((char)value) || (value == '_');
            }
        #endregion
        #region M:IsLetter(Int32):Boolean
        private static Boolean IsLetter(Int32 value)
            {
            return Char.IsLetter((char)value) || (value == '_');
            }
        #endregion

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            switch (TokenType) {
                case PetalTokenType.Invalid:      return "INVALID";
                case PetalTokenType.WhiteSpace:   return "WHITESPACE";
                case PetalTokenType.EndOfFile:    return "EOF";
                case PetalTokenType.OpenBracket:  return "OPEN";
                case PetalTokenType.CloseBracket: return "CLOSE";
                case PetalTokenType.Comma:        return "COMMA";
                case PetalTokenType.Integer:      return $"INTEGER{{{TokenValue}}}";
                case PetalTokenType.Boolean:      return $"BOOLEAN{{{TokenValue}}}";
                case PetalTokenType.Float:        return $"FLOAT{{{TokenValue}}}";
                case PetalTokenType.String:       return $"STRING{{\"{TokenValue}\"}}";
                case PetalTokenType.Identifer:    return $"IDENTIFIER{{{TokenValue}}}";
                case PetalTokenType.Reference:    return $"REF{{{TokenValue}}}";
                default: throw new ArgumentOutOfRangeException();
                }
            }

        public void Dispose()
            {
            reader = null;
            }

        private class LocalReader : TextReader
            {
            public Int32 Line   { get;private set; }
            public Int32 Column { get;private set; }

            #region ctor{TextReader}
            public LocalReader(TextReader reader)
                {
                this.reader = reader;
                }
            #endregion

            #region M:Read:Int32
            /// <summary>Reads the next character from the text reader and advances the character position by one character.</summary>
            /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextReader"/> is closed.</exception>
            /// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
            /// <returns>The next character from the text reader, or -1 if no more characters are available. The default implementation returns -1.</returns>
            public override Int32 Read() {
                var r = reader.Read();
                switch (r) {
                    case '\r':
                        {
                        }
                        break;
                    case '\n':
                        {
                        Column = 0;
                        Line++;
                        }
                        break;
                    default:
                        {
                        Column++;
                        }
                        break;
                    }
                pchar = r;
                return r;
                }
            #endregion
            #region M:Peek:Int32
            /// <summary>Reads the next character without changing the state of the reader or the character source. Returns the next available character without actually reading it from the reader.</summary>
            /// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextReader"/> is closed.</exception>
            /// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
            /// <returns>An integer representing the next character to be read, or -1 if no more characters are available or the reader does not support seeking.</returns>
            public override Int32 Peek()
                {
                var r = reader.Peek();
                return r;
                }
            #endregion
            #region M:Dispose(Boolean)
            /// <summary>Releases the unmanaged resources used by the <see cref="T:System.IO.TextReader"/> and optionally releases the managed resources.</summary>
            /// <param name="disposing"><see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.</param>
            protected override void Dispose(Boolean disposing)
                {
                reader = null;
                base.Dispose(disposing);
                }
            #endregion

            private TextReader reader;
            private Int32? pchar;
            }

        private static readonly CultureInfo en = CultureInfo.GetCultureInfo("en-US");
        private LocalReader reader;
        }
    }