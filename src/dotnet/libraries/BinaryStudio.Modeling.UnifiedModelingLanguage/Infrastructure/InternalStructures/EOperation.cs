using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EOperation : EBehavioralFeature, Operation
        {
        public TemplateParameter OwningTemplateParameter { get; set; }
        public Constraint BodyCondition { get; set; }
        public Class Class { get; set; }
        public DataType Datatype { get; set; }
        public Interface Interface { get; set; }
        public Boolean IsOrdered { get; }
        public Boolean IsQuery { get; set; }
        public Boolean IsUnique { get; }
        public Int32? Lower { get; }
        public IList<Constraint> Postcondition { get; }
        public IList<Constraint> Precondition { get; }
        public IList<Operation> RedefinedOperation { get; }
        public OperationTemplateParameter TemplateParameter { get; set; }
        public Type Type { get; }
        public UnlimitedNatural? Upper { get; }

        public EOperation()
            {
            RedefinedOperation = new List<Operation>();
            Precondition = new List<Constraint>();
            Postcondition = new List<Constraint>();
            }

        public Boolean isOrdered()
            {
            throw new NotImplementedException();
            }

        public Boolean isUnique()
            {
            throw new NotImplementedException();
            }

        public Int32 lower()
            {
            throw new NotImplementedException();
            }

        public Parameter[] returnResult()
            {
            throw new NotImplementedException();
            }

        public Type type()
            {
            throw new NotImplementedException();
            }

        public UnlimitedNatural upper()
            {
            throw new NotImplementedException();
            }

        TemplateParameter ParameterableElement.TemplateParameter
            {
            get { return TemplateParameter; }
            set { TemplateParameter = null;/*value;*/ }
            }

        public Boolean isCompatibleWith(ParameterableElement p)
            {
            throw new NotImplementedException();
            }

        public Boolean isTemplateParameter()
            {
            throw new NotImplementedException();
            }

        public TemplateSignature OwnedTemplateSignature { get; set; }
        public IList<TemplateBinding> TemplateBinding { get; }
        public Boolean isTemplate()
            {
            throw new NotImplementedException();
            }

        public ParameterableElement[] parameterableElements()
            {
            throw new NotImplementedException();
            }
        }
    }