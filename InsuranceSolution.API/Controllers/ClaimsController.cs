namespace InsuranceSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]

    public class ClaimsController : ControllerBase
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IMediator _mediator;
        private readonly IEmailService _emailService;

        public ClaimsController(IClaimRepository claimRepository, IMediator mediator, IEmailService emailService)
        {
            _mediator = mediator;
            _claimRepository = claimRepository;
            _emailService = emailService;
        }

        /// <summary>
        /// Returns claims of a specific policy.
        /// </summary>
        /// <param name="PolicyNumber"></param>
        /// <returns>Returns claims of a specific policy.</returns>
        [ApiVersion("1.0")]
        [Authorize(Roles = "Admin, Agent")]
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
        /// <param name="Claim"></param>
        /// <returns>Creates a new claim.</returns>
        [ApiVersion("1.0")]
        [Authorize(Roles = "Admin")]
        [HttpPost("v{version:apiVersion}/claim", Name = "CreateClaim")]
        [ProducesResponseType(typeof(CreateClaimCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateClaimCommandResponse>> CreateClaim([FromBody] CreateClaimCommand createClaimCommand)
        {
            var result = await _mediator.Send(createClaimCommand);

            if (result?.Success == true)
            {
                var email = new Email
                {
                    from = new From { email = "MS_H71f8Q@test-68zxl27rjz94j905.mlsender.net", name = "testname" },
                    to = new[] { new To { email = "123@example.com", name = "Name" } },
                    subject = "New claim",
                    text = $"Claim with policy id {createClaimCommand.PolicyId}",
                    html = @"<!DOCTYPE html>
                            <html>
                              <head>
                                <meta charset='UTF-8'>
                                <title>Hello Name,</title>
                              </head>
                              <body>
                                <h1>A new claim has been created!</h1>
                                <p>Claim with policy id: <strong>" + createClaimCommand.PolicyId + @"</strong></p>
                              </body>
                            </html>"
                };

                var success = await _emailService.SendEmail(email);

                return Created($@"api/claim/v1/{result.Claim.ClaimId}", result);
            }
            else
            {
                return BadRequest(result);
            }


        }

        /// <summary>
        /// Updates an existing claim
        /// </summary>
        /// <param name="updateClaimCommand"></param>
        /// <returns>Updates an existing claim</returns>
        [ApiVersion("1.0")]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
