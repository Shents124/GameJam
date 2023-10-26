using UnityEngine;
using Gameplay;
using System.Collections.Generic;
using ZBase.Foundation.Singletons;
using AssetLoad;

public class BattleService : MonoBehaviour
{
    private Character _hero;
    private Character _enemy;
    private List<Card> _card = new List<Card>();


    private void GetHeroData(int heroId)
    {
        var heroDataCsv = Singleton.Of<LoadResourceService>().LoadCsv<HeroDataCsv>();
        var heroData = heroDataCsv.heroMap[heroId];
    }

}
