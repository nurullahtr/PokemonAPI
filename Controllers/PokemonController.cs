using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokemonApi.Models;
using PokemonApi.Services;

namespace PokemonApi.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class PokemonController : ControllerBase {

        private readonly ILogger<PokemonController> _logger;

        private IPokemonService _service;

        public PokemonController (ILogger<PokemonController> logger, IPokemonService service) {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public List<Pokemon> Get () {

            List<Pokemon> response = _service.Get ();

            return response;
        }
    }
}