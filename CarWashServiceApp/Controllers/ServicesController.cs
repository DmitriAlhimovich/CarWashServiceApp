using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWashServiceApp.Data;
using CarWashServiceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarWashServiceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        

        private readonly ILogger<ServicesController> _logger;

        public ServicesController(ILogger<ServicesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Service> Index()
        {
            using (var context = new CarWashServiceContext())
            {
                var list = context.Services.Where(s => s.IsAvailable).ToList();

                return list;
            }
        }
    }
}
