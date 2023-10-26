namespace Gameplay
{
    public class BaseHero : Character
    {
        public HeroClass heroClass;
    
        public void InitData(int id, HeroClass heroClass, int attack, int defense, int hp, float critRate, string characterName)
        {
            InitData(id, attack, defense, hp, critRate, characterName);
            this.heroClass = heroClass;
        }
    }
}