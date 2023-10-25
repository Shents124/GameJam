using AssetLoad;
using Cysharp.Threading.Tasks;
using UnityEngine;
using ZBase.Foundation.Singletons;
using TMPro;
using System.Collections.Generic;
using ZBase.UnityScreenNavigator.Core.Modals;


public class SelectHero : Modal
{
    [SerializeField] private List<TextMeshProUGUI> _heroes;

    // Use this for initialization
    protected override void Start()
    {
        LoadHeroes();
    }

    private void LoadHeroes()
    {
        var heroData = Singleton.Of<LoadResourceService>().LoadCsv<HeroDataCsv>();
        Debug.Log(heroData);

        var index = 0;
        foreach (var hero in heroData.heroMap.Values)
        {
            Debug.Log(hero.id);
            _heroes[index].text = hero.id.ToString();
            index++;
        }
       
    }
}