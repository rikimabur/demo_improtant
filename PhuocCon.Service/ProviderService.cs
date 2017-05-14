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
    public interface IProviderService
    {
        Provider Add(Provider provider);
        void Update(Provider provider);
        IEnumerable<Provider> GetAll();
        IEnumerable<Provider> GetAll(string keyword);
        IEnumerable<Provider> Search(string keyword, int page, int pageSize,out int totalRow);
        Provider Delete(int id);
        Provider GetById(int id);
        void Save();

    }
    public class ProviderService : IProviderService
    {
        private IProviderRepository _providerRepository;
        private IUnitOfWork _unitOfWork;
        public ProviderService(IProviderRepository providerRepository, IUnitOfWork unitOfWork)
        {
            this._providerRepository = providerRepository;
            this._unitOfWork = unitOfWork;
        }

        public Provider Delete(int id)
        {
            return _providerRepository.Delete(id);
        }

        public IEnumerable<Provider> GetAll()
        {
            return _providerRepository.GetAll();
        }

        public IEnumerable<Provider> Search(string keyword, int page, int pageSize, out int totalRow)
        {
            var query = _providerRepository.GetMulti(x => x.Status && x.Name.Contains(keyword)).OrderBy(x => x.ID);
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);

        }

        public Provider GetById(int id)
        {
            return _providerRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public Provider Add(Provider provider)
        {
            return _providerRepository.Add(provider);
        }

        public void Update(Provider provider)
        {
            _providerRepository.Update(provider);
        }

        public IEnumerable<Provider> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _providerRepository.GetMulti(x => x.Name.Contains(keyword));
            else
                return _providerRepository.GetAll();
        }
    }
}
