using System.Collections.Generic;
using System.Linq;
using FootballManager.Common.Classes;
using FootballManager.Data.UnitOfWorks;
using FootballManager.Domain;

namespace FootballManager.Service
{
    public class NationService: BaseService<Nation>, INationService
    {
        public NationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<NationViewModel> GetAllNationViewModel()
        {
            return this.GetAll().Select(AutoMapper.Mapper.Map<NationViewModel>).OrderBy(x => x.NationName);
        }
    }

    public interface INationService : IBaseService<Nation>
    {
        IEnumerable<NationViewModel> GetAllNationViewModel();
    }
}
