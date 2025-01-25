namespace keeper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
  public ProfilesController(ProfilesService profilesService, Auth0Provider autho0Provider)
  {
    _profilesService = profilesService;
    _autho0Provider = autho0Provider;
  }
  private readonly ProfilesService _profilesService;
  private readonly Auth0Provider _autho0Provider;

  // [Authorize]
  [HttpGet("{profileId}")]
  public async Task<ActionResult<Profile>> GetProfileById(string profileId)
  {
    try
    {
      Account userInfo = await _autho0Provider.GetUserInfoAsync<Account>(HttpContext);
      Profile profile = _profilesService.GetProfileById(profileId);
      return Ok(profile);
    }
    catch (Exception exception)
    {

      return BadRequest(exception.Message);
    }
  }

}
