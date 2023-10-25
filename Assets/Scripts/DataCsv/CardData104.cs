using UnityEngine;

namespace Assets.Scripts.DataCsv
{
    [CreateAssetMenu(fileName = "CardData104", menuName = "ScriptableObjects/CardData104")]
    public class CardData104 : CardCsv
    {
        public int attack;
        public EffectType efffect;
        public int attackMore;
    }
}