﻿using APISistemaQuadidade.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISistemaQuadidade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("appication/json")]
    public class MockSearchController : ControllerBase
    {
        private IMockSearchService mockSearchService;

        public MockSearchController(IMockSearchService mockSearchService)
        {
            this.mockSearchService = mockSearchService;
        }
    }
}
