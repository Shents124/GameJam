using System;
using AssetLoad;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ZBase.Foundation.Singletons;

namespace Assets.Scripts.UI
{
    public class UIHero : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textName;
        [SerializeField] private Transform heroAnchor;
        [SerializeField] private TextMeshProUGUI textClass;
        [SerializeField] private TextMeshProUGUI textDescription;
        [SerializeField] private TextMeshProUGUI textAtk;
        [SerializeField] private TextMeshProUGUI textHp;
        [SerializeField] private TextMeshProUGUI textDef;
        [SerializeField] private TextMeshProUGUI textCritRate;
        [SerializeField] private Button buttonSelect;

        private Action<int> _onClickEvent;

        private int _id;
        private string _name;
        private HeroClass _heroClass;
        private int _attack;
        private int _health;
        private int _defense;
        private float _critRate;
        private string _skillDescription;

        public void Start()
        {
            _onClickEvent= (_) => { };
            buttonSelect.onClick.AddListener(OnSelect);
        }

        private void OnSelect()
        {
            UIService.OpenScreen(UIPath.screen_battle.ToString(), args: this._id).Forget();
            UIService.CloseModal();
        }

        public void SetData(HeroConfigData data)
        {
            this._id = data.id;
            this._name = data.heroName;
            this._heroClass = data.heroClass;
            this._attack = data.attack;
            this._health = data.health;
            this._defense = data.defense;
            this._critRate = data.critRate;
            this._skillDescription = data.skillDescription;

            SetUI();
        }

        private void SetUI()
        {
            textName.text = _name;
            textClass.text = GetHeroClassText(_heroClass);
            textDescription.text = _skillDescription;
            textAtk.text = $"ATK: {_attack}";
            textHp.text = $"HP: {_health}";
            textDef.text = $"DEF: {_defense}";
            textCritRate.text = $"CRIT: {_critRate}";
            
            var path = $"hero_{_id}";
            var heroPrefab = Singleton.Of<LoadResourceService>().LoadAsset<GameObject>(path);
            var heroObject = Instantiate(heroPrefab, heroAnchor);
            
        }

        private static string GetHeroClassText(HeroClass heroClass){
            return heroClass switch {
                HeroClass.Fairy => "Fairy",
                HeroClass.Warrior => "Warrior",
                HeroClass.Mage => "Mage",
                _ => ""
            };
        }
    }
}