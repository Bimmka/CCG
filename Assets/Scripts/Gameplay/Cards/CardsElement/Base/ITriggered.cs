namespace Gameplay.Cards.CardsElement.Base
{
  public interface ITriggered
  {
    bool IsCanBeTriggered(CardUseStrategy strategy);
    void Trigger();
  }
}