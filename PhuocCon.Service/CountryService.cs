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
    public interface ICountryService
    {
        void Add(Country country);
        void Update(Country country);
        Country Delete(int id);
        IEnumerable<Country> GetAll();
        IEnumerable<Country> GetAll(string keyword);
     
        void SaveChange();
        IEnumerable<Province> GetProvince(int id);
    }
    public class CountryService : ICountryService
    {
        ICountryRepository _countryRepository;
        IUnitOfWork _unitOfWork;
        IProvinceRepository _provinceRepository;
        public CountryService(ICountryRepository countryRepository, IUnitOfWork unitOfWork, IProvinceRepository provinceRepository)
        {
            this._countryRepository = countryRepository;
            this._unitOfWork = unitOfWork;
            this._provinceRepository = provinceRepository;
        }
        public void Add(Country country)
        {
            _countryRepository.Add(country);
        }

        public Country Delete(int id)
        {
            return _countryRepository.Delete(id); ;
        }

        public IEnumerable<Country> GetAll()
        {
            return _countryRepository.GetAll();
        }

        public void Update(Country country)
        {
            _countryRepository.Update(country);
        }
        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Country> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _countryRepository.GetMulti(x => x.Name == keyword);
            }
            else
            {
                return _countryRepository.GetAll();
            }
        }

        public IEnumerable<Province> GetProvince(int id)
        {
            return _provinceRepository.GetMulti(x => x.ID == id);
        }
    }
}
