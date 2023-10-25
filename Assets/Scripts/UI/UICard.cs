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
    public class UICard : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textName;
        [SerializeField] private TextMeshProUGUI textDescription;
        [SerializeField] private Image imgCard;
        [SerializeField] private Image starCard;
        

        public void Init()
        {
            
        }

        public void SetData(CardCsv cardInfo)
        {
            textName.text = cardInfo.cardName;
            textDescription.text = cardInfo.GetDescription();
            
            starCard.sprite = Singleton.Of<LoadResourceService>().LoadAsset<Sprite>($"star_{cardInfo.star}");
            starCard.SetNativeSize();
        }

        private void SetUI()
        {
            
        }
    }
}