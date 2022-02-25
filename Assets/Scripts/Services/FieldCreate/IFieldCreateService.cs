using Gameplay.Table;

namespace Services.FieldCreate
{
  public interface IFieldCreateService : IService
  {
    void CreateField(Field field);
  }
}