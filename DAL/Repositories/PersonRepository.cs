using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repositories
{
    public class PersonRepository : RepositoryBase<Person>,IPersonRepository
    {

        public PersonRepository(ReferenceDBContext context) : base(context)
        { }
        

        public IEnumerable<Person> FindByCondition(Expression<Func<Person, bool>> expression, string sortOrder, int page)
        {
            int numberOfObjectsPerPage = 10;
            IEnumerable<Person> returnList = Enumerable.Empty<Person>();
            switch (sortOrder)
            {
                case "nameGeo":
                    returnList = Context.People.Where(expression).OrderBy(x=>x.NameGeo).Skip(numberOfObjectsPerPage*(page-1)).Take(numberOfObjectsPerPage).Include(x=>x.ContactInformation);
                    break;
                case "nameEng":
                    returnList = Context.People.Where(expression).OrderBy(x => x.NameEng).Skip(numberOfObjectsPerPage * (page - 1)).Take(numberOfObjectsPerPage).Include(x => x.ContactInformation);
                    break;
                case "surnameGeo":
                    returnList = Context.People.Where(expression).OrderBy(x => x.SurnameGeo).Skip(numberOfObjectsPerPage * (page - 1)).Take(numberOfObjectsPerPage).Include(x => x.ContactInformation);
                    break;
                case "surnameEng":
                    returnList = Context.People.Where(expression).OrderBy(x => x.SurnameEng).Skip(numberOfObjectsPerPage * (page - 1)).Take(numberOfObjectsPerPage).Include(x => x.ContactInformation);
                    break;
                case "birtDate":
                    returnList = Context.People.Where(expression).OrderBy(x => x.BirthDate).Skip(numberOfObjectsPerPage * (page - 1)).Take(numberOfObjectsPerPage).Include(x => x.ContactInformation);
                    break;
                case "address":
                    returnList = Context.People.Where(expression).OrderBy(x => x.Address).Skip(numberOfObjectsPerPage * (page - 1)).Take(numberOfObjectsPerPage).Include(x => x.ContactInformation);
                    break;
            }
            return returnList;
        }

        public IEnumerable<LinkedPerson> GetPersonLinkedPeople(int Id)
        {
            return Context.People.Where(x=>x.Id==Id).Include(x=>x.LinkedPerson).FirstOrDefault().LinkedPerson; 
        }

        public Person GetDetailedInformation(int Id)
        {
            return Context.People.Where(x => x.Id == Id).Include(x => x.ContactInformation).FirstOrDefault();
        }

        public void AddLinkedPerson(int Id,int linkTypeId, Person person)
        {
            Person Current = Get(Id);
            LinkedPerson linked = new LinkedPerson()
            {
                LinkType = (LinkType)Context.LinkTypes.Find(linkTypeId),
                Person = person
            };
            Current.LinkedPerson.Add(linked); 
        }
    }
}
