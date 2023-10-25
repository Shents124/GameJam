using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Scripts.DataCsv
{
    public enum CardType
    {
        Passive,
        Active,
    }

    public enum EffectType
    {
        FireMark,
        WaterMark
    }

    [CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData")]
    public class CardCsv : SerializedScriptableObject
    {
        public int id;
        public CardType skillType;
        public string skillDescription;

        public string GetDescription(params object[] args)
        {
            return string.Format(skillDescription, args);
        }
    }
}
