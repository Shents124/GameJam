namespace Gameplay
{
    public class Hero102 : BaseHero
    {
        private float _critRateBonus = 0.05f;

        public override void OnUsePassiveSkill()
        {
            EventContainer.onPassFloor += HandlePassFloor;
        }

        private void HandlePassFloor()
        {
            CritRate += _critRateBonus;
        }
    }
}