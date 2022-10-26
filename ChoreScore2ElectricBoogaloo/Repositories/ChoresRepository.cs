namespace ChoreScore2ElectricBoogaloo.Repositories;

public class ChoresRepository
{
  private readonly IDbConnection _db;

  public ChoresRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Chore> GetChores()
  {
    var sql = "SELECT * FROM chores;";
    return _db.Query<Chore>(sql).ToList();
  }

  public Chore GetChore(String id)
  {
    var sql = "SELECT * FROM chores WHERE id = @id;";
    return _db.QuerySingleOrDefault<Chore>(sql, new {id});
  }

  public Chore CreateChore(Chore choreData)
  {
    var sql = @"
      INSERT INTO chores(name, isComplete)
      VALUES (@Name, false);
      SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, choreData);
    choreData.Id = id;
    choreData.IsComplete = false;
    return choreData;
  }

  public Chore EditChore(Chore choreData, String id)
  {
    string sql = "";
    if (choreData.Name != null) {
      sql += "UPDATE chores SET name = @Name WHERE id = @id;";
    }
    _db.QuerySingleOrDefault<Chore>(sql, new { id, Name = choreData.Name});
    return this.GetChore(id);
  }

  public Chore CompleteChore(String id)
  {
    string sql = @"
      UPDATE chores SET isComplete = true WHERE id = @id
    ";
    _db.QuerySingleOrDefault<Chore>(sql, new { id });
    return this.GetChore(id);
  }

  public Chore DeleteChore(String id)
  {
    string sql = @"
    DELETE FROM chores WHERE id = @id;    
    ";
    Chore chore = this.GetChore(id);
    _db.QuerySingleOrDefault<Chore>(sql, new { id });
    return chore;
  }
}
