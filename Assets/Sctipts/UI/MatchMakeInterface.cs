using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using UniRx.Operators;
using Game.Network;

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
        /// ルームリストのドロップダウン
        /// </summary>
        [SerializeField]
        private Dropdown RoomListDropdown = null;

        /// <summary>
        /// ルーム参加ボタン
        /// </summary>
        [SerializeField]
        private Button JoinRoomButton = null;

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

        /// <summary>
        /// ルームに参加した
        /// </summary>
        public IObservable<string> OnJoinRoom
        {
            get
            {
                return JoinRoomButton.OnClickAsObservable()
                    .Select((_) => RoomListDropdown.options[RoomListDropdown.value].text);
            }
        }

        void Awake()
        {
            RoomNameInputField.OnValueChangedAsObservable()
                .Select((Value) => string.IsNullOrEmpty(Value))
                .Subscribe((IsEmpty) => CreateRoomButton.interactable = !IsEmpty)
                .AddTo(gameObject);

            LobbyManager.Instance.RoomLIstUpdated
                .Select((Rooms) => Rooms.Count > 0)
                .Subscribe((HasRoom) =>
                {
                    RoomListDropdown.interactable = HasRoom;
                    JoinRoomButton.interactable = HasRoom;
                });

            LobbyManager.Instance.RoomLIstUpdated
                .Subscribe((Rooms) =>
                {
                    RoomListDropdown.options.Clear();
                    foreach (var Room in Rooms)
                    {
                        RoomListDropdown.options.Add(new Dropdown.OptionData(Room.Name));
                    }
                });
        }
    }
}
