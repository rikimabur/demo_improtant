using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhuocCon.Data.infrastructure;
using PhuocCon.Model.Models;
namespace PhuocCon.Data.Repositories
{
    public interface IMenuRepository : IRepository<Menu> 
    { 
    }
    public class MenuRepository:RepositoryBase<Menu>,IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
