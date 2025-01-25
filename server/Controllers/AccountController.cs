namespace keeper.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  public AccountController(AccountService accountService, Auth0Provider auth0Provider, VaultsService vaultsService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _vaultsService = vaultsService;
  }
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly VaultsService _vaultsService;


  [HttpGet]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateAccount(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("vaults")]
  public async Task<ActionResult<List<Vault>>> GetMyVaults()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> vaults = _vaultsService.GetMyVaults(userInfo.Id);
      return vaults;
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [HttpPut]
  public async Task<ActionResult<Account>> EditAccount([FromBody] Account editData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Account updatedProfile = _accountService.Edit(editData, userInfo.Id);
      return Ok(updatedProfile);

    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }
}
