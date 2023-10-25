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
        [SerializeField] private GameObject dataAnchor;
        [SerializeField] private Button buttonAdd;

        private CardCsv card;
        
        private void Start()
        {
            CardCsv testCard = ScriptableObject.CreateInstance<CardCsv>();
            testCard.id = 101;
            testCard.cardName = "101";
            testCard.star = 5;
            SetData(testCard);
        }

        public void Init()
        {
        }

        private void SelectCard(CardCsv selectedCard)
        {
            var isShowCardData = this.card is null;
            dataAnchor.gameObject.SetActive(isShowCardData);
            buttonAdd.gameObject.SetActive(!isShowCardData);

            if (isShowCardData) return;
            
            this.card = selectedCard;
        }


        public void SetData(CardCsv cardInfo)
        {
            textName.text = cardInfo.cardName;
            textDescription.text = cardInfo.GetDescription();
            
            starCard.sprite = Singleton.Of<LoadResourceService>().LoadAsset<Sprite>($"star_{cardInfo.star}");
            starCard.SetNativeSize();
            
            imgCard.sprite = Singleton.Of<LoadResourceService>().LoadAsset<Sprite>($"card_{cardInfo.id}");
            imgCard.SetNativeSize();
        }

        private void SetUI()
        {
            
        }
    }
}