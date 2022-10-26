namespace ChoreScore2ElectricBoogaloo.Services;

public class ChoresService {
  private readonly ChoresRepository _choresRepo;

  public ChoresService(ChoresRepository choresRepo)
  {
    _choresRepo = choresRepo;
  }

  public List<Chore> GetChores() {
    return _choresRepo.GetChores();
  }

  public Chore GetChore(String id) {
    return _choresRepo.GetChore(id);
  }

  public Chore CreateChore(Chore choreData) {
    return _choresRepo.CreateChore(choreData);
  }

  public Chore EditChore(Chore choreData, String id) {
    return _choresRepo.EditChore(choreData, id);
  }

  public Chore CompleteChore(String id) {
    return _choresRepo.CompleteChore(id);
  }

  public Chore DeleteChore(String id)
  {
    return _choresRepo.DeleteChore(id);
  }
}
