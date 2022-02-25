using Gameplay.Table;
using Services.Assets;
using StaticData.Gameplay.Table;
using UnityEngine;

namespace Services.FieldCreate
{
  public class FieldCreateService : IFieldCreateService
  {
    private readonly FieldCreateStaticData data;
      
    private readonly IAssetProvider assets;

    public FieldCreateService(IAssetProvider assetProvider, FieldCreateStaticData staticData)
    {
      assets = assetProvider;
      data = staticData;
    }

    public void CreateField()
    {
      Field table = SpawnTable();
      SpawnCells(table);
    }

    private void SpawnCells(Field table)
    {
      Vector3 startSpawnLocalPoint = table.SpawnLocalPosition;
      for (int i = 0; i < data.FieldSize.x; i++)
      {
        for (int j = 0; j < data.FieldSize.y; j++)
        {
          GameObject cell = SpawnCell(table.transform);
          cell.transform.localPosition = startSpawnLocalPoint + new Vector3(i * data.ElementsOffset.x, 0, -j * data.ElementsOffset.y);
        }
      } 
    }
    private Field SpawnTable() => 
      assets.Instantiate(data.TablePrefab, data.TableSpawnPosition);

    private GameObject SpawnCell(Transform table) => 
      assets.Instantiate(data.MapCellPrefab, table);
  }
}