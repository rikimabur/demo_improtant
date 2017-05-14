using PhuocCon.Data.infrastructure;
using PhuocCon.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuocCon.Data.Repositories
{
    public interface IProvinceRepository : IRepository<Province>
    {

    }
    public class ProvinceRepository :RepositoryBase<Province>, IProvinceRepository
    {
        public ProvinceRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
