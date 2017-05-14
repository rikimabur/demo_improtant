using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhuocCon.Model.Models;
using PhuocCon.Data.infrastructure;
namespace PhuocCon.Data.Repositories
{
    public interface IWardRepository : IRepository<Ward> { }
    public class WardRepository : RepositoryBase<Ward>, IWardRepository
    {
        public WardRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
