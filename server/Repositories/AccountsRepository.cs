namespace keeper.Repositories;

public class AccountsRepository
{
  private readonly IDbConnection _db;

  public AccountsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Account GetByEmail(string userEmail)
  {
    string sql = "SELECT * FROM accounts WHERE email = @userEmail";
    return _db.QueryFirstOrDefault<Account>(sql, new { userEmail });
  }

  internal Profile GetById(string id)
  {
    string sql = "SELECT * FROM accounts WHERE id = @id";
    return _db.QueryFirstOrDefault<Profile>(sql, new { id });
  }

  internal Account Create(Account newAccount)
  {
    string sql = @"
            INSERT INTO accounts
              (name, picture, email, id)
            VALUES
              (@Name, @Picture, @Email, @Id)";
    _db.Execute(sql, newAccount);
    return newAccount;
  }

  internal Profile Edit(Profile update)
  {
    string sql = @"
            UPDATE accounts
            SET 
              name = @Name,
              picture = @Picture,
              cover_img = @CoverImg
            WHERE id = @Id;";
    _db.Execute(sql, update);
    return update;
  }
}

