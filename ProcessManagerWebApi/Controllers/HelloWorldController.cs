using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProcessManagerWebApi.Controllers
{
    public class HelloWorldController : Controller
    {

        [HttpGet]
        [Route("Index")]
        public string Index()
        {
            return "Hello World";
        }
    }
}