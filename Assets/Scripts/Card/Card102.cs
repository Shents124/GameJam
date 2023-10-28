using System.Collections;
using Assets.Scripts.DataCsv;
using Gameplay;

public class Card102 : Card
{
    private CardData102 _cardData102;

    public override void InitData(CardCsv cardCsv)
    {
        if (cardCsv is CardData102 cardData102)
        {
            _cardData102 = cardData102;
        }
    }
    public override void OnUseCard(BaseHero baseHero, Character enemy)
    {
        var damage = baseHero.Attack + _cardData102.attack;
        baseHero.AttackTwiceRate += _cardData102.rateAttackDouble;
        baseHero.OnAttack(baseHero, enemy, damage);
    }
}