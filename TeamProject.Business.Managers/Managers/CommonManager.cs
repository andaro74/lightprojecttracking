using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.Business.Contracts;
using TeamProject.Data.Contracts;
using TeamProject.Business.Entities;

namespace TeamProject.Business.Managers
{
    public class CommonManager: ICommonService
    {
        IStatusRepository _StatusRepository;
        IDifficultyRepository _DifficultyRepository;
        IPriorityRepository _PriorityRepository;

        public CommonManager()
        {
        }

        public CommonManager(IStatusRepository statusRepository, IDifficultyRepository difficultyRepository, IPriorityRepository priorityRepository)
        {
            _StatusRepository = statusRepository;
            _DifficultyRepository = difficultyRepository;
            _PriorityRepository = priorityRepository;
        }

        public IEnumerable<Status> GetStatuses()
        {
            return _StatusRepository.Get();
        }

        public IEnumerable<Difficulty> GetDifficulties()
        {
            return _DifficultyRepository.Get();
        }

        public IEnumerable<Priority> GetPriorities()
        {
            return _PriorityRepository.Get();
        }
    }
}
