﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseControllerController : ControllerBase
    {
        public int MyProperty { get; set; }
    }
}