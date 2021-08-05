using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spacecrafts.Website.Models;
using Spacecrafts.Website.Services;

namespace Spacecrafts.Website.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpacecraftsController : ControllerBase
    {
        public SpacecraftsController(SpaceCraftJsonService spacecraftService)
        {

            SpaceCraftService  = spacecraftService;
            
        }

        public SpaceCraftJsonService SpaceCraftService {get; private set;}

        [HttpGet]
        public IEnumerable<SpaceCraft> Get()
        {
           return  this.SpaceCraftService.GetSpaceCrafts();
        }

    }
}
