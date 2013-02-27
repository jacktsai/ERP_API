using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Yahoo.Business.Security
{
    public class PrivilegeCollection : ICollection<Privilege>
    {
        private readonly User user;

        public PrivilegeCollection(User user)
        {
            this.user = user;
        }

        public void Add(Privilege privilege)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Privilege privilege)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Privilege[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(Privilege privilege)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Privilege> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
