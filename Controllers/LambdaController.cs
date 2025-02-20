using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyApiApp.Services;

namespace MyApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LambdaController : ControllerBase
    {
        private readonly ILambdaService _lambdaService;

        public LambdaController(ILambdaService lambdaService)
        {
            _lambdaService = lambdaService;
        }

        [HttpPost("invoke")]
        public async Task<IActionResult> InvokeLambda([FromBody] string data)
        {
            var response = await _lambdaService.InvokeLambdaAsync(data);
            return Ok(response);
        }
    }
}
