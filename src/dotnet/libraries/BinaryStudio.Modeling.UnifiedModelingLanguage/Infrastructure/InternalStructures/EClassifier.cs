using System;
using System.Collections.Generic;

namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure.InternalStructures
    {
    internal abstract class EClassifier : EType,Classifier
        {
        public Boolean IsLeaf { get;set; }
        public IList<RedefinableElement> RedefinedElement { get; }
        public IList<Classifier> RedefinitionContext { get; }
        public IList<ElementImport> ElementImport { get; }
        public IList<PackageableElement> ImportedMember { get; }
        public IList<NamedElement> Member { get; }
        public IList<NamedElement> OwnedMember { get; }
        public IList<Constraint> OwnedRule { get; }
        public IList<PackageImport> PackageImport { get; }
        public IList<Property> Attribute { get; }
        public IList<CollaborationUse> CollaborationUse { get; }
        public IList<Feature> Feature { get; }
        public IList<Classifier> General { get; }
        public IList<Generalization> Generalization { get; }
        public IList<NamedElement> InheritedMember { get; }
        public Boolean IsAbstract { get;set; }
        public Boolean IsFinalSpecialization { get;set; }
        public RedefinableTemplateSignature OwnedTemplateSignature { get;set; }
        public IList<UseCase> OwnedUseCase { get; }
        public IList<GeneralizationSet> PowertypeExtent { get; }
        public IList<Classifier> RedefinedClassifier { get; }
        public CollaborationUse Representation { get; set; }
        public IList<Substitution> Substitution { get; }
        public ClassifierTemplateParameter TemplateParameter { get;set; }
        public IList<UseCase> UseCase { get; }

        protected EClassifier()
            {
            OwnedRule = new List<Constraint>();
            Generalization = new List<Generalization>();
            }

        public Boolean isConsistentWith(RedefinableElement redefiningElement)
            {
            throw new NotImplementedException();
            }

        public Boolean isRedefinitionContextValid(RedefinableElement redefinedElement)
            {
            throw new NotImplementedException();
            }

        public Property[] allAttributes()
            {
            throw new NotImplementedException();
            }

        public Feature[] allFeatures()
            {
            throw new NotImplementedException();
            }

        public Classifier[] allParents()
            {
            throw new NotImplementedException();
            }

        public Interface[] allRealizedInterfaces()
            {
            throw new NotImplementedException();
            }

        public StructuralFeature[] allSlottableFeatures()
            {
            throw new NotImplementedException();
            }

        public Interface[] allUsedInterfaces()
            {
            throw new NotImplementedException();
            }

        public Interface[] directlyRealizedInterfaces()
            {
            throw new NotImplementedException();
            }

        public Interface[] directlyUsedInterfaces()
            {
            throw new NotImplementedException();
            }

        public Classifier[] general()
            {
            throw new NotImplementedException();
            }

        public Boolean hasVisibilityOf(NamedElement n)
            {
            throw new NotImplementedException();
            }

        public NamedElement[] inherit(NamedElement[] inhs)
            {
            throw new NotImplementedException();
            }

        public NamedElement[] inheritableMembers(Classifier c)
            {
            throw new NotImplementedException();
            }

        public NamedElement[] inheritedMember()
            {
            throw new NotImplementedException();
            }

        public Boolean isSubstitutableFor(Classifier contract)
            {
            throw new NotImplementedException();
            }

        Boolean Classifier.isTemplate()
            {
            throw new NotImplementedException();
            }

        public Boolean maySpecializeType(Classifier c)
            {
            throw new NotImplementedException();
            }

        public Classifier[] parents()
            {
            throw new NotImplementedException();
            }

        TemplateSignature TemplateableElement.OwnedTemplateSignature
            {
            get { return OwnedTemplateSignature; }
            set { OwnedTemplateSignature = null/*value*/; }
            }

        public IList<TemplateBinding> TemplateBinding { get; }
        Boolean TemplateableElement.isTemplate()
            {
            throw new NotImplementedException();
            }

        public ParameterableElement[] parameterableElements()
            {
            throw new NotImplementedException();
            }

        public PackageableElement[] excludeCollisions(PackageableElement[] imps)
            {
            throw new NotImplementedException();
            }

        public String[] getNamesOfMember(NamedElement element)
            {
            throw new NotImplementedException();
            }

        public PackageableElement[] importedMember()
            {
            throw new NotImplementedException();
            }

        public PackageableElement[] importMembers(PackageableElement[] imps)
            {
            throw new NotImplementedException();
            }

        public Boolean membersAreDistinguishable()
            {
            throw new NotImplementedException();
            }

        #region M:ToString:String
        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() {
            return String.IsNullOrWhiteSpace(Name)
                ? $"Classifier"
                : $"Classifier{{{Name}}}";
            }
        #endregion
        }
    }