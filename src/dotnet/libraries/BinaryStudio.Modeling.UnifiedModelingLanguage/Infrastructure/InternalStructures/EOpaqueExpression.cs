using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EOpaqueExpression : EValueSpecification,OpaqueExpression
        {
        public Behavior Behavior { get;set; }
        public IList<String> Body { get; }
        public IList<String> Language { get; }
        public Parameter Result { get; }

        public EOpaqueExpression()
            {
            Body = new List<String>();
            Language = new List<String>();
            }

        public Boolean isIntegral()
            {
            throw new NotImplementedException();
            }

        public Boolean isNonNegative()
            {
            throw new NotImplementedException();
            }

        public Boolean isPositive()
            {
            throw new NotImplementedException();
            }

        public Parameter result()
            {
            throw new NotImplementedException();
            }

        public Int32 value()
            {
            throw new NotImplementedException();
            }
        }
    }