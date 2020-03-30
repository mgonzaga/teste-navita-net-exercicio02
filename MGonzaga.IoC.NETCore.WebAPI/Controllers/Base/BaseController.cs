using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MGonzaga.IoC.NETCoreWebAPI.Controllers.Base
{
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {

    }
}