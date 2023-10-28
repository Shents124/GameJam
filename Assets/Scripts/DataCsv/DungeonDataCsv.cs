using System.Collections.Generic;
using Sirenix.OdinInspector;

public class DungeonDataCsv : SerializedScriptableObject
{
    public Dictionary<int, FloorConfigData> floorMap = new();
    public Dictionary<int, EnemyConfigData> enemyMap = new();

    private FloorConfigData[] _floorCsvs;
    private EnemyConfigData[] _enemyCsvs;

    public void CovertEnemyData()
    {
        enemyMap = new();
        foreach (var item in _enemyCsvs)
        {
            enemyMap.Add(item.id, item);
        }
    }

    public void ConvertFloorData()
    {
        floorMap = new();
        foreach (var item in _floorCsvs)
        {
            floorMap.Add(item.floorId, item);
        }
    }
}

public struct FloorConfigData
{
    public int floorId;
    public int enemyId;
    public int numberOfTrial;
    public int numberOfCard;
}

public struct EnemyConfigData
{
    public int id;
    public int attack;
    public int health;
    public int defense;
}
