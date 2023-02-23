using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slp.Services.Services.Interfaces
{
    public interface IAuthService
    {
        Guid GetCurrentUserId();
    }
}
