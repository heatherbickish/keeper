
namespace keeper.Services;

public class ProfilesService
{
  public ProfilesService(ProfilesRepository profilesRepository)
  {
    _profilesRepository = profilesRepository;
  }
  private readonly ProfilesRepository _profilesRepository;


  internal Profile GetProfileById(string profileId)
  {
    Profile profile = _profilesRepository.GetProfileById(profileId);

    if (profile == null) throw new Exception($"Invalid profile id: {profileId}");
    return profile;
  }
}
