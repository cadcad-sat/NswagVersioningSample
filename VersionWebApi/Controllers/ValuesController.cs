using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace VersionWebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("0")]
    [ApiVersion("1")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [MapToApiVersion("0")]
        public ActionResult<IEnumerable<string>> Get0()
        {
            return new string[] { "Version", "0" };
        }

        // GET api/values
        [HttpGet]
        [MapToApiVersion("1")]
        public ActionResult<IEnumerable<string>> Get1()
        {
            return new string[] { "Version", "1" };
        }
    }
}
