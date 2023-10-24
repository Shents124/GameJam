using System.Collections.Generic;
using Sirenix.OdinInspector;

public enum SkillType
{
    Passive,
    Active,
}

public class CardCsv : SerializedScriptableObject
{
    public Dictionary<int, CardConfigData> cardMap = new();

    private CardConfigData[] _cardCsvs;

    public void ConvertData()
    {
        cardMap = new();
        foreach (var item in _cardCsvs)
        {
            cardMap.Add(item.id, item);        
        }
    }
}

public struct CardConfigData
{
    public int id;
    public SkillType skillType;
    public string skillDescription;



    public string GetDescription(params object[] args)
    {
        return string.Format(skillDescription, args);
    }
}

public struct CardEffectData 
{

}
