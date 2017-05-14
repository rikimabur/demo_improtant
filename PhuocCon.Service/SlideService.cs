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
    public interface ISlideService
    {
        IEnumerable<Slide> GetAll();
        void Save();
    }
    public class SlideService : ISlideService
    {
        private ISlideRepository _slideRepository;
        private IUnitOfWork _unitOfWord;
        public SlideService(ISlideRepository slideRepository, IUnitOfWork unitOfWord)
        {
            this._slideRepository = slideRepository;
            this._unitOfWord = unitOfWord;
        }

        public IEnumerable<Slide> GetAll()
        {
            return _slideRepository.GetAll();
        }
        public void Save()
        {
            _unitOfWord.Commit();
        }

    }
}
