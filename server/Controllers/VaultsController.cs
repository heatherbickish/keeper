using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace keeper.Controllers;
[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  public VaultsController(VaultsService vaultsService, Auth0Provider autho0Provider, KeepsService keepsService)
  {
    _vaultsService = vaultsService;
    _autho0Provider = autho0Provider;
    _keepsService = keepsService;
  }
  private readonly VaultsService _vaultsService;
  private readonly Auth0Provider _autho0Provider;
  private readonly KeepsService _keepsService;


  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData)
  {
    try
    {
      Account userInfo = await _autho0Provider.GetUserInfoAsync<Account>(HttpContext);
      vaultData.CreatorId = userInfo.Id;
      Vault vault = _vaultsService.CreateVault(vaultData);
      return Ok(vault);
    }
    catch (Exception exception)
    {

      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{vaultId}")]
  public async Task<ActionResult<Vault>> GetVaultById(int vaultId)
  {
    try
    {
      Account userInfo = await _autho0Provider.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.GetVaultById(vaultId);
      return Ok(vault);
    }
    catch (Exception exception)
    {

      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpPut("{vaultId}")]
  public async Task<ActionResult<Vault>> UpdateVault(int vaultId, [FromBody] Vault vaultData)
  {
    try
    {
      Account userInfo = await _autho0Provider.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.UpdateVault(vaultId, userInfo.Id, vaultData);
      return Ok(vault);
    }
    catch (Exception exception)
    {

      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpDelete("{vaultId}")]
  public async Task<ActionResult<string>> DeleteVault(int vaultId)
  {
    try
    {
      Account userInfo = await _autho0Provider.GetUserInfoAsync<Account>(HttpContext);
      string message = _vaultsService.DeleteVault(vaultId, userInfo.Id);
      return Ok(message);
    }
    catch (Exception exception)
    {

      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{vaultId}/keeps")]
  public async Task<ActionResult<List<KeptKeep>>> GetKeepsByVaultId(int vaultId)
  {
    try
    {
      Account userInfo = await _autho0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<KeptKeep> keeps = _keepsService.GetKeepsByVaultId(vaultId, userInfo.Id);
      return Ok(keeps);
    }
    catch (Exception exception)
    {

      return BadRequest(exception.Message);
    }
  }


}
