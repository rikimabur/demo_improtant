using PhuocCon.Data.infrastructure;
using PhuocCon.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuocCon.Data.Repositories
{
    public interface IColorRepository : IRepository<Color>
    {

    }
    public class ColorRepository : RepositoryBase<Color>,IColorRepository
    {
        public ColorRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
