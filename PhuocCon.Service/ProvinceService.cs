using PhuocCon.Data.infrastructure;
using PhuocCon.Data.Repositories;
using PhuocCon.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhuocCon.Service
{
    public interface IProvinceService
    {
        void Add(Province province);
        Province Delete(int id);
        void Update(Province province);
        IEnumerable<Province> GetAll();
        IEnumerable<Province> GetAll(string keyword);
        IEnumerable<Province> GetById(int id);
        void SaveChange();
    }
    public class ProvinceService : IProvinceService
    {
        IProvinceRepository _provinceRepository;
        IUnitOfWork _unitOfWork;
        public ProvinceService(IProvinceRepository provinceRepository, IUnitOfWork unitOfWork)
        {
            this._provinceRepository = provinceRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(Province province)
        {
            _provinceRepository.Add(province);
        }

        public Province Delete(int id)
        {
           return _provinceRepository.Delete(id);
        }

        public IEnumerable<Province> GetAll()
        {
            return _provinceRepository.GetAll();
        }

        public IEnumerable<Province> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _provinceRepository.GetMulti(x => x.Name == keyword);
            }
            else
            {
                return _provinceRepository.GetAll();
            }
        }

        public IEnumerable<Province> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public void Update(Province province)
        {
            _provinceRepository.Update(province);
        }
    }
}
