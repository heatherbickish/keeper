using System.ComponentModel.DataAnnotations;

namespace keeper.Models;

public class Profile : RepoItem<string>
{
  public string Name { get; set; }
  [Url, MaxLength(255)] public string Picture { get; set; }
  [Url, MaxLength(1000)] public string CoverImg { get; set; }

}