namespace InsuranceSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]

    public class InsurersController : ControllerBase
    {
        private readonly IInsurerRepository _insurerRepository;
        private readonly IMediator _mediator;
        private readonly IEmailService _emailService;

        public InsurersController(IInsurerRepository insurerRepository, IMediator mediator, IEmailService emailService)
        {
            _insurerRepository = insurerRepository;
            _mediator = mediator;
            _emailService = emailService;
        }

        /// <summary>
        /// Returns insurers of a specific policy.
        /// </summary>
        /// <param name="PolicyNumber"></param>
        /// <param name="CustomerVatNumber"></param>
        /// <returns>Returns insurers of a specific policy.</returns>
        [ApiVersion("1.0")]
        [Authorize(Roles = "Admin, Agent")]
        [HttpGet("v{version:apiVersion}/{PolicyNumber}/{CustomerVatNumber}", Name = "GetInsurers")]
        [ProducesResponseType(typeof(List<InsurersListVm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<InsurersListVm>>> GetInsurers(string PolicyNumber, string CustomerVatNumber)
        {
            try
            {
                var getInsurers = new GetInsurersQuery() { policyNumber = PolicyNumber, customerVatNumber = CustomerVatNumber };
                var result = await _mediator.Send(getInsurers);

                if (result != null && result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        /// <summary>
        /// Creates a new insurer
        /// </summary>
        /// <param name="Insurer"></param>
        /// <returns>Creates a new insurer.</returns>
        [ApiVersion("1.0")]
        [Authorize(Roles = "Admin")]
        [HttpPost("v{version:apiVersion}/insurer", Name = "CreateInsurer")]
        [ProducesResponseType(typeof(CreateInsurerCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateInsurerCommandResponse>> CreateInsurer([FromBody] CreateInsurerCommand createInsurerCommand)
        {
            var result = await _mediator.Send(createInsurerCommand);

            if (result?.Success == true)
            {
                var email = new Email
                {
                    from = new From { email = "MS_H71f8Q@test-68zxl27rjz94j905.mlsender.net", name = "testname" },
                    to = new[] { new To { email = "123@example.com", name = "Name" } },
                    subject = "New insurer",
                    text = $"Insurer {createInsurerCommand.InsurerName}",
                    html = @"<!DOCTYPE html>
                            <html>
                              <head>
                                <meta charset='UTF-8'>
                                <title>Hello Name,</title>
                              </head>
                              <body>
                                <h1>A new insurer has been created</h1>
                                <p>Insurer: <strong>" + createInsurerCommand.InsurerName + @"</strong></p>
                              </body>
                            </html>"
                };

                var success = await _emailService.SendEmail(email);

                return Created($@"api/insurer/v1/{result.CreateInsurer.InsurerName}", result);
            }
            else
            {
                return BadRequest(result);
            }


        }

        /// <summary>
        /// Updates an existing insurer
        /// </summary>
        /// <param name="updateInsurerCommand"></param>
        /// <returns>Updates an existing insurer</returns>
        [ApiVersion("1.0")]
        [Authorize(Roles = "Admin")]
        [HttpPut("v{version:apiVersion}", Name = "UpdateInsurer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> UpdateInsurer([FromBody] UpdateInsurerCommand updateInsurerCommand)
        {
            var result = await _mediator.Send(updateInsurerCommand);
            if (result == true)
                return NoContent();
            {
                return BadRequest(result);
            }
        }

        /// <summary>
        /// Deletes an insurer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deletes an insurer</returns>
        [ApiVersion("1.0")]
        [Authorize(Roles = "Admin")]
        [HttpDelete("v{version:apiVersion}/{id}", Name = "DeleteInsurer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteInsurerCommand = new DeleteInsurerCommand { InsurerId = id };
            await _mediator.Send(deleteInsurerCommand);
            return NoContent();
        }
    }
}
