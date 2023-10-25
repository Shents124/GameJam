using UnityEngine;

namespace Assets.Scripts.DataCsv
{
    [CreateAssetMenu(fileName = "CardData112", menuName = "ScriptableObjects/CardData112")]
    public class CardData112 : CardCsv
    {
        public int attack;
        public float critRate;
    }
}