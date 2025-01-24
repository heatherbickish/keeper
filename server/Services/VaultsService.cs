




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

  internal Vault UpdateVault(int vaultId, string userId, Vault vaultData)
  {
    Vault vault = GetVaultById(vaultId);

    if (vault.CreatorId != userId) throw new Exception("YOU CANNOT ALTER ANOTHER USERS VAULT, MY LOVE");

    vault.Name = vaultData.Name ?? vault.Name;
    vault.Description = vaultData.Description ?? vault.Description;
    vault.Img = vaultData.Img ?? vault.Img;
    vault.IsPrivate = vaultData.IsPrivate ?? vault.IsPrivate;

    _vaultsRepository.UpdateVault(vault);
    return vault;
  }
}
