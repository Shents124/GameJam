using System;

namespace Gameplay
{
    public class BaseHero : Character
    {
        public HeroClass heroClass;

        public Action<int> onPassFloor;

        protected override void Awake()
        {
            base.Awake();
            onPassFloor = (_) => { };
        }

        public void InitData(int id, HeroClass heroClass, int attack, int defense, int hp, float critRate, string characterName)
        {
            InitData(id, attack, defense, hp, critRate, characterName);
            this.heroClass = heroClass;
            onPassFloor = OnPassFloor;
        }

        protected virtual void OnPassFloor(int _)
        {
        }
    }
}