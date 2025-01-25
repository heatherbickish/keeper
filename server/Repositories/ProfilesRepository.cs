
namespace keeper.Repositories;

public class ProfilesRepository
{
  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;


  internal Profile GetProfileById(string profileId)
  {
    string sql = "SELECT * FROM accounts WHERE id = @profileId;";
    Profile profile = _db.Query<Profile>(sql, new { profileId }).SingleOrDefault();
    return profile;
  }
}
