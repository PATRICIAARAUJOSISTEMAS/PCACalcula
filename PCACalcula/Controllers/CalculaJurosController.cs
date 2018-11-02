using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PCACalcula.Domain.Interfaces;
using PCACalcula.Models;

namespace PCACalcula.Controllers
{
    [Route("PCACalcula/[controller]")]
    public class CalculaJurosController : Controller
    {
        private ICalculaJurosService _calculaJurosService;

        public CalculaJurosController(ICalculaJurosService calculaJurosService)
        {
            _calculaJurosService = calculaJurosService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(float), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CalculaJuros(CalculaJurosViewModel viewModel)
        {
            try
            {
              return Ok(_calculaJurosService.Calcula(viewModel.ValorInicial, viewModel.Meses));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}