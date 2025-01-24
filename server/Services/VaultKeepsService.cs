





namespace keeper.Services;

public class VaultKeepsService
{
  public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository)
  {
    _vaultKeepsRepository = vaultKeepsRepository;
  }
  private readonly VaultKeepsRepository _vaultKeepsRepository;


  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    VaultKeep vaultKeep = _vaultKeepsRepository.CreateVaultKeep(vaultKeepData);
    return vaultKeep;
  }
}
