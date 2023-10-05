using Application.ModelsServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IModelsService _modelsService;

        public ModelsController(IModelsService modelsService)
        {
            _modelsService = modelsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string modelyear,string make)
        {
            var result = await _modelsService.GetAllModels(modelyear, make);
            return Ok(result);
        }
    }
}
