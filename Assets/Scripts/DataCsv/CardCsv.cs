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
        public string cardName;
        public int star;
        public CardType skillType;
        public string skillDescription;

        public virtual string GetDescription()
        {
            return default;
        }
    }
}