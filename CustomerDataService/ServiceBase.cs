using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerDataService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDataService
{
    public abstract class ServiceBase : IServiceBase
    {
        private IBaseController _controller;
        protected IBaseController Controller { get { return _controller; } }
        public void Register(IBaseController controller)
        {
            this._controller = controller;
        }
    }
}
