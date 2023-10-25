using UnityEngine;

namespace Assets.Scripts.DataCsv
{
    [CreateAssetMenu(fileName = "CardData102", menuName = "ScriptableObjects/CardData102")]
    public class CardData102 : CardCsv
    {
        public int attack;
        public float rateAttackDouble;
    }
}