﻿using PhuocCon.Common;
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
    public interface IApplicationRoleService
    {
        ApplicationRole GetDetail(string id);
        IEnumerable<ApplicationRole> GetAll(int page, int pageSize, out int totalRow, string filter);
        IEnumerable<ApplicationRole> GetAll();
        ApplicationRole Add(ApplicationRole appRole);
        void Update(ApplicationRole appRole);
        void Delete(string id);
        //add roles to a sepcify group
        bool AddRolesToGroup(IEnumerable<ApplicationRoleGroup> roleGroups, int groupId);
        //Get list role by group id
        IEnumerable<ApplicationRole> GetListRoleByGroupId(int groupId);
        void Save();

    }
    public class ApplicationRoleService : IApplicationRoleService
    {
        private IApplicationRoleRepository _appRoleRepository;
        private IApplicationRoleGroupRepository _appRoleGroupRepository;
        private IUnitOfWork _unitOfWork;
        public ApplicationRoleService(IApplicationRoleRepository appRoleRepository, IApplicationRoleGroupRepository appRoleGroupRepository, IUnitOfWork unitOfWork)
        {
            this._appRoleRepository = appRoleRepository;
            this._unitOfWork = unitOfWork;
            this._appRoleGroupRepository = appRoleGroupRepository;
        }

        public ApplicationRole GetDetail(string id)
        {
            return _appRoleRepository.GetSingleByCondition(x => x.Id == id);
        }

        public IEnumerable<ApplicationRole> GetAll(int page, int pageSize, out int totalRow, string filter)
        {
            var query = _appRoleRepository.GetAll();
            if (!string.IsNullOrEmpty(filter))
                query = query.Where(x => x.Description.Contains(filter));
            totalRow = query.Count();
            return query.OrderBy(x => x.Description).Skip(page * pageSize).Take(pageSize);
        }

        public IEnumerable<ApplicationRole> GetAll()
        {
            return _appRoleRepository.GetAll();
        }

        public ApplicationRole Add(ApplicationRole appRole)
        {
            if(_appRoleRepository.CheckContains(x=>x.Description == appRole.Description))
                throw new NameDuplicatedException("Tên không được trùng");
            return _appRoleRepository.Add(appRole);
        }

        public void Update(ApplicationRole appRole)
        {
            if(_appRoleRepository.CheckContains(x=>x.Description == appRole.Description && x.Id!= appRole.Id))
                throw new NameDuplicatedException("Tên không được trùng");
            _appRoleRepository.Update(appRole);
        }

        public void Delete(string id)
        {
            _appRoleRepository.DeleteMulti(x => x.Id == id);
        }

        public bool AddRolesToGroup(IEnumerable<ApplicationRoleGroup> roleGroups, int groupId)
        {
            _appRoleGroupRepository.DeleteMulti(x => x.GroupId == groupId);
            foreach (var roleGroup in roleGroups)
            {
                _appRoleGroupRepository.Add(roleGroup);
            }
            return true;
        }

        public IEnumerable<ApplicationRole> GetListRoleByGroupId(int groupId)
        {
            return _appRoleRepository.GetListRoleByGroupId(groupId);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
