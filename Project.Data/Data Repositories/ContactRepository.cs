using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Business.Entities;
using TeamProject.Data.Contracts;

namespace TeamProject.Data
{
    public class ContactRepository:DataRepositoryBase<Contact>,IContactRepository
    {
        protected override Contact AddEntity(TeamProjectContext entityContext, Contact entity)
        {
            throw new NotImplementedException();
        }

        protected override Contact UpdateEntity(TeamProjectContext entityContext, Contact entity)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Contact> GetEntities(TeamProjectContext entityContext)
        {
            return from e in entityContext.ContactSet select e;
        }

        protected override Contact GetEntity(TeamProjectContext entityContext, int id)
        {
            var query = (from e in entityContext.ContactSet
                         where e.ContactId == id
                         select e);
            var results = query.FirstOrDefault();
            return results;
        }

       
    }
}
