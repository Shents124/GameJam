using System.Collections.Generic;
using Sirenix.OdinInspector;

public enum HeroClass
{
    Warrior,
    Mage,
    Fairy,
}


public class HeroDataCsv : SerializedScriptableObject
{
    public Dictionary<int, HeroConfigData> heroMap = new();

    private HeroConfigData[] _heroConfigData;

    public void ConvertData()
    {
        heroMap = new();
        foreach (var item in _heroConfigData)
        {
            heroMap.Add(item.id, item);
        }
    }
}

public struct HeroConfigData
{
    public int id;
    public string heroName;
    public HeroClass heroClass;
    public string skillDescription;
    public int attack;
    public int health;
    public int defense;
    public float critRate;

    public string GetDescription(params object[] arg0)
    {
        return string.Format(skillDescription, arg0);
    }
}