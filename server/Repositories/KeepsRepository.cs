



namespace keeper.Repositories;
public class KeepsRepository
{
  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;


  internal Keep CreateKeep(Keep keepData)
  {
    string sql = @"
      INSERT INTO
      keeps(name, description, img, creator_id)
      VALUES(@Name, @Description, @Img, @CreatorId);

      SELECT
      keeps.*,
      accounts.*
      FROM keeps_with_kept_view keeps
      JOIN accounts ON accounts.id = keeps.creator_id
      WHERE keeps.id = LAST_INSERT_ID();";

    Keep keep = _db.Query(sql, (Keep keep, Profile account) =>
    {
      keep.Creator = account;
      return keep;
    }, keepData).SingleOrDefault();
    return keep;
  }

  internal List<Keep> GetAllKeeps()
  {
    string sql = @"
      SELECT
      keeps.*,
      accounts.*
      FROM keeps
      JOIN accounts ON accounts.id = keeps.creator_id
      ORDER BY keeps.created_at DESC;";

    List<Keep> keeps = _db.Query(sql, (Keep keep, Profile account) =>
    {
      keep.Creator = account;
      return keep;
    }).ToList();
    return keeps;
  }

  internal Keep GetKeepById(int keepId)
  {
    string sql = @"
      SELECT
      keeps.*,
      accounts.*
      FROM keeps_with_kept_view keeps
      JOIN accounts ON accounts.id = keeps.creator_id
      WHERE keeps.id = @keepId;";

    Keep keep = _db.Query(sql, (Keep keep, Profile account) =>
    {
      keep.Creator = account;
      return keep;
    }, new { keepId }).SingleOrDefault();
    return keep;
  }

  internal void UpdateKeep(Keep keepData)
  {
    string sql = @"
      UPDATE keeps
      SET
      name = @Name,
      description = @Description,
      img = @Img
      WHERE id = @Id LIMIT 1;";

    int rowsAffected = _db.Execute(sql, keepData);

    if (rowsAffected != 1) throw new Exception($"{rowsAffected} WERE UPDATED AND THAT WAS TERRIBLE");
  }

  internal void DeleteKeep(int keepId)
  {
    string sql = "DELETE FROM keeps WHERE id = @keepId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { keepId });

    if (rowsAffected != 1) throw new Exception($"{rowsAffected} WERE DELETED AND THAT WAS NOT GOOD");
  }

  internal List<KeptKeep> GetKeepsByVaultId(int vaultId)
  {
    string sql = @"
      SELECT
      vault_keeps.*,
      keeps.*,
      accounts.*
      FROM vault_keeps
      JOIN keeps ON vault_keeps.keep_id = keeps.id
      JOIN accounts ON accounts.id = keeps.creator_id
      WHERE vault_keeps.vault_id = @vaultId;";

    List<KeptKeep> keeps = _db.Query(sql, (VaultKeep vaultKeep, KeptKeep keep, Profile account) =>
    {
      keep.VaultKeepId = vaultKeep.Id;
      keep.Creator = account;
      return keep;
    }, new { vaultId }).ToList();
    return keeps;
  }

  internal List<Keep> GetKeepsByProfileId(string profileId)
  {
    string sql = @"
      SELECT
      keeps.*,
      accounts.*
      FROM keeps
      JOIN accounts ON accounts.id = keeps.creator_id
      WHERE keeps.creator_id = @profileId;";

    List<Keep> keeps = _db.Query(sql, (Keep keep, Profile account) =>
    {
      keep.Creator = account;
      return keep;
    }, new { profileId }).ToList();
    return keeps;
  }

  internal void IncrementViews(Keep keep)
  {
    string sql = @"
      UPDATE keeps
      SET views = @Views
      WHERE id = @Id
      LIMIT 1;";

    int rowsAffected = _db.Execute(sql, keep);
    if (rowsAffected != 1) throw new Exception($"{rowsAffected} WERE UPDATED AND THAT WAS NAUGHTY");
  }
}