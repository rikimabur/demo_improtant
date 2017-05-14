using System;

namespace PhuocCon.Data.infrastructure
{
    //1giao tiếp khởi tạo các đối tượng không cần tạo trực tiếp
    public interface IDbFactory : IDisposable
    {
        PhuocConDbContext Init();

    }
}
