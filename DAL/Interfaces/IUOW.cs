using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUOW : IDisposable
    {
        IPersonRepository PersonRepository { get; }
        void Commit();
    }
}
