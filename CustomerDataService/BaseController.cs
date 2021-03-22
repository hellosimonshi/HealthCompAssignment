using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using CustomerDataService.Interfaces;

namespace CustomerDataService
{
    public abstract class BaseController : ControllerBase, IBaseController
    {
        public ModelStateDictionary modelState { get; } = new ModelStateDictionary();
    }
}
