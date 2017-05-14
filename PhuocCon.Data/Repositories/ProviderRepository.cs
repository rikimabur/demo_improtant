using PhuocCon.Data.infrastructure;
using PhuocCon.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuocCon.Data.Repositories
{
    public interface IProviderRepository : IRepository<Provider>
    {

    }
    public class ProviderRepository : RepositoryBase<Provider>, IProviderRepository
    {
        public ProviderRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
