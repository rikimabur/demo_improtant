using PhuocCon.Data.infrastructure;
using PhuocCon.Data.Repositories;
using PhuocCon.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuocCon.Service
{
    public interface IApplicationUserService
    {
        IEnumerable<ApplicationUser> DetailUser(string userName);
    }
    public class ApplicationUserService : IApplicationUserService
    {
        private IApplicationUserRepository _applicationUserRepository;
        private IUnitOfWork _unitOfWork;
        public ApplicationUserService(IApplicationUserRepository applicationUserRepository, IUnitOfWork unitOfWork)
        {
            this._applicationUserRepository = applicationUserRepository;
            this._unitOfWork = unitOfWork;
        }
        public IEnumerable<ApplicationUser> DetailUser(string userName)
        {
            return _applicationUserRepository.GetMulti(x => x.FullName == userName);
        }
    }
}
