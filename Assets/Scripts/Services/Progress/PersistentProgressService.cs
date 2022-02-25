using Services.PlayerData;

namespace Services.Progress
{
  public class PersistentProgressService : IPersistentProgressService
  {

    public Player Player { get; private set; }
    public PersistentProgressService()
    {
      Player = new Player();
     
    }

    public void SetPlayerToDefault()
    {
     
    }
  }
}