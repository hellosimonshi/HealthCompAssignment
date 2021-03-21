using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CustomerDataService.Interfaces
{
    public interface IBaseController
    {
        ModelStateDictionary modelState { get; }
    }
}
