using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Game.System;

namespace Game.Network
{
    /// <summary>
    /// ロビーマネージャ
    /// </summary>
    public class LobbyManager : MonoBehaviour, ILobbyCallbacks
    {
        /// <summary>
        /// Prefabのパス
        /// </summary>
        private static readonly string PrefabPath = "Prefabs/System/LobbyManager";

        #region Singleton

        /// <summary>
        /// インスタンス
        /// </summary>
        public static LobbyManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = PrefabManager.Instance.Load<LobbyManager>(PrefabPath);
                }
                return _Instance;
            }
        }
        private static LobbyManager _Instance = null;

        #endregion

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
    }
}
