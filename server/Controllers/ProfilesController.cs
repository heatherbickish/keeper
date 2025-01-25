namespace keeper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
  public ProfilesController(ProfilesService profilesService, Auth0Provider autho0Provider, KeepsService keepsService, VaultsService vaultsService)
  {
    _profilesService = profilesService;
    _autho0Provider = autho0Provider;
    _keepsService = keepsService;
    _vaultsService = vaultsService;
  }
  private readonly ProfilesService _profilesService;
  private readonly Auth0Provider _autho0Provider;
  private readonly KeepsService _keepsService;
  private readonly VaultsService _vaultsService;


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

  [HttpGet("{profileId}/keeps")]
  public async Task<ActionResult<List<Keep>>> GetKeepsByProfileId(string profileId)
  {
    try
    {
      Account userInfo = await _autho0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Keep> keeps = _keepsService.GetKeepsByProfileId(profileId);
      return Ok(keeps);

    }
    catch (Exception exception)
    {

      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{profileId}/vaults")]
  public async Task<ActionResult<List<Vault>>> GetVaultsByProfileId(string profileId)
  {
    try
    {
      Account userInfo = await _autho0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> vaults = _vaultsService.GetVaultsByProfileId(profileId);
      return vaults;

    }
    catch (Exception exception)
    {

      return BadRequest(exception.Message);
    }
  }

}
