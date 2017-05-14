using PhuocCon.Common;
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
    public interface IApplicationGroupService
    {
        ApplicationGroup GetDetail(int id);
        IEnumerable<ApplicationGroup> GetAll(int page, int pageSize, out int totalRow, string filter);
        IEnumerable<ApplicationGroup> GetAll();
        ApplicationGroup Add(ApplicationGroup appGroup);
        void Update(ApplicationGroup appGroup);
        ApplicationGroup Delete(int id);
        bool AddUserToGroup(IEnumerable<ApplicationUserGroup> userGroups, string userId);
        IEnumerable<ApplicationUser> GetListUserByGroupId(int groupId);
        IEnumerable<ApplicationGroup> GetListGroupByUserId(string userId);
        void Save();
    }
    public class ApplicationGroupService : IApplicationGroupService
    {
        private IApplicationGroupRepository _applicationGroupRepository;
        private IUnitOfWork _unitOfWork;
        private IApplicationUserGroupRepository _applicationUserGroupRepository;
        public ApplicationGroupService(IApplicationGroupRepository applicationGroupRepository, IUnitOfWork unitOfWork, IApplicationUserGroupRepository applicationUserGroupRepository)
        {
            this._applicationGroupRepository = applicationGroupRepository;
            this._unitOfWork = unitOfWork;
            this._applicationUserGroupRepository = applicationUserGroupRepository;
        }
        public ApplicationGroup Add(ApplicationGroup appGroup)
        {
            if (_applicationGroupRepository.CheckContains(x => x.Name == appGroup.Name))
                throw new NameDuplicatedException("Tên không được trùng");
            return _applicationGroupRepository.Add(appGroup);
        }

        public bool AddUserToGroup(IEnumerable<ApplicationUserGroup> userGroups, string userId)
        {
            _applicationUserGroupRepository.DeleteMulti(x => x.UserId == userId);
            foreach (var userGroup in userGroups)
            {
                _applicationUserGroupRepository.Add(userGroup);
            }
            return true;
        }

        public ApplicationGroup Delete(int id)
        {
            var appGroup = this._applicationGroupRepository.GetSingleById(id);
            return _applicationGroupRepository.Delete(appGroup);
        }

        public IEnumerable<ApplicationGroup> GetAll()
        {
            return _applicationGroupRepository.GetAll();
        }

        public IEnumerable<ApplicationGroup> GetAll(int page, int pageSize, out int totalRow, string filter)
        {
            var query = _applicationGroupRepository.GetAll();
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Name.Contains(filter));

            totalRow = query.Count();
            return query.OrderBy(x => x.Name).Skip(page * pageSize).Take(pageSize);
        }

        public ApplicationGroup GetDetail(int id)
        {
            return _applicationGroupRepository.GetSingleById(id);
        }

        public IEnumerable<ApplicationGroup> GetListGroupByUserId(string userId)
        {
            return _applicationGroupRepository.GetListGroupByUserId(userId);
        }

        public IEnumerable<ApplicationUser> GetListUserByGroupId(int groupId)
        {
            return _applicationGroupRepository.GetListUserByGroupId(groupId);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ApplicationGroup appGroup)
        {
            if (_applicationGroupRepository.CheckContains(x => x.Name == appGroup.Name))
                throw new NameDuplicatedException("tên không được trùng");
            _applicationGroupRepository.Update(appGroup);
        }
    }
}
