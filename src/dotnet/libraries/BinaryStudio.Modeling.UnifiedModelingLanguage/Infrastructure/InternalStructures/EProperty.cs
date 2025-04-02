using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal class EProperty : EStructuralFeature,Property
        {
        public TemplateParameter OwningTemplateParameter { get; set; }
        public IList<ConnectorEnd> End { get; }
        public ConnectableElementTemplateParameter TemplateParameter { get; set; }
        public ConnectorEnd[] end()
            {
            throw new NotImplementedException();
            }

        TemplateParameter ParameterableElement.TemplateParameter
            {
            get { return TemplateParameter; }
            set { TemplateParameter = null;/*value;*/ }
            }

        public AggregationKind Aggregation { get; set; }
        public Association Association { get; set; }
        public Property AssociationEnd { get; set; }
        public Class Class { get; set; }
        public DataType Datatype { get; set; }
        public ValueSpecification DefaultValue { get; set; }
        public Interface Interface { get; set; }
        public Boolean IsComposite { get; set; }
        public Boolean IsDerived { get; set; }
        public Boolean IsDerivedUnion { get; set; }
        public Boolean IsID { get; set; }
        public Property Opposite { get; set; }
        public Association OwningAssociation { get; set; }
        public IList<Property> Qualifier { get; }
        public IList<Property> RedefinedProperty { get; }
        public IList<Property> SubsettedProperty { get; }

        public EProperty()
            {
            SubsettedProperty = new List<Property>();
            RedefinedProperty = new List<Property>();
            }

        public Boolean isAttribute()
            {
            throw new NotImplementedException();
            }

        Boolean Property.isCompatibleWith(ParameterableElement p)
            {
            throw new NotImplementedException();
            }

        public Boolean isComposite()
            {
            throw new NotImplementedException();
            }

        public Boolean isNavigable()
            {
            throw new NotImplementedException();
            }

        public Property opposite()
            {
            throw new NotImplementedException();
            }

        public Type[] subsettingContext()
            {
            throw new NotImplementedException();
            }

        Boolean ParameterableElement.isCompatibleWith(ParameterableElement p)
            {
            throw new NotImplementedException();
            }

        public Boolean isTemplateParameter()
            {
            throw new NotImplementedException();
            }

        public IList<PackageableElement> DeployedElement { get; }
        public IList<Deployment> Deployment { get; }
        public PackageableElement[] deployedElement()
            {
            throw new NotImplementedException();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"Property"
                : $"Property{{{Name}}}";
            }
        #endregion
        }
    }