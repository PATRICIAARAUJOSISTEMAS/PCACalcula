﻿using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using PCACalcula.Domain.Interfaces;

namespace PCACalcula.Controllers
{
    [Route("PCACalcula/[controller]/[action]")]
    public class GitHubController : BaseController
    {
        private IGitHubService _gitHubService;

        public GitHubController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult ShowMetheCode()
        {
            try
            {
                return ResponseOk(_gitHubService.GetUrl(), _gitHubService);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }


    }
}