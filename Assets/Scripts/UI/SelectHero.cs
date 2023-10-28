using AssetLoad;
using UnityEngine;
using ZBase.Foundation.Singletons;
using System.Collections.Generic;
using Assets.Scripts.UI;
using ZBase.UnityScreenNavigator.Core.Modals;


public class SelectHero : Modal
{
    [SerializeField] private List<UIHero> listHeroPrefab;

    // Use this for initialization
    protected override void Start()
    {
        LoadHeroes();
    }

    private void LoadHeroes()
    {
        var heroData = Singleton.Of<LoadResourceService>().LoadCsv<HeroDataCsv>();
        for (int i = 0; i < heroData.heroMap.Count; i++)
        {
            listHeroPrefab[i].SetData(heroData.heroMap[i]);
        }
    }
}