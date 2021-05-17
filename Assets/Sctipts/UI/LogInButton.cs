using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

namespace Game.UI
{
    /// <summary>
    /// ログインボタン
    /// </summary>
    public class LogInButton : UIComponent
    {
        /// <summary>
        /// ZOrder
        /// </summary>
        public override EZOrder ZOrder => EZOrder.Overlay;

        /// <summary>
        /// ボタン
        /// </summary>
        private Button PressButton = null;

        /// <summary>
        /// 押された
        /// </summary>
        public IObservable<Unit> OnPressed { get { return PressButton.OnClickAsObservable(); } }

        void Awake()
        {
            PressButton = GetComponent<Button>();
        }
    }
}
