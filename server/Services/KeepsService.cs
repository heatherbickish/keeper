namespace keeper.Services;

public class KeepsService
{
  public KeepsService(KeepsRepository keepsRepository)
  {
    _keepsRepository = keepsRepository;
  }
  private readonly KeepsRepository _keepsRepository;

}