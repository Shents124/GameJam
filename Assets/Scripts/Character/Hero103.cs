namespace Gameplay
{
    public class Hero103 : BaseHero
    {
        private int _attackBonus = 4;

        public override void OnUsePassiveSkill()
        {
            EventContainer.onPassFloor += HandlePassFloor;
        }

        private void HandlePassFloor()
        {
            Attack += _attackBonus;
        }
    }
}