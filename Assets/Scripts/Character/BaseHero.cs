using System;
using UnityEngine;

namespace Gameplay
{
    public class BaseHero : Character
    {
        public HeroClass heroClass;

        public Action<int> onPassFloor;

        public void InitData(int id, HeroClass heroClass, int attack, int defense, int hp, float critRate, string characterName)
        {
            onPassFloor = _ => { };
            base.InitData(id, attack, defense, hp, critRate, characterName);
            this.heroClass = heroClass;
            onPassFloor += OnPassFloor;
        }

        public virtual void OnPassFloor(int _)
        {
            Debug.Log("OnPassFloor");
        }
    }
}