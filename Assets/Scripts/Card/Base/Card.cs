using Assets.Scripts.DataCsv;

namespace Gameplay
{
    public abstract class Card
    {
        #region Member

        public CardCsv cardCsv;

        #endregion

        #region Method

        public void Init()
        {
            InitPassive();
        }

        public abstract void InitData(CardCsv cardCsv);

        protected void InitPassive(){ }

        public abstract void OnUseCard(BaseHero baseHero, Character enemy);

        #endregion
    }
}