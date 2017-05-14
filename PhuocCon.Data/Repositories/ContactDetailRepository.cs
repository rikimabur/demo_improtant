using PhuocCon.Data.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhuocCon.Model.Models;
namespace PhuocCon.Data.Repositories
{
    public interface IContactDetailRepository : IRepository<ContactDetail>
    {
    }
    public class ContactDetailRepository : RepositoryBase<ContactDetail>, IContactDetailRepository
    {
        public ContactDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
