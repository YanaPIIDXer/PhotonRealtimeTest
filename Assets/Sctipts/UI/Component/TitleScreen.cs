using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using Game.Network;

namespace Game.UI.Component
{
    /// <summary>
    /// タイトル画面
    /// </summary>
    public class TitleScreen : UIComponent
    {
        /// <summary>
        /// ZOrder
        /// </summary>
        public override EZOrder ZOrder => EZOrder.MainHUD;

        /// <summary>
        /// スタートボタン
        /// </summary>
        [SerializeField]
        private Button StartButton = null;

        void Awake()
        {
            StartButton.OnClickAsObservable()
                .Subscribe((_) =>
                {
                    StartButton.interactable = false;
                    ServerConnection.Instance.Connect();
                });
        }
    }
}
