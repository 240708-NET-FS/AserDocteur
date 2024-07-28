namespace VotingApp.Entities;
using VotingApp.Constants;
public class User
 {
  public int UserId { get; set; }

  public required string Name { get; set; }
//  public int Age { get; set; }
//  public string? Email { get; set; }
//  public string Party { get; set; }

  public int PresidentId { get; set; }
  public President? President { get; set; }

 }