namespace ConfigAgent.API.Controllers;

/// <summary>
/// Controller for Credentials Configuration operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ConfigController : ControllerBase
{
    #region PrivateFields
    
    private readonly ICredentialsService _credentialsService;
    private readonly ILogger<ConfigController> _logger;
    
    #endregion
    
    #region ctor

    public ConfigController(ICredentialsService credentialsService, ILogger<ConfigController> logger)
    {
        _credentialsService = credentialsService ?? throw new ArgumentNullException(nameof(credentialsService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    #endregion
    
    #region ControllerMethods
    
    /// <summary>
    /// Gets Credentials.
    /// </summary>
    /// <returns>
    /// Returns Credentials data.
    /// </returns>
    [HttpGet]
    [ProducesResponseType(typeof(CredentialsModel), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CredentialsModel>> Get()
    {
        _logger.Log(LogLevel.Information, "Executing Credentials Get");

        CredentialsModel credentials = await _credentialsService.Get();

        return Ok(credentials);
    }
    
    /// <summary>
    /// Inserts Credentials.
    /// </summary>
    /// <param name="credentialsModel">
    /// Credentials Model.
    /// </param>
    /// <returns>
    /// Returns 201 status code.
    /// </returns>
    [HttpPost]
    [ProducesResponseType(typeof(CredentialsModel), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> Post([FromBody] CredentialsModel credentialsModel)
    {
        _logger.Log(LogLevel.Information, "Executing Credentials Post");

        CredentialsModel existedCredentials = await _credentialsService.Get();

        if (existedCredentials is not null)
        {
            throw new AgentException("Your credentials are already in the database, use them.", 403);
        }

        await _credentialsService.InsertOne(credentialsModel);

        return CreatedAtAction(nameof(Post), credentialsModel);
    }
    
    /// <summary>
    /// Updates an existing Credentials record.
    /// </summary>
    /// <param name="credentialsModel">
    /// Credentials to update.
    /// </param>
    /// <returns>
    /// Returns No content.
    /// </returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put([FromBody] CredentialsModel credentialsModel)
    {
        _logger.Log(LogLevel.Information, "Executing Credentials Put");
        
        await _credentialsService.Update(credentialsModel);
        
        return NoContent();
    }
    
    /// <summary>
    /// Deletes Credentials.
    /// </summary>
    /// <param name="id">
    /// Buyer's ID to delete basket.
    /// </param>
    /// <returns>
    /// Returns No content.
    /// </returns>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        _logger.Log(LogLevel.Information, "Executing Credentials Delete");
        
        await _credentialsService.Delete(id);
        
        return NoContent();
    }
    
    #endregion
}