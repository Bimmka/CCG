using Gameplay.Cards.CardsElement.Base;
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

    public void CreateField(Field field)
    {
      TableView table = SpawnTable();
      field.SetSize(data.FieldSize);
      field.SetFieldParent(table.transform);
      field.SetPlayerDeckParent(table.PlayerDeckParent);
      SpawnCells(table, field);
    }

    private void SpawnCells(TableView table, Field field)
    {
      Vector3 startSpawnLocalPoint = table.SpawnLocalPosition;
      FieldCell cell;
      for (int i = 0; i < data.FieldSize.x; i++)
      {
        for (int j = 0; j < data.FieldSize.y; j++)
        {
          Vector2Int gridPosition = new Vector2Int(i, j);
          cell = SpawnCell(table.transform);
          cell.SetGridPosition(gridPosition);
          cell.SetCellType(CellType(gridPosition));
          cell.transform.localPosition = startSpawnLocalPoint + new Vector3(i * data.ElementsOffset.x, 0, -j * data.ElementsOffset.y);
          field.AddCell(cell, gridPosition);
        }
      } 
    }

    private PlayingZoneType CellType(Vector2Int position)
    {
      if (position.y < data.FieldSize.y - 1)
        return PlayingZoneType.Opponent;
      return PlayingZoneType.Player;
    }
    private TableView SpawnTable() => 
      assets.Instantiate(data.TablePrefab, data.TableSpawnPosition);

    private FieldCell SpawnCell(Transform table) => 
      assets.Instantiate(data.MapCellPrefab, table);
  }
}