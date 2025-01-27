namespace keeper.Services;

public class AccountService
{
  private readonly AccountsRepository _repo;

  public AccountService(AccountsRepository repo)
  {
    _repo = repo;
  }

  private Profile GetAccount(string accountId)
  {
    Profile account = _repo.GetById(accountId);
    if (account == null)
    {
      throw new Exception("Invalid Account Id");
    }
    return account;
  }

  internal Profile GetOrCreateAccount(Account userInfo)
  {
    Profile account = _repo.GetById(userInfo.Id);
    if (account == null)
    {
      return _repo.Create(userInfo);
    }
    return account;
  }

  internal Profile Edit(Profile editData, string accountId)
  {
    Profile profile = GetAccount(accountId);
    profile.Name = editData.Name ?? editData.Name;
    profile.Picture = editData.Picture ?? editData.Picture;
    profile.CoverImg = editData.CoverImg ?? editData.CoverImg;
    return _repo.Edit(profile);
  }
}
