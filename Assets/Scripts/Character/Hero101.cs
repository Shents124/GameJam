namespace Gameplay
{
    public class Hero101 : BaseHero
    {
        protected float rateAttackTwice = 0.3f;

        public override void InitData(int id, int attack, int defense, int hp, float critRate, string characterName)
        {
            base.InitData(id, attack, defense, hp, critRate, characterName);
            AttackTwiceRate = rateAttackTwice;
        }

        public override void OnUsePassiveSkill()
        {
            OnAttackEvent += CheckOnAttackTwice;
        }

        private void CheckOnAttackTwice(Character attacker, Character target, int damage)
        {
            var ran = UnityEngine.Random.Range(0, 1f);
            if (ran <= AttackTwiceRate)
            {
                OnAttackTwice(attacker, target, damage);
            }
        }
    }
}