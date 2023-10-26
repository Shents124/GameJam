using Assets.Scripts.DataCsv;
using Gameplay;

public class Card103 : Card
{
    private CardData103 _cardData103;

    public override void InitData(CardCsv cardCsv)
    {
        if (cardCsv is CardData103 cardData103)
        {
            _cardData103 = cardData103;
        }
    }

    public override void OnUseCard(BaseHero baseHero, Character enemy)
    {
        var damage = baseHero.Attack + _cardData103.attack;
        baseHero.OnAttack(baseHero, enemy, damage);

        if (enemy.Hp <= _cardData103.hpBelow)
            enemy.Hp -= _cardData103.hpLoseMore;
    }
}
