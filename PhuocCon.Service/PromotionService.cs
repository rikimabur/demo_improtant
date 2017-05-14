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
    public interface IPromotionService
    {
        IEnumerable<Promotion> GetAll();
        Promotion GetById(int id);
        void Add(Promotion promotion);
        void Update(Promotion promotion);
        void Delete(int id);
        void Save();


    }
    public class PromotionService : IPromotionService
    {
        private IPromotionRepository _promotionRepository;
        private IUnitOfWork _uniOfWork;
        public PromotionService(IPromotionRepository promotionRepository, IUnitOfWork uniOfWork)
        {
            this._promotionRepository = promotionRepository;
            this._uniOfWork = uniOfWork;
        }
        public void Add(Promotion promotion)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Promotion> GetAll()
        {
            return _promotionRepository.GetAll();
        }

        public Promotion GetById(int id)
        {
            return _promotionRepository.GetSingleById(id);
        }

        public void Save()
        {
            _uniOfWork.Commit();
        }

        public void Update(Promotion promotion)
        {
            throw new NotImplementedException();
        }
    }
}
