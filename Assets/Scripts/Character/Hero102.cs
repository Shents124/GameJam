namespace Gameplay
{
    public class Hero102 : BaseHero
    {
        private float _critRateBonus = 0.05f;

        protected override void OnPassFloor(int _)
        {
            CritRate += _critRateBonus;
        }
    }
}