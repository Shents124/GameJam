using System;
using System.Collections.Generic;
using System.IO;
using AssetLoad;
using Assets.Scripts.DataCsv;
using Assets.Scripts.UI;
using Cysharp.Threading.Tasks;
using Gameplay;
using UnityEngine;
using UnityEngine.UI;
using ZBase.Foundation.Singletons;
using Screen = ZBase.UnityScreenNavigator.Core.Screens.Screen;


public class ScreenBattle : Screen
{
    [SerializeField] private RectTransform _heroContainer;
    [SerializeField] private Character _enemy;
    [SerializeField] private Button _battleBtn;
    [SerializeField] private List<UICard> _cardUis = new();

    private List<Card> _cards = new();
    private BaseHero _hero;

    private int _currentFloor = 1;

    private DungeonDataCsv _dungeonDataCsv;
    private HeroConfigData _heroData;
    private CardDataCsv _cardDataCsv;

    protected override void Start()
    {
        _battleBtn.onClick.AddListener(OnClickedBattle);
    }

    public override UniTask Initialize(Memory<object> args)
    {
        var heroId = (int) args.ToArray()[0];
        LoadDataCsv(heroId);
        LoadHero(heroId);
        LoadEnemy();
        return base.Initialize(args);
    }

    private void LoadDataCsv(int heroId)
    {
        var loadService = Singleton.Of<LoadResourceService>();
        _dungeonDataCsv = loadService.LoadCsv<DungeonDataCsv>();

        _heroData = loadService.LoadCsv<HeroDataCsv>().heroMap[heroId];
        _cardDataCsv = loadService.LoadCsv<CardDataCsv>();
    }

    private void LoadHero(int heroId)
    {
        var path = $"hero_{heroId}";
        var heroPrefab = Singleton.Of<LoadResourceService>().LoadAsset<GameObject>(path);
        var heroObject = Instantiate(heroPrefab, _heroContainer);
        _hero = heroObject.GetComponent<BaseHero>();

        _hero.InitData(heroId, _heroData.attack, _heroData.defense, _heroData.health, _heroData.critRate, _heroData.heroName);
    }

    private void LoadEnemy()
    {
        var enemyData = _dungeonDataCsv.enemyMap[_currentFloor];
        _enemy.InitData(enemyData.id, enemyData.attack, enemyData.defense, enemyData.health, 0, "");
        _enemy.Shield = 10;
    }

    private void OnClickedBattle()
    {
        var cardData101 = GetCardCsv(_cardDataCsv.cardDict[101].GetPath());
        var cardData102 = GetCardCsv(_cardDataCsv.cardDict[102].GetPath());
        var cardData103 = GetCardCsv(_cardDataCsv.cardDict[103].GetPath());

        var card101 = new Card101();
        card101.InitData(cardData101);

        var card102 = new Card102();
        card102.InitData(cardData102);

        var card103 = new Card103();
        card103.InitData(cardData103);
        _cards.Add(card101);
        _cards.Add(card102);
        _cards.Add(card103);

        _hero.OnUsePassiveSkill();

        foreach (var card in _cards)
        {
            card.OnUseCard(_hero, _enemy);
        }
    }

    private CardCsv GetCardCsv(string path)
    {
        return Singleton.Of<LoadResourceService>().LoadAsset<CardCsv>(path);
    }
}
