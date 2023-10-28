using Assets.Scripts.DataCsv;
using Gameplay;

public class Card101 : Card
{
    private CardData101 _cardData101;

    public override void InitData(CardCsv cardCsv)
    {
        if (cardCsv is CardData101 cardData101)
        {
            _cardData101 = cardData101;
        }
    }

    public override void OnUseCard(BaseHero baseHero, Character enemy)
    {
        var damage = baseHero.Attack + _cardData101.attack;
        baseHero.OnAttack(baseHero, enemy, damage);
    }
}
