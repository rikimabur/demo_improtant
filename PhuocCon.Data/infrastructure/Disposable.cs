using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PhuocCon.Data.infrastructure
{
    // cho phép nhưng cái nào kế thừa tự động hủy
    public class Disposable : IDisposable
    {
        private bool isDisposed;
        ~Disposable()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // thu hoi bo nho
        }
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }
            isDisposed = true;
        }
        // Ovveride this to dispose custom objects
        protected virtual void DisposeCore()
        {
 
        }
    }
}
