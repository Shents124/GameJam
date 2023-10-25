using UnityEngine;

namespace Card.Base
{
    public abstract class Card : MonoBehaviour
    {
        #region Member

        public int id;
        public int star;
        public string name;
        public string description;

        #endregion

        #region Method

        public void Init()
        {
            InitData();
            InitPassive();
        }
        protected void InitData(){ }
        protected void InitPassive(){ }

        public virtual void OnPlay() { }

        #endregion
    }
}