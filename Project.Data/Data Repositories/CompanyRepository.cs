using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Business.Entities;
using TeamProject.Data.Contracts;

namespace TeamProject.Data
{
    public class CompanyRepository:DataRepositoryBase<Company>,ICompanyRepository
    {
        protected override Company AddEntity(TeamProjectContext entityContext, Company entity)
        {
            throw new NotImplementedException();
        }

        protected override Company UpdateEntity(TeamProjectContext entityContext, Company entity)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Company> GetEntities(TeamProjectContext entityContext)
        {
            throw new NotImplementedException();
        }

        protected override Company GetEntity(TeamProjectContext entityContext, int id)
        {
            throw new NotImplementedException();
        }
    }
}
