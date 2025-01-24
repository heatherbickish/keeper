namespace keeper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase
{
  public VaultKeepsController(VaultKeepsService vaultKeepsService, Auth0Provider autho0Provider)
  {
    _vaultKeepsService = vaultKeepsService;
    _autho0Provider = autho0Provider;
  }
  private readonly VaultKeepsService _vaultKeepsService;
  private readonly Auth0Provider _autho0Provider;


  [Authorize]
  [HttpPost]
  public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vaultKeepData)
  {
    try
    {
      Account userInfo = await _autho0Provider.GetUserInfoAsync<Account>(HttpContext);
      vaultKeepData.CreatorId = userInfo.Id;
      VaultKeep vaultKeep = _vaultKeepsService.CreateVaultKeep(vaultKeepData);
      return Ok(vaultKeep);
    }
    catch (Exception exception)
    {

      return BadRequest(exception.Message);
    }
  }
}
