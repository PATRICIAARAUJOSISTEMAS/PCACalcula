using Microsoft.AspNetCore.Mvc;
using PCACalcula.Domain.Interfaces;
using System;
using System.Net;

namespace PCACalcula.Controllers
{
    public class BaseController : Controller
    {
        private IServiceBase _serviceBase;

        protected new IActionResult ResponseOk(object result, IServiceBase serviceBase)
        {
            _serviceBase = serviceBase;

            if (serviceBase.IsValid())
                return Ok(new
                {
                    data = result
                });
            else
            {
                return BadRequest(new
                {
                    errors = serviceBase.Notifications
                });
            }
        }
        protected new IActionResult ResponseException(Exception ex)
        {
            return StatusCode(
                (int)HttpStatusCode.InternalServerError,
                    new
                    {
                        errors = ex.Message
                    }
                );
        }
    }
}
