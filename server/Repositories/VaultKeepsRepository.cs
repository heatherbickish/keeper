namespace keeper.Repositories;
public class VaultKeepsRepository
{
  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;


  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    string sql = @"
      INSERT INTO
      vault_keeps(keep_id, vault_id, creator_id)
      VALUES(@KeepId, @VaultId, @CreatorId);

      SELECT * FROM vault_keeps WHERE vault_keeps.id = LAST_INSERT_ID();";

    VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, vaultKeepData).SingleOrDefault();
    return vaultKeep;
  }

  internal VaultKeep GetVaultKeepById(int vaultKeepId)
  {
    string sql = " SELECT * FROM vault_keeps WHERE id = @vaultKeepId;";
    VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, new { vaultKeepId }).SingleOrDefault();
    return vaultKeep;
  }

  internal void DeleteVaultKeep(int vaultKeepId)
  {
    string sql = "DELETE FROM vault_keeps WHERE id = @vaultKeepId;";

    int rowsAffected = _db.Execute(sql, new { vaultKeepId });

    if (rowsAffected != 1) throw new Exception($"{rowsAffected} ROWS WERE DELETED AND WHAT A MESS");
  }
}
