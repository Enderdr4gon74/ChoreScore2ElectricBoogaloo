namespace ChoreScore2ElectricBoogaloo.Models;

public class Chore 
{
  public int Id { get; set; }
  public string Name { get; set; }
  public bool IsComplete { get; set; }
  public Chore(string name, int id, bool isComplete) 
  {
    Id = id;
    Name = name;
    IsComplete = isComplete;
  }

  public Chore()
  {
    
  }
}