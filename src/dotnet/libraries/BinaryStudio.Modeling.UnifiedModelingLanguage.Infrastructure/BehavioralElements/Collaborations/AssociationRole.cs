namespace BinaryStudio.Modeling.UnifiedModelingLanguage.Infrastructure
    {
    public partial interface AssociationRole : Association
        {
        Association @base { get; }
        Link[] conformingLink { get; }
        Message[] nessage { get; }
        Multiplicity multiplicity { get; }
        }
    }
