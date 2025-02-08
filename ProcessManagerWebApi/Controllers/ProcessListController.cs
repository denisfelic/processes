using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProcessManagerClassLib;

namespace ProcessManagerWebApi.Controllers
{

    [ApiController]
    [Route("api/processes")]
    public class ProcessListController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<ProcessDto>> GetProcesses()
        {

            var processManager = new ProcessManager();
            var processes = processManager.GetActiveProcesses();
            return Ok(processes);
        }

    }
}