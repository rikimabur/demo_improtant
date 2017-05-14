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
    public interface IFooterService
    {
        Footer Add(Footer footer);
        void Update(Footer footer);
        Footer Delete(int id);
        IEnumerable<Footer> GetAll();
        Footer GetById(int id);
        void Save();
    }
    public class FooterService : IFooterService
    {
        private IFooterRepository _footerRepository;
        private IUnitOfWork _unitOfWork;
        public FooterService(IFooterRepository footerRepository, IUnitOfWork unitOfWork)
        {
            this._footerRepository = footerRepository;
            this._unitOfWork = unitOfWork;
        }
        public Footer Add(Footer footer)
        {
            var new_footer = _footerRepository.Add(footer);
            _unitOfWork.Commit();
            return new_footer;
        }

        public Footer Delete(int id)
        {
            return _footerRepository.Delete(id);
        }

        public IEnumerable<Footer> GetAll()
        {
            return _footerRepository.GetAll();
        }

        public Footer GetById(int id)
        {
            return _footerRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Footer footer)
        {
            _footerRepository.Update(footer);
        }
    }
}
