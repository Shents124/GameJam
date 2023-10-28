namespace Gameplay
{
    public class Hero103 : BaseHero
    {
        private int _attackBonus = 4;

        protected override void OnPassFloor(int _)
        {
            Attack += _attackBonus;
        }
    }
}