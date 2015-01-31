using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Business.Entities;

namespace TeamProject.Business.Contracts
{
    public interface ITeamProjectService
    {
        IEnumerable<Project> GetTeamProjects();

        Project GetTeamProject(int id);

        
    }
}
