







namespace keeper.Services;

public class VaultKeepsService
{
  public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository, VaultsService vaultsService)
  {
    _vaultKeepsRepository = vaultKeepsRepository;
    _vaultsService = vaultsService;
  }
  private readonly VaultKeepsRepository _vaultKeepsRepository;
  private readonly VaultsService _vaultsService;


  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    Vault vault = _vaultsService.GetVaultById(vaultKeepData.VaultId, vaultKeepData.CreatorId);

    if (vault.CreatorId != vaultKeepData.CreatorId) throw new Exception("HAHA CAUGHT YOOUUU!");

    VaultKeep vaultKeep = _vaultKeepsRepository.CreateVaultKeep(vaultKeepData);

    return vaultKeep;
  }

  private VaultKeep GetVaultKeepById(int vaultKeepId)
  {
    VaultKeep vaultKeep = _vaultKeepsRepository.GetVaultKeepById(vaultKeepId);

    if (vaultKeep == null) throw new Exception($"Invalid vault keep id: {vaultKeepId}");
    return vaultKeep;
  }



  internal string DeleteVaultKeep(int vaultKeepId, string userId)
  {
    VaultKeep vaultKeep = GetVaultKeepById(vaultKeepId);

    if (vaultKeep.CreatorId != userId) throw new Exception("STOP FRIEND CANT DO THAT");

    _vaultKeepsRepository.DeleteVaultKeep(vaultKeepId);
    return "Deleted vault keep? Still not sure what that is";
  }
}


