namespace InsuranceSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class ClaimsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IClaimRepository _claimRepository;

        public ClaimsController(IMediator mediator, IClaimRepository claimRepository)
        {
            _mediator = mediator;
            _claimRepository = claimRepository;
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

        /// <summary>
        /// Creates a new claim
        /// </summary>
        /// <param name="Complaint"></param>
        /// <returns>Creates a new claim.</returns>
        [ApiVersion("1.0")]
        [HttpPost("v{version:apiVersion}/claim", Name = "CreateClaim")]
        [ProducesResponseType(typeof(CreateClaimCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateClaimCommandResponse>> CreateClaim([FromBody] CreateClaimCommand createClaimCommand)
        {
            var result = await _mediator.Send(createClaimCommand);
            if (result?.Success == true)
                return Created($@"api/claim/v1/{result.Claim.ClaimId}", result);
            else
                return BadRequest(result);

        }

        /// <summary>
        /// Updates an existing claim
        /// </summary>
        /// <param name="updateClaimCommand"></param>
        /// <returns>Updates an existing claim</returns>
        [ApiVersion("1.0")]
        [HttpPut("v{version:apiVersion}", Name = "UpdateClaim")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> UpdateClaim([FromBody] UpdateClaimCommand updateClaimCommand)
        {
            var result = await _mediator.Send(updateClaimCommand);
            if (result == true)
                return NoContent();
            {
                return BadRequest(result);
            }
        }

        /// <summary>
        /// Deletes a claim.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deletes a claim.</returns>
        [ApiVersion("1.0")]
        [HttpDelete("v{version:apiVersion}/{id}", Name = "DeleteClaim")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteClaimCommand = new DeleteClaimCommand() { ClaimId = id };
            await _mediator.Send(deleteClaimCommand);
            return NoContent();
        }
    }
}
