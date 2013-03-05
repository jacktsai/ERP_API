using System;

namespace Yahoo
{
    public interface IAuthority
    {
        bool CanSelect { get; }
        bool CanInsert { get; }
        bool CanUpdate { get; }
        bool CanDelete { get; }
        bool CanParticular { get; }
    }
}
