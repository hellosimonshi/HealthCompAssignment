using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDataService.Interfaces
{
    public interface IServiceBase
    {
        void Register(IBaseController controller);
    }
}
