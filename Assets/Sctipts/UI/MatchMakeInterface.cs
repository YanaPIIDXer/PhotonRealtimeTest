using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using UniRx.Operators;

namespace Game.UI
{
    /// <summary>
    /// マッチメイク画面インタフェース
    /// </summary>
    public class MatchMakeInterface : UIComponent
    {
        /// <summary>
        /// ZOrder
        /// </summary>
        public override EZOrder ZOrder => EZOrder.MainHUD;

        /// <summary>
        /// ルーム名入力フォーム
        /// </summary>
        [SerializeField]
        private InputField RoomNameInputField = null;

        /// <summary>
        /// ルーム作成ボタン
        /// </summary>
        [SerializeField]
        private Button CreateRoomButton = null;

        /// <summary>
        /// ルーム作成ボタンを押した
        /// </summary>
        public IObservable<string> OnCreateRoom
        {
            get
            {
                return CreateRoomButton.OnClickAsObservable()
                    .Select((_) => RoomNameInputField.text);
            }
        }

        void Awake()
        {
            RoomNameInputField.OnValueChangedAsObservable()
                .Select((Value) => string.IsNullOrEmpty(Value))
                .Subscribe((IsEmpty) => CreateRoomButton.interactable = !IsEmpty)
                .AddTo(gameObject);
        }
    }
}
