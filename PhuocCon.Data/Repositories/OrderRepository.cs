using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhuocCon.Data.infrastructure;
using PhuocCon.Model.Models;
using PhuocCon.Common.ViewModels;
using System.Data.SqlClient;

namespace PhuocCon.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<RevenuesStatisticViewModel> GetRevenuesStatistic(string fromDate, string toDate);
    } 
    public class OrderRepository : RepositoryBase<Order>,IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory){ }


        public IEnumerable<RevenuesStatisticViewModel> GetRevenuesStatistic(string fromDate, string toDate)
        {
            var parameters = new SqlParameter[]{
                new SqlParameter("@fromDate", fromDate),
                new SqlParameter("@toDate", toDate)
            };
            return DbContext.Database.SqlQuery<RevenuesStatisticViewModel>("GetRevenueStatistic @fromDate,@toDate", parameters);
        }
    }
}
