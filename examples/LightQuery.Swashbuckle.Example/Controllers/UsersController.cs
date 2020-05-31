using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightQuery.Client;
using LightQuery.EntityFrameworkCore;
using LightQuery.Swashbuckle.Example.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LightQuery.Swashbuckle.Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            AppDbContext appDbContext,
            ILogger<UsersController> logger
        )
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        [HttpGet]
        [AsyncLightQuery(forcePagination: true, defaultPageSize: 3, defaultSort: "columnName desc")]
        [ProducesResponseType(typeof(PaginationResult<User>), 200)]
        public async Task<IActionResult> Get()
        {

            var list = _appDbContext.Users.AsQueryable();

            return Ok(list);
        }
    }
}