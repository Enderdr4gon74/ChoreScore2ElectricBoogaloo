namespace ChoreScore2ElectricBoogaloo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChoresController : ControllerBase
{
  private readonly ChoresService _choresService;

  public ChoresController(ChoresService choresService)
  {
    _choresService = choresService;
  }

  [HttpGet]
  public ActionResult<List<Chore>> Get()
  {
    try
    {
      List<Chore> chores = _choresService.GetChores();
      return Ok(chores);
    }
    catch (System.Exception ex)
    {
       return BadRequest(ex.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<Chore> GetChore(String id)
  {
    try
    {
      Chore chore = _choresService.GetChore(id);
      return Ok(chore);
    }
    catch (System.Exception ex)
    {
       return BadRequest(ex.Message);
    }
  }

  [HttpPost]
  public ActionResult<Chore> CreateChore([FromBody] Chore choreData)
  {
    try
    {
      Chore chore = _choresService.CreateChore(choreData);
      return Ok(chore);
    }
    catch (System.Exception ex)
    {
       return BadRequest(ex.Message);
    }
  }

  [HttpPut("{id}")]
  public ActionResult<Chore> EditChore([FromBody] Chore choreData, String id)
  {
    try
    {
      Chore chore = _choresService.EditChore(choreData, id);
      return Ok(chore);
    }
    catch (System.Exception ex)
    {
       return BadRequest(ex.Message);
    }
  }

  [HttpPut("{id}/complete")]
  public ActionResult<Chore> CompleteChore(String id)
  {
    try
    {
      Chore chore = _choresService.CompleteChore(id);
      return Ok(chore);
    }
    catch (System.Exception ex)
    {
       return BadRequest(ex.Message);
    }
  }

  [HttpDelete("{id}")]
  public ActionResult<Chore> DeleteChore(String Id)
  {
    try
    {
      Chore chore = _choresService.DeleteChore(Id);
      return chore;
    }
    catch (System.Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}