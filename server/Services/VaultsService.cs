



namespace keeper.Services;

public class VaultsService
{
  public VaultsService(VaultsRepository vaultsRepository)
  {
    _vaultsRepository = vaultsRepository;
  }
  private readonly VaultsRepository _vaultsRepository;


  internal Vault CreateVault(Vault vaultData)
  {
    Vault vault = _vaultsRepository.CreateVault(vaultData);
    return vault;
  }
}
