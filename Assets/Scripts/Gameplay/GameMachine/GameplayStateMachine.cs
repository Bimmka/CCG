using Gameplay.Table;
using Services.FieldCreate;
using UnityEngine;
using Zenject;

namespace Gameplay.GameMachine
{
  public class GameplayStateMachine : MonoBehaviour
  {
    [SerializeField] private Field field;
    
    private IFieldCreateService fieldCreateService;

    [Inject]
    private void Construct(IFieldCreateService fieldCreateService)
    {
      this.fieldCreateService = fieldCreateService;
    }
  }
}