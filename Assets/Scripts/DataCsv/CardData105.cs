using UnityEngine;

namespace Assets.Scripts.DataCsv
{
    [CreateAssetMenu(fileName = "CardData105", menuName = "ScriptableObjects/CardData105")]
    public class CardData105 : CardCsv
    {
        public int attack;
        public EffectType effect;
        public int stack;
    }
}