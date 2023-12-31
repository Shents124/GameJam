﻿using AssetLoad;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using ZBase.Foundation.Singletons;
using Screen = ZBase.UnityScreenNavigator.Core.Screens.Screen;
using TMPro;
using System.Collections.Generic;

namespace Assets.Scripts.UI
{
    public class MainScreen : Screen
    {
        [SerializeField] private Button _buttonSelectHero;
        [SerializeField] private List<TextMeshProUGUI> _heroName;

        // Use this for initialization
        protected override void Start()
        {
            _buttonSelectHero.onClick.AddListener(OnClickedSelectHero);
        }

        private void OnClickedSelectHero()
        {
            UIService.OpenModalAsync(UIPath.select_hero.ToString()).Forget();
        }
    }
}