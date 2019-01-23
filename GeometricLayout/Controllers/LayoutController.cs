using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeometricLayout.Services;

namespace GeometricLayout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LayoutController : ControllerBase
    {
        private readonly LayoutService _layoutService;

        public LayoutController(LayoutService layoutService)
        {
            layoutService = _layoutService;
        }

    }
}