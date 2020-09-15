using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Interfaces
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        IEnumerable<Person> FindByCondition(Expression<Func<Person, bool>> expression, string sortOrder, int page);
        IEnumerable<LinkedPerson> GetPersonLinkedPeople(int Id);
        Person GetDetailedInformation(int Id);
        void AddLinkedPerson(int Id, int linkTypeId, Person person);
    }
}
