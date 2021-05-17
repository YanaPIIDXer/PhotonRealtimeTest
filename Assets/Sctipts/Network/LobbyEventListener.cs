using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

namespace Game.Network
{
    /// <summary>
    /// ロビーイベントリスナ
    /// </summary>
    public class LobbyEventListener : MonoBehaviour, ILobbyCallbacks
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        public static LobbyEventListener Instance { get; private set; }

        public void OnJoinedLobby()
        {
        }

        public void OnLeftLobby()
        {
        }

        public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
        {
        }

        public void OnRoomListUpdate(List<RoomInfo> roomList)
        {
        }

        void Awake()
        {
            Instance = this;
        }
    }
}
