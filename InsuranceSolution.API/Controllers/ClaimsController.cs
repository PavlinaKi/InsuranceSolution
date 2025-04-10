using InsuranceSolution.Application.Features.Claims.Queries.GetClaims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClaimsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAccessor;

        public ClaimsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns claims of a specific policy.
        /// </summary>
        /// <param name="PolicyNumber"></param>
        /// <returns>Returns claims of a specific policy.</returns>
        [ApiVersion("1.0")]
        [HttpGet("v{version:apiVersion}/{PolicyNumber}", Name = "GetClaims")]
        [ProducesResponseType(typeof(List<ClaimsListVm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ClaimsListVm>>> GetClaims(string PolicyNumber)
        {  
            var getClaims = new GetClaimsQuery() { policyNumber = PolicyNumber };
            var result = await _mediator.Send(getClaims);
            if (result?.Count > 0)
                return Ok(result);
            else
                return NotFound();
        }
    }
}
