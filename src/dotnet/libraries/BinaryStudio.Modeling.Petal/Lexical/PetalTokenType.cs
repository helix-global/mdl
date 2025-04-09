namespace BinaryStudio.Modeling.Petal
    {
    public enum PetalTokenType
        {
        Invalid,
        WhiteSpace   = 'w',
        EndOfFile    = 'e',
        Integer      = 'n',
        Boolean      = 'b',
        Float        = 'f',
        String       = 's',
        OpenBracket  = '(',
        CloseBracket = ')',
        Comma        = ',',
        Identifer    = 'i',
        Reference    = '@'
        }
    }