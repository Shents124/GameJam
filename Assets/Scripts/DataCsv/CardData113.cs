using UnityEngine;

namespace Assets.Scripts.DataCsv
{
    [CreateAssetMenu(fileName = "CardData113", menuName = "ScriptableObjects/CardData113")]
    public class CardData113 : CardCsv
    {
        public int attack;
        public HeroClass heroClass;
        public int attackBonus;
    }
}