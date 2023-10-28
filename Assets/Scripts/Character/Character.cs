using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public abstract partial class Character : MonoBehaviour
    {
        #region Member

        protected Animator animator;

        protected enum AnimState
        {
            Idle,
            Attack,
            Hurt,
        }

        public int Id { get; protected set; }
        public int Attack { get; protected set; }
        public int Defense { get; protected set; }
        public int Shield { get; set; }

        public int Hp { get; set; }
        public float CritRate { get; protected set; }
        public string CharacterName { get; protected set; }
        public float AttackTwiceRate { get; set; }

        protected Skill skill;

        #endregion

        #region Event

        protected event Action<Character, Character, int> OnAttackEvent;

        #endregion

        #region Method

        protected virtual void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public virtual void Init()
        {
            SetAnim(AnimState.Idle);
   
        }

        public virtual void InitData(int id, int attack, int defense, int hp, float critRate, string characterName) 
        {
            this.Id = id;
            this.Attack = attack;
            this.Defense = defense;
            this.Hp = hp;
            this.CritRate = critRate;
            this.CharacterName = characterName;
        }

        public virtual void OnUsePassiveSkill()
        {

        }

        public virtual void OnAttack(Character attacker, Character target, int damage)
        {
            SetAnim(AnimState.Attack);
            OnAttackEvent?.Invoke(attacker, target, damage);
            target.GetHit(attacker, target, GetDamage(damage));
            Debug.Log($"damage: {GetDamage(damage)}, hp target remain: {target.Hp}");
        }

        public void OnAttackTwice(Character attacker, Character target, int damage)
        {
            SetAnim(AnimState.Attack);
            target.GetHit(attacker, target, GetDamage(damage));
            Debug.Log($"damage: {GetDamage(damage)}, hp target remain: {target.Hp}");
        }

        private int GetDamage(int damage)
        {
            var ran = Random.Range(0, 1f);
            return ran < CritRate ? damage * 2 : damage;
        }

        public virtual void GetHit(Character attacker, Character target, int damage)
        {    
            if (Shield > 0)
            {
                if (damage >= Shield)
                {               
                    damage -= Shield;
                    Shield = 0;                 
                }
                else
                {
                    Shield -= damage;
                   
                    return;
                }            
            }

            var hpLose = damage - Defense;
          
            if (hpLose > 0)
            {
                Hp -= hpLose;
            }
            else
            {
                return;
            }

            SetAnim(AnimState.Hurt);
        }

        protected void SetAnim(AnimState state)
        {
            animator.SetInteger("state", (int)state);
        }

        #endregion
    }
}