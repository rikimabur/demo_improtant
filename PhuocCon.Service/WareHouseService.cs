using PhuocCon.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuocCon.Service
{
    public interface IWareHouseService
    {
        IEnumerable<WareHouse> GetAll();
        void Save();
    }
    public class WareHouseService : IWareHouseService
    {
        public IEnumerable<WareHouse> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
