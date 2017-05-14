using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhuocCon.Data.infrastructure;
using PhuocCon.Model.Models;
namespace PhuocCon.Data.Repositories
{
    public interface IVisistorStatisticRepository : IRepository<VisistorStatistic>
    {

    }
    class VisistorStatisticRepository : RepositoryBase<VisistorStatistic>, IVisistorStatisticRepository
    {
        public VisistorStatisticRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
