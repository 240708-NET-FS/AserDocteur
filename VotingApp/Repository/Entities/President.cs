namespace VotingApp.Entities;


public class President
 {
  public int PresidentId { get; set; }

  public required string Name { get; set; }
  public string Party { get; set; }

//  public int VoteCount { get; set; }

  public ICollection<User>? Users{ get; }

  public override string ToString()
    {
        Console.WriteLine($"\n{PresidentId} {Name} {Party} \n");
        foreach (User user in Users) 
        {
            Console.WriteLine($"{user.Name} supports {Name}");
        }
        return $"\n{Name}";
        //return $"\n{PresidentId} {Name} {Party} {VoteCount}\n";
    } 
}