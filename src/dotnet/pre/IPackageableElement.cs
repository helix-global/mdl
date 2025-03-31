namespace pre
    {
    internal interface IPackageableElement : INamedElement
        {
        IPackage Package { get; }
        }
    }