using System.ComponentModel.DataAnnotations;

namespace keeper.Models;

public class Keep : RepoItem<int>
{
  public string Name { get; set; }
  [MaxLength(2000)] public string Description { get; set; }
  [Url, MaxLength(2000)] public string Img { get; set; }
  [Range(1, 100000)] public int Views { get; set; }
  public string CreatorId { get; set; }
}