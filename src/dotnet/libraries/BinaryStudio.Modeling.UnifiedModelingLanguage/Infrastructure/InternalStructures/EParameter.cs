using System;
using System.Collections.Generic;
using BinaryStudio.Modeling.MetadataInterchange;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EParameter : EElement, Parameter
        {
        public Boolean IsOrdered { get;set; }
        public Boolean IsUnique { get;set; }
        public Int32 Lower { get;set; }
        public ValueSpecification LowerValue { get;set; }
        public UnlimitedNatural Upper { get;set; }
        public ValueSpecification UpperValue { get;set; }

        public Boolean compatibleWith(MultiplicityElement other)
            {
            throw new NotImplementedException();
            }

        public Boolean includesMultiplicity(MultiplicityElement M)
            {
            throw new NotImplementedException();
            }

        public Boolean @is(Int32 lowerbound, UnlimitedNatural upperbound)
            {
            throw new NotImplementedException();
            }

        public Boolean isMultivalued()
            {
            throw new NotImplementedException();
            }

        public Int32? lower()
            {
            throw new NotImplementedException();
            }

        public Int32 lowerBound()
            {
            throw new NotImplementedException();
            }

        public UnlimitedNatural? upper()
            {
            throw new NotImplementedException();
            }

        public UnlimitedNatural upperBound()
            {
            throw new NotImplementedException();
            }

        public TemplateParameter OwningTemplateParameter { get;set; }
        public IList<ConnectorEnd> End { get; }
        public ConnectableElementTemplateParameter TemplateParameter { get;set; }
        public ConnectorEnd[] end()
        {
            throw new NotImplementedException();
        }

        TemplateParameter ParameterableElement.TemplateParameter
        {
            get { return TemplateParameter; }
            set { TemplateParameter = null; /*value;*/ }
        }

        public Boolean isCompatibleWith(ParameterableElement p)
        {
            throw new NotImplementedException();
        }

        public Boolean isTemplateParameter()
        {
            throw new NotImplementedException();
        }

        public IList<Dependency> ClientDependency { get; }
        public String Name { get; set; }
        public StringExpression NameExpression { get;set; }
        public Namespace Namespace { get; }
        public String QualifiedName { get; }
        public VisibilityKind? Visibility { get;set; }
        public Namespace[] allNamespaces()
        {
            throw new NotImplementedException();
        }

        public Package[] allOwningPackages()
        {
            throw new NotImplementedException();
        }

        public Dependency[] clientDependency()
        {
            throw new NotImplementedException();
        }

        public Boolean isDistinguishableFrom(NamedElement n, Namespace ns)
        {
            throw new NotImplementedException();
        }

        public String qualifiedName()
        {
            throw new NotImplementedException();
        }

        public String separator()
        {
            throw new NotImplementedException();
        }

        [IsIDREF] public Type Type { get;set; }
        public String Default { get;set; }
        public ValueSpecification DefaultValue { get;set; }
        public ParameterDirectionKind Direction { get;set; }
        public ParameterEffectKind? Effect { get;set; }
        public Boolean IsException { get;set; }
        public Boolean IsStream { get;set; }
        public Operation Operation { get;set; }
        public IList<ParameterSet> ParameterSet { get; }
        public String @default()
        {
            throw new NotImplementedException();
        }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"Parameter"
                : $"Parameter{{{Name}}}";
            }
        #endregion
        }
    }