



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
      FROM keeps
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
      JOIN accounts ON accounts.id = keeps.creator_id;";

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
      FROM keeps
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
}