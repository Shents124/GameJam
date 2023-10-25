using System;
using UnityEngine;

namespace Character
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

        protected int id;
        protected float hp;
        protected string name;

        protected Skill skill;

        #endregion

        #region Method

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public virtual void Init()
        {
            SetAnim(AnimState.Idle);
            InitData();
        }

        protected virtual void InitData() { }

        public virtual void OnAttack(Character attacker, Character target, float damage)
        {
            SetAnim(AnimState.Attack);
        }

        public virtual void GetHit(Character attacker, Character target, float damage)
        {
            SetAnim(AnimState.Hurt);
        }

        protected void SetAnim(AnimState state)
        {
            animator.SetInteger("state", (int)state);
        }

        #endregion
    }
}