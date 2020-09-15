using DAL.Context;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UOW : IUOW
    {
        private ReferenceDBContext Context;
        private IPersonRepository personRepository;

        public UOW(ReferenceDBContext context)
        {
            Context = context;
        }

        public IPersonRepository PersonRepository
        {
            get
            {
                if (personRepository == null)
                    personRepository = new PersonRepository(Context);
                return personRepository;
            }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
