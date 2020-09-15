using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repository;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : Controller
    {

        readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {

            _pedidoRepository = pedidoRepository;

        }

        [Route("getAllDapperItens")]
        [HttpGet]
        public async Task<IActionResult> GetAllDapperItens([FromQuery] PedidoViewModel pedidoViewModel )
        {
            var l = await _pedidoRepository.GetAllDapperItens2(pedidoViewModel);
            return Ok(l);
        
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
