





namespace keeper.Services;
public class VaultsService
{
  public VaultsService(VaultsRepository vaultsRepository, ProfilesService profilesService)
  {
    _vaultsRepository = vaultsRepository;
    _profilesService = profilesService;
  }
  private readonly VaultsRepository _vaultsRepository;
  private readonly ProfilesService _profilesService;


  internal Vault CreateVault(Vault vaultData)
  {
    Vault vault = _vaultsRepository.CreateVault(vaultData);
    return vault;
  }

  private Vault GetVaultById(int vaultId)
  {
    Vault vault = _vaultsRepository.GetVaultById(vaultId);

    if (vault == null) throw new Exception($"Invalid vault id: {vaultId}");

    return vault;
  }

  internal Vault GetVaultById(int vaultId, string userId)
  {
    Vault vault = GetVaultById(vaultId);

    if (vault.CreatorId != userId && vault.IsPrivate == true) throw new Exception($"Invalid vault id: {vaultId} 😜");

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

  internal string DeleteVault(int vaultId, string userId)
  {
    Vault vault = GetVaultById(vaultId);

    if (vault.CreatorId != userId) throw new Exception("YOU CANNOT DELETE ANOTHER USERS VAULT, DUDE");

    _vaultsRepository.DeleteVault(vaultId);
    return $"Deleted {vault.Name}";
  }

  internal List<Vault> GetVaultsByProfileId(string profileId)
  {
    _profilesService.GetProfileById(profileId);
    List<Vault> vaults = GetMyVaults(profileId);

    return vaults.FindAll(vault => vault.CreatorId == profileId && vault.IsPrivate == false);
  }

  internal List<Vault> GetMyVaults(string userId)
  {
    List<Vault> vaults = _vaultsRepository.GetMyVaults(userId);
    return vaults;
  }


}
