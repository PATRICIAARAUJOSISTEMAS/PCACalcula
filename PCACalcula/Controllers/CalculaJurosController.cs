using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using PCACalcula.Domain.Interfaces;
using PCACalcula.Models;

namespace PCACalcula.Controllers
{
    [Route("PCACalcula/[controller]")]
    public class CalculaJurosController : BaseController
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
              return ResponseOk(_calculaJurosService.Calcula(viewModel.ValorInicial, viewModel.Meses), _calculaJurosService);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }
    }
}