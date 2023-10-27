using System;
using System.Net.Mime;
using AssetLoad;
using Assets.Scripts.DataCsv;
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


        private int _id;
        private HeroClass _heroClass;
        private int _attack;
        private int _health;
        private int _defense;
        private float _critRate;
        private string _skillDescription;

        public void Init()
        {
            
        }

        private void SelectCard(CardCsv selectedCard)
        {
            
        }


        public void SetData(HeroConfigData data)
        {
            this._id = data.id;
            this._heroClass = data.heroClass;
            this._attack = data.attack;
            this._health = data.health;
            this._defense = data.defense;
            this._critRate = data.critRate;
            this._skillDescription = data.skillDescription;
        }

        private void SetUI()
        {
            textName.text = "Buba";
            textDescription.text = _skillDescription;
            textAtk.text = $"ATK: {_attack}";
            textHp.text = $"HP: {_health}";
            textDef.text = $"DEF: {_defense}";
            textCritRate.text = $"CRIT: {_critRate}";
        }
    }
}