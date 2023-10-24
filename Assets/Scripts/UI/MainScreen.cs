﻿using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Screen = ZBase.UnityScreenNavigator.Core.Screens.Screen;

namespace Assets.Scripts.UI
{
    public class MainScreen : Screen
    {
        [SerializeField] private Button _openSelectHero;

        // Use this for initialization
        protected override void Start()
        {
            _openSelectHero.onClick.AddListener(OnClickedSelectHero);
        }

        private void OnClickedSelectHero()
        {
            UIService.OpenModalAsync(UIPath.select_hero_2.ToString(), closeWhenClickOnBackDrop: false).Forget();
        }
    }
}