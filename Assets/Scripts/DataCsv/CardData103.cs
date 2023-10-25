using UnityEngine;

namespace Assets.Scripts.DataCsv
{
    [CreateAssetMenu(fileName = "CardData103", menuName = "ScriptableObjects/CardData103")]
    public class CardData103 : CardCsv
    {
        public int attack;
        public int hpBelow;
        public int hpLoseMore;
    }
}