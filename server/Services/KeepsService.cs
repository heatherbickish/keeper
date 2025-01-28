namespace keeper.Services;
public class KeepsService
{
  public KeepsService(KeepsRepository keepsRepository, VaultsService vaultsService, ProfilesService profilesService)
  {
    _keepsRepository = keepsRepository;
    _vaultsService = vaultsService;
    _profilesService = profilesService;
  }
  private readonly KeepsRepository _keepsRepository;
  private readonly VaultsService _vaultsService;
  private readonly ProfilesService _profilesService;


  internal Keep CreateKeep(Keep keepData)
  {
    Keep keep = _keepsRepository.CreateKeep(keepData);
    return keep;
  }

  internal List<Keep> GetAllKeeps()
  {
    List<Keep> keeps = _keepsRepository.GetAllKeeps();
    return keeps;
  }

  private Keep GetKeepById(int keepId)
  {
    Keep keep = _keepsRepository.GetKeepById(keepId);


    if (keep == null) throw new Exception($"Invalid keep id: {keepId}");
    return keep;
  }

  internal Keep IncrementViews(int keepId, string userId)
  {
    Keep keep = GetKeepById(keepId);

    if (keep.CreatorId != userId)
    {
      keep.Views++;
    }
    _keepsRepository.IncrementViews(keep);
    return keep;
  }

  internal Keep UpdateKeep(int keepId, string userId, Keep keepData)
  {
    Keep keep = GetKeepById(keepId);

    if (keep.CreatorId != userId) throw new Exception("YOU CANNOT EDIT ANOTHER USERS KEEP, BUDDDY");

    keep.Name = keepData.Name ?? keep.Name;
    keep.Description = keepData.Description ?? keep.Description;
    keep.Img = keepData.Img ?? keep.Img;

    _keepsRepository.UpdateKeep(keep);
    return keep;
  }

  internal string DeleteKeep(int keepId, string userId)
  {
    Keep keep = GetKeepById(keepId);

    if (keep.CreatorId != userId) throw new Exception("YOU CANNOT DELETE ANOTHER USERS KEEP, HOMIE");

    _keepsRepository.DeleteKeep(keepId);
    return $"Deleted {keep.Name}";
  }

  internal List<KeptKeep> GetKeepsByVaultId(int vaultId, string userId)
  {
    _vaultsService.GetVaultById(vaultId, userId);

    List<KeptKeep> keeps = _keepsRepository.GetKeepsByVaultId(vaultId);
    return keeps;
  }

  internal List<Keep> GetKeepsByProfileId(string profileId)
  {
    _profilesService.GetProfileById(profileId);

    List<Keep> keeps = _keepsRepository.GetKeepsByProfileId(profileId);
    return keeps;
  }
}