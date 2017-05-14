using PhuocCon.Common.ViewModels;
using PhuocCon.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuocCon.Service
{
    public interface IStatisticService
    {
        IEnumerable<RevenuesStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate);
    }
    public class StatisticService :IStatisticService
    {
        IOrderRepository _orderRepository;
        public StatisticService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IEnumerable<RevenuesStatisticViewModel> GetRevenueStatistic(string fromDate, string toDate)
        {
            return _orderRepository.GetRevenuesStatistic(fromDate, toDate);
        }
    }
}
