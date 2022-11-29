using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {

    }
}
