using UnityEngine;

namespace Gameplay
{
    public class Hero103 : BaseHero
    {
        private int _attackBonus = 4;

        public override void OnPassFloor(int _)
        {
            base.OnPassFloor(_);
            Debug.Log("pass floor add atk");
            Attack += _attackBonus;
        }
    }
}