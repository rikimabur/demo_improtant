using PhuocCon.Data.infrastructure;
using PhuocCon.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuocCon.Data.Repositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {

    }
    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
