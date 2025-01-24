using System.ComponentModel.DataAnnotations;

namespace keeper.Models;

public class Vault : RepoItem<int>
{
  [MaxLength(255)] public string Name { get; set; }
  [MaxLength(1000)] public string Description { get; set; }
  [Url, MaxLength(1000)] public string Img { get; set; }
  public bool? IsPrivate { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
}