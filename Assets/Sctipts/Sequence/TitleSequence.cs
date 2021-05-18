using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using Game.Network;
using Game.UI;
using Game.UI.Component;

namespace Game.Sequence
{
    /// <summary>
    /// タイトルシーケンス
    /// </summary>
    public class TitleSequence : MonoBehaviour
    {
        void Awake()
        {
            ConnectionEventListener.Instance.Connected
                .Subscribe((_) =>
                {
                    ServerConnection.Instance.JoinLobby();
                });

            LobbyEventListener.Instance.RoomListUpdate
                .Subscribe((Rooms) =>
                {
                    Debug.Log("RoomCount:" + Rooms.Count);
                });

            UIManager.Instance.Show<TitleScreen>("TitleScreen");
        }
    }
}
