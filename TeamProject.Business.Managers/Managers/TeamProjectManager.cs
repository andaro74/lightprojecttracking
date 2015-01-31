using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Business.Common;
using TeamProject.Business.Contracts;
using TeamProject.Business.Entities;
using TeamProject.Data.Contracts;

namespace TeamProject.Business.Managers
{
    public class TeamProjectManager: ITeamProjectService
    {
        ITeamProjectEngine _TeamProjectEngine;
        ICompanyRepository _CompanyRepository;
        IProjectRepository _ProjectRepository;
        ITeamMemberRepository _TeamMemberRepository;
        IContactRepository _ContactRepository;

        public TeamProjectManager()
        {
        }

        public TeamProjectManager(ITeamProjectEngine teamProjectEngine)
        {
            _TeamProjectEngine = teamProjectEngine;
        }

     
        public TeamProjectManager(IProjectRepository projectRepository, ITeamMemberRepository teamMemberRepository, IContactRepository contactRepository,
           ITeamProjectEngine teamProjectEngine)
        {
            _ProjectRepository = projectRepository;
            _TeamMemberRepository = teamMemberRepository;
            _TeamProjectEngine = teamProjectEngine;
            _ContactRepository = contactRepository;

        }

        public IEnumerable<Project> GetTeamProjects()
        {
            IEnumerable<Project> projects = _ProjectRepository.Get();
            return projects;

        }

        public Project GetTeamProject(int id)
        {
           Project project= _ProjectRepository.Get(id);
           IEnumerable<TeamMember> members= _TeamMemberRepository.Get().Where(p => p.ProjectId == id);
           project.TeamMembers = members;

           foreach (var m in project.TeamMembers)
            {
                m.ContactInfo = _ContactRepository.Get(m.ContactId);
            }

           return project;
        }
    }
}
