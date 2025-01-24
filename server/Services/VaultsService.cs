




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

  internal Vault GetVaultById(int vaultId)
  {
    Vault vault = _vaultsRepository.GetVaultById(vaultId);

    if (vault == null) throw new Exception($"Invalid vault id: {vaultId}");

    return vault;
  }
}
