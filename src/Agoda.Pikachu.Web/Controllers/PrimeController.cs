using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agoda.Pikachu.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agoda.Pikachu.Web.Controllers
{
    [Route("api/prime")]
    [ApiController]
    public class PrimeController : ControllerBase
    {
        [HttpGet("is")]
        public bool IsPrime(int myInt)
        { 
            return myInt.IsPrime();

        }
    }
}