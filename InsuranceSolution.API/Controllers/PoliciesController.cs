namespace InsuranceSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]

    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyRepository _policyRepository;
        private readonly IMediator _mediator;
        private readonly IEmailService _emailService;

        public PoliciesController(IPolicyRepository policyRepository, IMediator mediator, IEmailService emailService)
        {
            _policyRepository = policyRepository;
            _mediator = mediator;
            _emailService = emailService;
        }

        /// <summary>
        /// Returns policies of a specific customer.
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns>Returns policies of a specific customer.</returns>
        [ApiVersion("1.0")]
        [Authorize(Roles = "Admin, Agent")]
        [HttpGet("v{version:apiVersion}/{CustomerId}", Name = "GetPolicies")]
        [ProducesResponseType(typeof(List<PoliciesListVm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<PoliciesListVm>>> GetPolicies(Guid CustomerId)
        {
            var getPolicies = new GetPoliciesQuery() { customerId = CustomerId };
            var result = await _mediator.Send(getPolicies);
            if (result?.Count > 0)
                return Ok(result);
            else
                return NotFound();
        }

        /// <summary>
        /// Creates a new policy
        /// </summary>
        /// <param name="Policy"></param>
        /// <returns>Creates a new policy.</returns>
        [ApiVersion("1.0")]
        [Authorize(Roles = "Admin")]
        [HttpPost("v{version:apiVersion}/policy", Name = "CreatePolicy")]
        [ProducesResponseType(typeof(CreatePolicyCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreatePolicyCommandResponse>> CreatePolicy([FromBody] CreatePolicyCommand createPolicyCommand)
        {
            var result = await _mediator.Send(createPolicyCommand);

            if (result?.Success == true)
            {
                var email = new Email
                {
                    from = new From { email = "MS_H71f8Q@test-68zxl27rjz94j905.mlsender.net", name = "testname" },
                    to = new[] { new To { email = "123@example.com", name = "Name" } },
                    subject = "New policy",
                    text = $"Policy with id {createPolicyCommand.PolicyNumber}",
                    html = @"<!DOCTYPE html>
                            <html>
                              <head>
                                <meta charset='UTF-8'>
                                <title>Hello Name,</title>
                              </head>
                              <body>
                                <h1>A new policy has been created</h1>
                                <p>Policy ID: <strong>" + createPolicyCommand.PolicyNumber + @"</strong></p>
                              </body>
                            </html>"
                };

                var success = await _emailService.SendEmail(email);

                return Created($@"api/policy/v1/{result.Policy.PolicyId}", result);
            }

            else
            {
                return BadRequest(result);
            }
        }

        /// <summary>
        /// Updates an existing policy
        /// </summary>
        /// <param name="updatePolicyCommand"></param>
        /// <returns>Updates an existing policy</returns>
        [ApiVersion("1.0")]
        [Authorize(Roles = "Admin")]
        [HttpPut("v{version:apiVersion}", Name = "UpdatePolicy")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> UpdateClaim([FromBody] UpdatePolicyCommand updatePolicyCommand)
        {
            var result = await _mediator.Send(updatePolicyCommand);
            if (result == true)
                return NoContent();
            {
                return BadRequest(result);
            }
        }

        /// <summary>
        /// Deletes a policy
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deletes a policy</returns>
        [ApiVersion("1.0")]
        [Authorize(Roles = "Admin")]
        [HttpDelete("v{version:apiVersion}/{id}", Name = "DeletePolicy")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletePolicyCommand = new DeletePolicyCommand() { PolicyId = id };
            await _mediator.Send(deletePolicyCommand);
            return NoContent();
        }
    }
}
